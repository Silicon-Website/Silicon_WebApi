using Infrastructure.Contexts;
using Infrastructure.GraphQL;
using Infrastructure.GraphQL.Mutations;
using Infrastructure.GraphQL.ObjectTypes;
using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        services.AddGraphQL()
                .AddQueryType<Query>()
                .AddMutationType<CourseMutation>()
                .AddType<CourseType>();

        services.AddScoped<ICourseService, CourseService>();
    })
    .Build();



builder.Services.AddDbContext<ApiContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));





var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
