using System;
using System.Collections.Generic;
using TodoBackEnd.Model;

namespace TodoBackEnd.Service.Todos
{
    public interface ITodosService
    {
        List<Todo> GetTodos();
        bool AddTodo(Todo todo);
        bool UpdateTodo(Todo todo);
        bool DeleteTodo(int id);
    }
}
