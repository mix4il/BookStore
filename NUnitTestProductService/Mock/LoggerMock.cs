using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProductService.Mock
{
    internal class LoggerMock<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return state as IDisposable;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return false;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {

        }
    }
}
