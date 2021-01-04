using System;
using Shared;
using FilePersistence;

namespace App
{
    public abstract class Startup
    {
        static private readonly string HOME = Environment.GetEnvironmentVariable("HOME");
        static private readonly string DATA_FILE = $"{HOME}\\.todo";

        public static ITodoRepository Configure()
        {
            return new FileTodoRepository(DATA_FILE);
        }
    }
}