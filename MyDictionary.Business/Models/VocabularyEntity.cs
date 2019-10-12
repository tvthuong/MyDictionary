using SQLite;

namespace MyDictionary.Business.Models
{
    public class VocabularyEntity
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { set; get; }
    }
}
