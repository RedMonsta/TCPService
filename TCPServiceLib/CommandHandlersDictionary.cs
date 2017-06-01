using System;
using System.Collections.Generic;

namespace TCPServiceLib
{
    public static class CommandHandlersDictionary
    {
        private static Dictionary<Type, ICustomCommandHandler> dictionary = new Dictionary<Type, ICustomCommandHandler>();
        private static ICustomCommandHandler DefaultHandler { get; set; }

        public static void SetDefaultHandler(ICustomCommandHandler handler)
        {
            DefaultHandler = handler;
        }

        public static void AddHandler(Type commandType, ICustomCommandHandler handler)
        {
            dictionary.Add(commandType, handler);
        }

        public static ICustomCommandHandler GetHandler(Type comType)
        {
            ICustomCommandHandler commandHandler;
            try
            {
                commandHandler = dictionary[comType];
            }
            catch (Exception)
            {
                commandHandler = DefaultHandler;
            }
            return commandHandler;
        }

    }
}
