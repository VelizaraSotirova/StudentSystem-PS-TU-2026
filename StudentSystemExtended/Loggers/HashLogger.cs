using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemExtended.Loggers
{
    internal class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            this._name = name;
            this._logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            // This logger does not support scopes, so we return null.
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // This logger is enabled for all log levels.
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            switch(logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"{logLevel}");
            messageToBeLogged.AppendFormat(" [{0}]", _name);

            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;
        }

        public void PrintAllLogs()
        {
            foreach (var log in _logMessages)
            {
                Console.WriteLine($"EventId: {log.Key} -> Message: {log.Value}");
            }
        }

        public void PrintLogById(int eventId)
        {
            if (!_logMessages.TryGetValue(eventId, out string? message))
            {
                Console.WriteLine("No such event as EventId");
            }
            else
            {
                Console.WriteLine($"EventId: {eventId} -> Message: {message}");
            }
        }

        public void DeleteLogById(int eventId)
        {
            if (_logMessages.TryRemove(eventId, out _))
            {
                Console.WriteLine($"Log с EventId {eventId} беше изтрит.");
            }
            else
            {
                Console.WriteLine("Няма такъв Log.");
            }
        }
    }
}
