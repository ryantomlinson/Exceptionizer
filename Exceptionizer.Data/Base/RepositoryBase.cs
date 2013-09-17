using System;
using System.Configuration;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;
using MongoDB.Driver;
using Nest;

namespace Exceptionizer.Data.Base
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntityDto
	{
		protected ElasticClient elasticSearchClient;
		protected MongoClient mongoClient;
		protected MongoDatabase mongoExceptionDatabaseKeys;
		protected MongoCollection<T> mongoExceptionCollection;

		protected RepositoryBase(string mongoCollectionName)
		{
			ConfigureMongoDb(mongoCollectionName);
			ConfigureElasticSearch();
		}

		protected RepositoryBase(string mongoDatabaseName, string mongoCollectionName)
		{
			ConfigureMongoDb(mongoCollectionName, mongoDatabaseName);
			ConfigureElasticSearch();
		}

		private void ConfigureElasticSearch()
		{
			var elasticsSearchConnectionString = ConfigurationManager.AppSettings["ElasticSeachConnectionString"];
			var settings = new ConnectionSettings(new Uri(elasticsSearchConnectionString));
			settings.SetDefaultIndex("exceptionizer");
			elasticSearchClient = new ElasticClient(settings);
		}

		private void ConfigureMongoDb(string mongoCollectionName)
		{
			ConfigureMongoDb(MongoDatabaseKeys.Exceptionizer, mongoCollectionName);
		}

		private void ConfigureMongoDb(string mongoDatabaseName, string mongoCollectionName)
		{
			mongoClient = new MongoClient(GetMongoDbConnectionString());
			var server = mongoClient.GetServer();
			mongoExceptionDatabaseKeys = server.GetDatabase(mongoDatabaseName);
			mongoExceptionCollection = mongoExceptionDatabaseKeys.GetCollection<T>(mongoCollectionName);
		}

		private string GetMongoDbConnectionString()
		{
			return ConfigurationManager.AppSettings["MongoDbConnectionString"];
		}

		public void Add(T messageDto)
		{
			try
			{
				messageDto.Id = Guid.NewGuid();
				messageDto.CreationDate = DateTime.UtcNow;

				mongoExceptionCollection.Insert(messageDto);

				ConnectionStatus connectionStatus;
				if (elasticSearchClient.TryConnect(out connectionStatus))
				{
					elasticSearchClient.Index(messageDto);
				}
				else
				{
					//throw exception here
				}
			}
			catch (Exception)
			{
				
			}
		}
	}
}