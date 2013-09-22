using System;
using System.Configuration;
using Exceptionizer.Common.Exceptions.ElasticSearch;
using Exceptionizer.Common.Exceptions.NoSql;
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
		protected MongoCollection<T> mongoCollection;

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

		/// <exception cref="UnableToConfigureElasticSearchException">Thrown when there are issues configuring the elastic search client</exception>
		private void ConfigureElasticSearch()
		{
			try
			{
				var elasticsSearchConnectionString = ConfigurationManager.AppSettings["ElasticSeachConnectionString"];
				var settings = new ConnectionSettings(new Uri(elasticsSearchConnectionString));
				settings.SetDefaultIndex("exceptionizer");
				elasticSearchClient = new ElasticClient(settings);
			}
			catch (Exception exception)
			{
				//TODO: log
				throw new UnableToConfigureElasticSearchException("Problem constructing the elastic search client", exception);
			}
			
		}

		/// <exception cref="UnableToConfigureMongoDbException">Thrown when there are issues configuring the mongodb client</exception>
		private void ConfigureMongoDb(string mongoCollectionName)
		{
			ConfigureMongoDb(MongoDatabaseKeys.Exceptionizer, mongoCollectionName);
		}

		/// <exception cref="UnableToConfigureMongoDbException">Thrown when there are issues configuring the mongodb client</exception>
		private void ConfigureMongoDb(string mongoDatabaseName, string mongoCollectionName)
		{
			try
			{
				mongoClient = new MongoClient(GetMongoDbConnectionString());
				var server = mongoClient.GetServer();
				mongoExceptionDatabaseKeys = server.GetDatabase(mongoDatabaseName);
				mongoCollection = mongoExceptionDatabaseKeys.GetCollection<T>(mongoCollectionName);
			}
			catch (Exception exception)
			{
				throw new UnableToConfigureMongoDbException("Problem configuring the MongoDb client", exception);
			}
		}

		private string GetMongoDbConnectionString()
		{
			return ConfigurationManager.AppSettings["MongoDbConnectionString"];
		}

		/// <exception cref="UnableToPersistToMongoDbException">Thrown when there are connection issues to MongoDB</exception>
		/// <exception cref="UnableToPersistToElasticSearchException">Thrown when there are connection issues to ElasticSearch</exception>
		public void Add(T objectDto)
		{
			try
			{
				objectDto.Id = Guid.NewGuid();
				objectDto.CreationDate = DateTime.UtcNow;

				AddToNoSqlStore(objectDto);
				AddToElasticSearch(objectDto);

			}
			catch (UnableToPersistToMongoDbException exception)
			{
				//TODO: log here
				throw;
			}
			catch (UnableToPersistToElasticSearchException exception)
			{
				//TODO: log here
				throw;
			}
		}

		/// <exception cref="UnableToPersistToMongoDbException">Thrown when there are connection issues to MongoDB</exception>
		private void AddToNoSqlStore(T objectDto)
		{
			try
			{
				mongoCollection.Insert(objectDto);
			}
			catch (Exception exception)
			{
				throw new UnableToPersistToMongoDbException("A problem occured inseting into MongoDB", exception);
			}
		}

		/// <exception cref="UnableToPersistToElasticSearchException">Thrown when there are connection issues to ElasticSearch</exception>
		private void AddToElasticSearch(T objectDto)
		{
			try
			{
				ConnectionStatus connectionStatus;
				if (elasticSearchClient.TryConnect(out connectionStatus))
				{
					elasticSearchClient.Index(objectDto);
				}
				else
				{
					throw new UnableToPersistToElasticSearchException("Unable to connect to ElasticSearch");
				}
			}
			catch (Exception exception)
			{
				throw new UnableToPersistToElasticSearchException("Unable to index to ElasticSearch", exception);
			}
		}
	}
}