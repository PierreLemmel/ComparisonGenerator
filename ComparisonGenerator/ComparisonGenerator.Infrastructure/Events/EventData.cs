using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComparisonGenerator.Infrastructure.Events
{
    [FirestoreData]
    public class Event
    {
        [FirestoreDocumentCreateTimestamp]
        public DateTime Date { get; set; }
        [FirestoreProperty]
        public string Type { get; set; }
        [FirestoreProperty]
        public string JsonContent { get; set; }
    }
}
