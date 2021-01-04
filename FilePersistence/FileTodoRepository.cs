using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared;

namespace FilePersistence
{
    public class FileTodoRepository : ITodoRepository, IDisposable
    {
        private List<string> _todos;
        private string _file;

        public FileTodoRepository(string filePath)
        {
            _file = filePath;

            if (!File.Exists(filePath))
            {
                using var file = File.Create(filePath);
            }

            using StreamReader reader = File.OpenText(filePath);

            _todos = new List<string>();

            string line;
            while( (line = reader.ReadLine()) != null )
            {
                _todos.Add(line.Trim());
            }
        }

        public async Task Add(string todo)
        {
            _todos.Add(todo);
        }

        public async Task<IEnumerable<string>> Read()
        {
            return _todos;
        }

        public async Task Remove(string todo)
        {
            _todos.Remove(todo);
        }

        public void Dispose() 
        {
            File.Delete(_file);
            using StreamWriter writer = File.CreateText(_file);
            foreach (var todo in _todos)
            {
                writer.WriteLine(todo);
            }
        }
    }
}
