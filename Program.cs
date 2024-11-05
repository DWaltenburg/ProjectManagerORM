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

seedWorkers();

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

void seedWorkers()
{
    var team = new Team { Name = "Frontend" };
    var team2 = new Team { Name = "Backend" };
    var team3 = new Team { Name = "Testere" };

    db.Teams.Add(team);
    db.Teams.Add(team2);
    db.Teams.Add(team3);
    db.SaveChanges();

    //we dont do loops in this household >:(
    var worker = new Worker { Name = "Steen Secher" };
    var worker2 = new Worker { Name = "Ejvind Møller" };
    var worker3 = new Worker { Name = "Konrad Sommer" };
    var worker4 = new Worker { Name = "Sofus Lotus" };
    var worker5 = new Worker { Name = "Remo Lademann" };
    var worker6 = new Worker { Name = "Ella Fanth" };
    var worker7 = new Worker { Name = "Anne Dam" };

    db.Workers.Add(worker);
    db.Workers.Add(worker2);
    db.Workers.Add(worker3);
    db.Workers.Add(worker4);
    db.Workers.Add(worker5);
    db.Workers.Add(worker6);
    db.Workers.Add(worker7);

    db.SaveChanges();

    var teamWorker = new TeamWorker { TeamId = team.TeamId, WorkerId = worker.WorkerId };
    var teamWorker2 = new TeamWorker { TeamId = team.TeamId, WorkerId = worker2.WorkerId };
    var teamWorker3 = new TeamWorker { TeamId = team.TeamId, WorkerId = worker3.WorkerId };

    var teamWorker4 = new TeamWorker { TeamId = team2.TeamId, WorkerId = worker4.WorkerId };
    var teamWorker5 = new TeamWorker { TeamId = team2.TeamId, WorkerId = worker5.WorkerId };
    var teamWorker6 = new TeamWorker { TeamId = team2.TeamId, WorkerId = worker3.WorkerId };

    var teamWorker7 = new TeamWorker { TeamId = team3.TeamId, WorkerId = worker6.WorkerId };
    var teamWorker8 = new TeamWorker { TeamId = team3.TeamId, WorkerId = worker7.WorkerId };
    var teamWorker9 = new TeamWorker { TeamId = team3.TeamId, WorkerId = worker.WorkerId };

    db.TeamWorkers.Add(teamWorker);
    db.TeamWorkers.Add(teamWorker2);
    db.TeamWorkers.Add(teamWorker3);

    db.TeamWorkers.Add(teamWorker4);
    db.TeamWorkers.Add(teamWorker5);
    db.TeamWorkers.Add(teamWorker6);

    db.TeamWorkers.Add(teamWorker7);
    db.TeamWorkers.Add(teamWorker8);
    db.TeamWorkers.Add(teamWorker9);

    db.SaveChanges();
}