using System;
using System.Configuration;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;
using MongoDB.Driver;
using Nest;

namespace Exceptionizer.Data
{
	public class ExceptionRepository : IExceptionRepository
	{
		private MongoClient mongoClient;
		private MongoDatabase mongoExceptionDatabase;
		private MongoCollection<ExceptionizerMessageDto> mongoExceptionCollection;

		private ElasticClient elasticSearchClient;
		
		public ExceptionRepository()
		{
			ConfigureMongoDB();
			ConfigureElasticSearch();
		}

		private void ConfigureElasticSearch()
		{
			var elasticsSearchConnectionString = ConfigurationManager.AppSettings["ElasticSeachConnectionString"];
			var settings = new ConnectionSettings(new Uri(elasticsSearchConnectionString));
			elasticSearchClient = new ElasticClient(settings);
		}

		private void ConfigureMongoDB()
		{
			mongoClient = new MongoClient(GetMongoDbConnectionString());
			var server = mongoClient.GetServer();
			mongoExceptionDatabase = server.GetDatabase("exception");
			mongoExceptionCollection = mongoExceptionDatabase.GetCollection<ExceptionizerMessageDto>(MongoCollectionKeys.ExceptionsCollection);
		}

		private string GetMongoDbConnectionString()
		{
			return ConfigurationManager.AppSettings["MongoDbConnectionString"];
		}

		public void Add(ExceptionizerMessageDto messageDto)
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