using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Tests.QueriesTests
{
    [TestClass]
    public class TodoQueryTest
    {   
        private List<TodoItem> _items;
        public TodoQueryTest()
        {
            _items = new List<TodoItem>();

            _items.Add(new TodoItem("Tarefa 1",DateTime.Now,"teste@teste.com"));
            _items.Add(new TodoItem("Tarefa 2",DateTime.Now,"teste@teste.com"));
            _items.Add(new TodoItem("Tarefa 3",DateTime.Now.AddDays(1),"teste2@teste.com"));
            _items.Add(new TodoItem("Tarefa 4",DateTime.Now.AddDays(1),"teste2@teste.com"));
        }

        [TestMethod]
        public void GetAll()
        {   
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("teste@teste.com"));
            Assert.AreEqual(2,result.Count());

            result = _items.AsQueryable().Where(TodoQueries.GetAll("teste2@teste.com"));
            Assert.AreEqual(2,result.Count());
        }

        [TestMethod]
        public void GetAllDone()
        {   
            _items[0].MarkAsDone();
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("teste@teste.com"));
            Assert.AreEqual(1,result.Count());
        }

        [TestMethod]
        public void GetAllUndone()
        {
            _items[0].MarkAsDone();

            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("teste@teste.com"));
            Assert.AreEqual(1,result.Count());
        }

        [TestMethod]
        public void GetAllByDate()
        {
            _items[0].MarkAsDone();
            
            var result = _items.AsQueryable().Where(TodoQueries.GetAllByPeriod("teste@teste.com",true,DateTime.Now));
            Assert.AreEqual(1,result.Count());

            result = _items.AsQueryable().Where(TodoQueries.GetAllByPeriod("teste@teste.com",false,DateTime.Now));
            Assert.AreEqual(1,result.Count());
        }
    }
}
