using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonGenerator.Infrastructure.DataAccess
{
    public class FirestoreRepository<TDbModel> : IRepository<TDbModel>
    {
        private readonly FirestoreDb db;

        private static string CollectionName => typeof(TDbModel).Name + "s";

        public FirestoreRepository(FirestoreDb db)
        {
            this.db = db;
        }

        public async Task Add(TDbModel elt)
        {
            CollectionReference colRef = db.Collection(CollectionName);
            await colRef.AddAsync(elt);
        }

        public async Task<IReadOnlyCollection<TDbModel>> Get()
        {
            Query employeeQuery = db.Collection(CollectionName);
            QuerySnapshot snapshot = await employeeQuery.GetSnapshotAsync();

            return snapshot.Documents.Select(doc => doc.ConvertTo<TDbModel>()).ToList();
        }
    }
}
