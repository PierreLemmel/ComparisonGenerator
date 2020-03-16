using ComparisonGenerator.Infrastructure.DataAccess;
using ComparisonGenerator.Infrastructure.Events;
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
using System.IO;

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
                string credentialsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "comparisongenerator-e2b8c7b24f8e.json");

                GoogleCredential cred = GoogleCredential.FromFile(credentialsPath);
                Channel channel = new Channel(FirestoreClient.DefaultEndpoint.Host,
                              FirestoreClient.DefaultEndpoint.Port,
                              cred.ToChannelCredentials());
                FirestoreClient client = FirestoreClient.Create(channel);
                FirestoreDb db = FirestoreDb.Create("comparisongenerator", client);

                return db;
            });

            services.AddSingleton<ComparisonHandler>();

            services.AddSingleton<IEventStore, EventStore>(sp =>
            {
                var store = new EventStore(sp.GetService<IRepository<Event>>());

                store.RegisterHandler<ComparisonAdded>(sp.GetService<ComparisonHandler>());

                return store;
            });

            services.AddSingleton<IComparandSource, RawMemoryComparandSource>();
            services.AddSingleton(typeof(IRepository<>), typeof(FirestoreRepository<>));
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
