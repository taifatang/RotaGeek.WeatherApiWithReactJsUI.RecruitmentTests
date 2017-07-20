using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace RotaGeek.Repository
{

    public class DocumentDbRepository<T> : IDocumentDbRepository<T> where T : class, new()
    {
        private readonly string _databaseId;
        private readonly string _collectionId;
        private readonly IDocumentClient _documentClient;

        public DocumentDbRepository(string databaseId, string collectionId, IDocumentClient documentClient)
        {
            _databaseId = databaseId;
            _collectionId = collectionId;
            _documentClient = documentClient;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Factory.StartNew(() => _documentClient.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId)));
        }

        public async Task CreateItemAsync(T item)
        {
            await _documentClient.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId), item);
        }
        public async Task CreateOrUpdateItemAsync(T item)
        {
            await _documentClient.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri(_databaseId, _collectionId), item);
        }
    }
}