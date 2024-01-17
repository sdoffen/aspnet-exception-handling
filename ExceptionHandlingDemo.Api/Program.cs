using ExceptionHandlingDemo.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

/*
UseStatusCodePages
- Turn on regardless of environment
- Produces status code pages for HTTP errors

When UseStatusCodePages isn't used, navigating to a URL without an endpoint
returns a browser-dependent error message indicating the endpoint can't be found.

When UseStatusCodePages is called, the browser returns the following response:
    Status Code: 404; Not Found
*/
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    // This is for global exception handling
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // This is for global exception handling
    app.UseExceptionHandler("/error");
    app.MapGet("/error", () => "Sorry, an error occurred");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
