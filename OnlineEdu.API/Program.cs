using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrete;
using OnlineEdu.Business.Configurations;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Concrete;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>),typeof(GenericManager<>));
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
builder.Services.AddScoped<ICourseCategoryService, CourseCategoryManager>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICourseService, CourseManager>();
builder.Services.AddScoped<ICourseRegisterRepository, CourseRegisterRepository>();
builder.Services.AddScoped<ICourseRegisterService, CourseRegisterManager>();
builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
builder.Services.AddScoped<IBlogCategoryService, BlogCategoryManager>();
var configuration = builder.Configuration;
builder.Services.Configure<JwtTokenOptions>(configuration.GetSection("TokenOptions"));

// Add services to the container.
builder.Services.AddDbContext<OnlineEduContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    options.UseLazyLoadingProxies();
});
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
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
