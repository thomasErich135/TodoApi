using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Tests.CommandTests
{
     [TestClass]
    public class MarkTodoAsUndoneCommandTests
    {
        private readonly MarkTodoAsUndoneCommand _invalidCommand = new MarkTodoAsUndoneCommand(Guid.Empty,"");
        private readonly MarkTodoAsUndoneCommand _validCommand = new MarkTodoAsUndoneCommand(Guid.NewGuid(),"Usuário Fake");

        [TestMethod]
        public void CommandInvalid()
        {
            _invalidCommand.Validate();
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void CommandValid()
        {
            _validCommand.Validate();
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }   
}
