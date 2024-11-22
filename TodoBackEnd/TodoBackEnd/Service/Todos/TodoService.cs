using System.Collections.Generic;
using TodoBackEnd.Data;
using TodoBackEnd.Model;

namespace TodoBackEnd.Service.Todos
{
    public class TodosService : ITodosService
    {
        private readonly TodoDbContext _todoDbContext;

        public TodosService(TodoDbContext todoDbContext)
        {
            this._todoDbContext = todoDbContext;
        }

        public List<Todo> GetTodos()
        {
            return _todoDbContext.todos.OrderByDescending(x => x.Id).ToList();
        }

        public bool AddTodo(Todo todo)
        {     

            _todoDbContext.todos.Add(todo);
            // Lưu thay đổi vào cơ sở dữ liệu
            _todoDbContext.SaveChanges();
            return true;
        }

        public bool UpdateTodo(Todo todo)
        {
            _todoDbContext.todos.Update(todo);
            _todoDbContext.SaveChanges();
            return true;
        }

        public bool DeleteTodo(int id)
        {
            // Tìm mục Todo với id
            Todo todo = _todoDbContext.todos.Find(id);

            if (todo == null)
            {
                // Không tìm thấy Todo với id đã cho
                return false;
            }

            // Xóa mục Todo
            _todoDbContext.todos.Remove(todo);

            // Lưu thay đổi vào cơ sở dữ liệu
            _todoDbContext.SaveChanges();

            return true;
        }

    }
}
