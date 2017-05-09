using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DAL
{
    internal class ContextWrapper : IDisposable
    {
        public ToDoListDBEntities Context { get; private set; }

        public ContextWrapper()
        {
            Context = new ToDoListDBEntities();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
