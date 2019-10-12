using MyDictionary.Business.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;

namespace MyDictionary.Business
{
    public class DictionaryBD
    {
        public static DictionaryBD Instance { get; } = new DictionaryBD();

        public IEnumerable<VocabularyEntity> Vocabularies { get; private set; }

        private SQLiteAsyncConnection _connection;

        public void Initialize(string dbFolder)
        {
            string dbPath = Path.Combine(dbFolder, "Dictionary.db3");
            _connection = new SQLiteAsyncConnection(dbPath);
            CreateTables();
            GetEntities();
        }

        public void Insert<T>(T entity)
        {
            _connection.InsertAsync(entity).Wait();
            if (entity is VocabularyEntity)
            {
                GetDictionaryEntities();
            }
        }

        public void Update<T>(T entity)
        {
            _connection.UpdateAsync(entity).Wait();
            if (entity is VocabularyEntity)
            {
                GetDictionaryEntities();
            }
        }

        public void Delete<T>(T entity)
        {
            if (entity is VocabularyEntity dictionaryEntity)
            {
                _connection.DeleteAsync<T>(dictionaryEntity.Id).Wait();
                GetDictionaryEntities();
            }
        }

        private void GetEntities()
        {
            GetDictionaryEntities();
        }

        private void GetDictionaryEntities()
        {
            Vocabularies = _connection.Table<VocabularyEntity>().ToListAsync().Result;
        }

        private void CreateTables()
        {
            _connection.CreateTableAsync<VocabularyEntity>().Wait();
        }

        private DictionaryBD() { }
    }
}
