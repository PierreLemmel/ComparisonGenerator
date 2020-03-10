using Google.Cloud.Firestore;

namespace ComparisonGenerator.Infrastructure.DbModels
{
    [FirestoreData]
    public class ComparisonDbModel
    {
        public string ComparisonDbModelId { get; set; }
        [FirestoreProperty]
        public string Author { get; set; }
        [FirestoreProperty]
        public string Content { get; set; }
    }
}