using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace ToDoList
{
    class ToDoItem
    {
        public class TodoItem
        {
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string Name { get; set; }
            public string Text { get; set; }
            public TodoItem()
            {
            }
            public override string ToString()
            {
                return "ID" + ID + " Name " + Name + " Text " + Text;
            }
        }
    }
}
