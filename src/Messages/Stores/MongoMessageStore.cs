using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SonjaMemorial.Messages;
public class MongoMessageStore : IMessageStore
{
  IMongoDatabase _db;
  IMongoCollection<MongoMessageData> _collection;
  public MongoMessageStore(string connectionString, string databaseName, string collectionName)
  {
    var settings = MongoClientSettings.FromConnectionString(connectionString);
    var client = new MongoClient(settings);
    _db = client.GetDatabase(databaseName);
    _collection = _db.GetCollection<MongoMessageData>(collectionName);
  }
  public async Task Add(MessageData message)
  {
    var data = new MongoMessageData(message);
    await _collection.InsertOneAsync(data);
  }

  public async Task<IEnumerable<MessageData>> GetAll()
  {
    return await _collection.Find<MongoMessageData>(_ => true).ToListAsync();
  }
}

public class MongoMessageData : MessageData {
  public MongoMessageData(string body, DateTime created) : base(body, created) {
  }

  public MongoMessageData(MessageData data) : base(data.Body, data.Created) {
  }

  [BsonId]
  public ObjectId Id { get; set; }
}

