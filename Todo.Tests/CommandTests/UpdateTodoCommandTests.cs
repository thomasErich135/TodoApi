using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Tests.CommandTests
{
    [TestClass]
    public class UpdateTodoCommandTests
    {
         private readonly UpdateTodoCommand _invalidCommand = new UpdateTodoCommand(Guid.Empty,"","");
        private readonly UpdateTodoCommand _validCommand = new UpdateTodoCommand(Guid.NewGuid(),"Tarefa fake","Usuário Fake");

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
