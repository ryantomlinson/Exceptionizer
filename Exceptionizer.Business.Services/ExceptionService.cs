using System;
using AutoMapper;
using Exceptionizer.Business.Domain;
using Exceptionizer.Data.Contracts;
using Exceptionizer.Data.Entities;

namespace Exceptionizer.Business.Services
{
	public class ExceptionService
	{
		private readonly IExceptionRepository exceptionRepository;

		public ExceptionService(IExceptionRepository exceptionRepository)
		{
			this.exceptionRepository = exceptionRepository;
		}

		public void Add(ExceptionizerMessage message)
		{
			try
			{
				var messageDto = Mapper.Map<ExceptionizerMessageDto>(message);
				exceptionRepository.Add(messageDto);
			}
			catch (Exception)
			{
				
			}
		}
	}
}