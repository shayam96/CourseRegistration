using CourseRegistration.Model;
using CourseRegistration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var course = new Course
{
    CourseId = 1,
    CourseName = "C# Programming",
    Capacity = 3
};

var students = new List<Student>
{
    new Student { StudentId = 1, StudentName = "A", HasCompletedPrerequisite = true },
    new Student { StudentId = 2, StudentName = "B", HasCompletedPrerequisite = true },
    new Student { StudentId = 3, StudentName = "C", HasCompletedPrerequisite = true },
    new Student { StudentId = 4, StudentName = "D", HasCompletedPrerequisite = true },
    new Student { StudentId = 5, StudentName = "E", HasCompletedPrerequisite = false }
};

builder.Services.AddSingleton(
    new EnrollmentService(course, students));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
