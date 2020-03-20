using ComparisonGenerator.Infrastructure.DataAccess;
using ComparisonGenerator.Infrastructure.Events;
using ComparisonGenerator.Logic;
using ComparisonGenerator.Logic.Events;
using ComparisonGenerator.Logic.Handlers;
using ComparisonGenerator.Models;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ComparisonGenerator.Core.Reflection;
using FluentValidation;

namespace ComparisonGenerator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSingleton<FirestoreDb>(sp =>
            {
                string credentialsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comparisongenerator-6b32a2eee55a.json");

                GoogleCredential cred = GoogleCredential.FromFile(credentialsPath);
                Channel channel = new Channel(FirestoreClient.DefaultEndpoint.Host,
                              FirestoreClient.DefaultEndpoint.Port,
                              cred.ToChannelCredentials());
                FirestoreClient client = FirestoreClient.Create(channel);
                FirestoreDb db = FirestoreDb.Create("comparisongenerator", client);

                return db;
            });

            SetupEventStore(services);
            SetupValidators(services);

            services.AddSingleton(typeof(IRepository<>), typeof(FirestoreRepository<>));
        }

        private void SetupEventStore(IServiceCollection services)
        {
            Assembly eventAssembly = Assembly.GetAssembly(typeof(EventBase));

            IEnumerable<(Type EventType, Type HandlerType)> eventTypes = eventAssembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.ImplementsOpenGenericInterface(typeof(IEventHandler<>)))
                .Select(t => (EventType: t.GetTypeImplementingOpenGenericInterface(typeof(IEventHandler<>)), HandlerType: t));

            services.AddSingleton<ComparisonHandler>();

            MethodInfo registerHandlerGenericMethod = typeof(IEventStore).GetMethod(nameof(IEventStore.RegisterHandler));

            services.AddSingleton<IEventStore>(sp =>
            {
                IEventStore store = new EventStore(sp.GetService<IRepository<Event>>());

                foreach((Type EventType, Type HandlerType) in eventTypes)
                {
                    MethodInfo method = registerHandlerGenericMethod.MakeGenericMethod(EventType);

                    object handler = sp.GetService(HandlerType);
                    method.Invoke(store, new[] { handler });
                }

                return store;
            });
        }

        private void SetupValidators(IServiceCollection services)
        {
            Assembly validatorsAssembly = GetType().Assembly;

            IEnumerable<(Type ModelType, Type ValidatorType)> validatorTypes = validatorsAssembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.ImplementsOpenGenericInterface(typeof(IValidator<>)))
                .Select(t => (ModelType: t.GetTypeImplementingOpenGenericInterface(typeof(IValidator<>)), ValidatorType: t));

            foreach ((Type ModelType, Type ValidatorType) in validatorTypes)
            {
                Type interfaceType = typeof(IValidator<>).MakeGenericType(ModelType);
                services.AddSingleton(interfaceType, ValidatorType);
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}