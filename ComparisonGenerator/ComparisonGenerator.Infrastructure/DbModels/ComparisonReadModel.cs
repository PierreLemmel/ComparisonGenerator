using Google.Cloud.Firestore;
using System;

namespace ComparisonGenerator.Models
{
    [FirestoreData]
    public class ComparisonReadModel
    {
        [FirestoreDocumentId]
        public string Id { get; set; }
        [FirestoreDocumentCreateTimestamp]
        public DateTime Date { get; set; }
        [FirestoreProperty]
        public string Author { get; set; }
        [FirestoreProperty]
        public string Content { get; set; }
    }
}