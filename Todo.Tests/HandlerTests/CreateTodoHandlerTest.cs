using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Tests.Repositories;

namespace Todo.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da tarefa", "Usuário da tarefa", DateTime.Now);
        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
        //Usar MOQ ou Fake Repository
        [TestMethod]
        public void TodoHandlerFail()
        {
            _invalidCommand.Validate();
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success,false);
        }

        [TestMethod]
        public void TodoHandlerSuccess()
        {
            _validCommand.Validate();
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }
    }
}
