using PolicyHistory_API_using_Dapper.Context;
using PolicyHistory_API_using_Dapper.Repository;
using PolicyHistory_API_using_Dapper.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddCors(option =>
{

    option.AddPolicy(name: "mypolicy", option =>
    {
        option.WithOrigins("https://localhost:7280").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddTransient<DapperContext>();


builder.Services.AddTransient<IEnterpriseManagerFB_Interface, EnterpriseManagerFB_Repository>();
builder.Services.AddControllers();

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

app.UseCors("mypolicy");
app.Run();
