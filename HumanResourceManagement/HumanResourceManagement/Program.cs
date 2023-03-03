using Microsoft.EntityFrameworkCore;
using HumanResourceManagement;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeDb>(opt => opt.UseInMemoryDatabase("employee"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/employee/search/{Name}", async (string name, EmployeeDb db) =>
{
    var employee = await db.Employees
        .Where(e => e.Name!.Contains(name))
        .ToListAsync();

    if (employee is null || employee.Count == 0) return Results.NotFound();

    return Results.Ok(employee);
});

app.MapGet("/employee", async(EmployeeDb db) => await db.Employees.ToListAsync());

app.MapGet("/employee/complete", async (EmployeeDb db) => await db.Employees.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/employee/{id}", async (int id, EmployeeDb db) => await db.Employees.FindAsync(id)
is Employee employee
? Results.Ok(employee )
: Results.NotFound());
app.MapPost("/employee", async (Employee employee, EmployeeDb db) =>
{
    db.Employees.Add(employee);
    await db.SaveChangesAsync();

    return Results.Created($"/employee/{employee.Id}", employee);
});
app.MapPut("/employee/{id}", async (int id, Employee inputemployee, EmployeeDb db) =>
{
    var employee = await db.Employees.FindAsync(id);
    if (employee is null) return Results.NotFound();

    employee.Name = inputemployee.Name;
    employee.IsComplete = inputemployee.IsComplete;

    await db.SaveChangesAsync();

    return Results.NoContent();
});
app.MapDelete("/employee/{id}", async (int id, EmployeeDb db) =>
{
    if (await db.Employees.FindAsync(id) is Employee employee)
    {
        db.Employees.Remove(employee);
        await db.SaveChangesAsync();
        return Results.Ok(employee);
    }
    return Results.NotFound();
});


app.Run();
