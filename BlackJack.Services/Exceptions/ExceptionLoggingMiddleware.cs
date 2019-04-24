using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace BlackJack
{
  public class ExceptionLoggingMiddleware
  {
    private readonly RequestDelegate _next;
    private Logger log = LogManager.GetCurrentClassLogger();

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
        string stack = ex.StackTrace;
        string source = ex.Source;
        string message = ex.Message;

        string error = $@"{source} | {message}";
        log.Error(error);


        //log.Trace("trace message");
        //log.Debug("debug message");
        //log.Info("info message");
        //log.Warn("warn message");
        //log.Fatal("fatal message");

        System.Diagnostics.Debug.WriteLine($"The following error happened: {ex.Message}");
        throw;
      }
    }






  }
}
