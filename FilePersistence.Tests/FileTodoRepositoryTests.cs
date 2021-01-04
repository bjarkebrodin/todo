using System;
using Xunit;
using FilePersistence;
using System.IO;
using System.Linq;

namespace FilePersistence.Tests
{
    public class FileTodoRepositoryTests
    {
        static readonly string HOME = Environment.GetEnvironmentVariable("HOME");

        [Fact]
        public void ConstructGivenNonexistingFileCreatesFile()
        {
            var file = $"{HOME}\\.todotest";
            using ( var repo = new FileTodoRepository(file) ) 
            {
                Assert.True(File.Exists(file));
            }
            File.Delete(file);
        }

        [Fact]
        public async void AddGivenValidPersistsTodo()
        {
            var file = $"{HOME}\\.todotest";
            var todo = "Write unit tests";

            using ( var repo = new FileTodoRepository(file) ) 
            {
                repo.Add(todo);
            }

            using ( var repo = new FileTodoRepository(file) ) 
            {
                var todos = (await repo.Read()).ToArray();
                Assert.True(todos.Contains(todo));
            }
            File.Delete(file);
        }

        [Fact]
        public async void RemoveGivenValidRemovesTodo()
        {
            var file = $"{HOME}\\.todotest";
            var todo = "Write unit tests";

            using ( var repo = new FileTodoRepository(file) ) 
            {
                repo.Add(todo);
            }

            using ( var repo = new FileTodoRepository(file) ) 
            {
                var todos = (await repo.Read()).ToArray();
                Assert.True(todos.Contains(todo));
                await repo.Remove(todo);
            }

            using ( var repo = new FileTodoRepository(file) ) 
            {
                var todos = (await repo.Read()).ToArray();
                Assert.False(todos.Contains(todo));
            }

            File.Delete(file);           
        }
    }
}
