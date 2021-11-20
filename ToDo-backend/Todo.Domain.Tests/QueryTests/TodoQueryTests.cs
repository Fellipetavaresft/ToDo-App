using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "Usuario A", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "Usuario B", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "Fellipe Tavares", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "Usuario D", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "Usuario D", DateTime.Now));
        }

        [TestMethod]
        public void Deve_retornar_dados_do_fellipe()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("Fellipe Tavares"));
            Assert.AreEqual(1,result.count());
;        }
    }
}