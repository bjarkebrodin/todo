using System;
using System.Text;
using System.Collections.Generic;
using Shared;
using static System.Console;

namespace App
{
    public class Program
    {
        static ITodoRepository _repo;

        public static void Main(string[] args)
        {
            _repo = Startup.Configure();
            switch(args[0])
            {
                case "list" : 
                    List(); 
                    break;
                case "complete" : 
                    Complete(args[1..]); 
                    break;
                default : 
                    Add(args); 
                    break;
            }
            _repo.Dispose();
        }

        static async void Add(string[] args)
        {
            await _repo.Add(args[0]);
            Write($"Added '{args[0]}' to todo list");
        }

        static async void List() 
        {
            var Out = new StringBuilder();
            Out.Append("Todos : \n");

            foreach (var todo in (await _repo.Read()))
            {
                Out.Append(todo).Append("\n");
            }

            Write(Out.ToString());
        }
        
        static async void Complete(string[] args)
        {
            await _repo.Remove(args[0]);
            Write($"Completed todo '{args[0]}'");
        }
    }
}
