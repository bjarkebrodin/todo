using System;
using App;
using Xunit;
using System.IO;

namespace App.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void MainGivenList_ListsTodos()
        {
            using var Out = new StringWriter();
            Console.SetOut(Out);
        }  
    }
}