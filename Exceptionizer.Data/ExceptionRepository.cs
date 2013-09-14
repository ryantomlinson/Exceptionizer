using System;
using System.Configuration;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;
using MongoDB.Driver;

namespace Exceptionizer.Data
{
	public class ExceptionRepository : IExceptionRepository
	{
		private readonly MongoClient client;
		private readonly MongoDatabase exceptionDatabase;
		private readonly MongoCollection<ExceptionizerMessageDto> exceptionCollection;
		
		public ExceptionRepository()
		{
			client = new MongoClient(GetConnectionString());
			var server = client.GetServer();
			exceptionDatabase = server.GetDatabase("exception");
			exceptionCollection = exceptionDatabase.GetCollection<ExceptionizerMessageDto>(MongoCollectionKeys.ExceptionsCollection);
		}

		private string GetConnectionString()
		{
			return ConfigurationManager.AppSettings["MongoDbConnectionString"];
		}

		public void Add(ExceptionizerMessageDto messageDto)
		{
			try
			{
				messageDto.Id = Guid.NewGuid();
				messageDto.CreationDate = DateTime.UtcNow;

				exceptionCollection.Insert(messageDto);
			}
			catch (Exception)
			{
				
			}
		}
	}
}