using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IPostDal, EfPostDal>();
builder.Services.AddSingleton<IPostService, PostManager>();
builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();
builder.Services.AddSingleton<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICommentDal, EfCommentDal>();
builder.Services.AddSingleton<ICommentService, CommentManager>();

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
