var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

var todoItems = new[] {
    new TodoItem() { Id = 1, Description = "Item 1" },
    new TodoItem() { Id = 2, Description = "Item 2" },
    new TodoItem() { Id = 3, Description = "Item 3" },
};

// Return list of To Do items
app.MapGet("/items", () => todoItems);

// Return a single To Do item
app.MapGet("/items/{id}", (int id) =>
{
    return todoItems.FirstOrDefault(x => x.Id == id);
});

app.Run();
