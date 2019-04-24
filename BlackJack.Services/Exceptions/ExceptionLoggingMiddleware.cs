using BlackJack.Exceptions;
using BlackJackServices.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLog;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
	public class ExceptionLoggingMiddleware
	{
		private Logger log = LogManager.GetCurrentClassLogger();
		private readonly RequestDelegate _next;

		public ExceptionLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				HandleExceptionAsync(context, ex);
				throw;
			}
		}

		private void HandleExceptionAsync(HttpContext context, Exception ex)
		{
			string error = null;
			if (ex is ModelNotValidException)
			{
				error = $"{ex.Source} | Model types error | {ex.Message}";
				log.Error(error);
			}
			if (ex is NotFoundException)
			{
				error = $"{ex.Source} | Not found | {ex.Message}";
				log.Error(error);
			}
			if (ex is CacheNotFoundException)
			{
				error = $"{ex.Source} | Game moves empty, game not registred | {ex.Message}";
				log.Error(error);
			}
			if (ex is MoveNotFoundException)
			{
				error = $"{ex.Source} | Move not found | {ex.Message}";
				log.Error(error);
			}
			if (ex is StatisticDataNotFound)
			{
				error = $"{ex.Source} | Statistic error | {ex.Message}";
				log.Error(error);
			}
			if (ex is GameUserNotFoundException)
			{
				error = $"{ex.Source} | GameUser Not Found | {ex.Message}";
				log.Error(error);
			}


		}

	}
}
