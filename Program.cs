using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();

seedTasks();


using (BloggingContext context = new())
{
    var tasks = context.Tasks.Include(Task => Task.Todos);
    foreach (var task in tasks)
    {
        Console.WriteLine($"Task: {task.Name}");
        foreach (var todo in task.Todos)
        {
            Console.WriteLine($"- {todo.Name}");
        }
    }
}

void seedTasks()
{
    var task = new Task { Name = "Produce software" };
    db.Tasks.Add(task);

    var todo1 = new Todo { Name = "Write code", IsComplete = false };
    db.Todos.Add(todo1);
    task.Todos.Add(todo1);

    var todo2 = new Todo { Name = "Compile source", IsComplete = false };
    db.Todos.Add(todo2);
    task.Todos.Add(todo2);

    var todo3 = new Todo { Name = "Test program", IsComplete = false };
    db.Todos.Add(todo3);
    task.Todos.Add(todo3);
    db.SaveChanges();


    var task2 = new Task { Name = "Brew coffee" };
    db.Tasks.Add(task2);

    var todo4 = new Todo { Name = "Pour water", IsComplete = false };
    db.Todos.Add(todo4);
    task2.Todos.Add(todo4);

    var todo5 = new Todo { Name = "Pour coffee", IsComplete = false };
    db.Todos.Add(todo5);
    task2.Todos.Add(todo5);

    var todo6 = new Todo { Name = "Turn on", IsComplete = false };
    db.Todos.Add(todo6);
    task2.Todos.Add(todo6);
    db.SaveChanges();
}

void printIncompleteTasksAndTodos()
{
    using (BloggingContext context = new())
    {
        var tasks = context.Tasks.Include(Task => Task.Todos).Where(Task => Task.Todos.Any(Todo => Todo.IsComplete == false));
        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos)
            {
                Console.WriteLine($"- {todo.Name}");
            }
        }
    }
}