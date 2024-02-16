using aspnetserver.Data;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:5173", "https://appname.azurestaticapps.net");
        //WithOrigins te baglanacagým frontend url adresini ve diger url adreslerini yazdým.
    }
    );
    //frontende baglanabilmek icin CORS oluþturdum
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API TEST", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
    {
        swaggerUIOptions.DocumentTitle = "Asp.Net React Test Project";
        swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "My API TEST V1");
        swaggerUIOptions.RoutePrefix = string.Empty;
    });

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");//frontende baglanabilmek icin gerekli


app.MapGet("/get-all-post", async () => await PostRepository.GetPostsAsync()).WithTags("Posts Endpoints");


app.MapGet("/get-post/{id}", async (int id) =>
{
    Post postToRet = await PostRepository.GetPostByIdAsync(id);
    if (postToRet != null)
    {
        return Results.Ok();
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");


app.MapPost("/create-post", async (Post post) =>
{
    bool olusturmaBasarili = await PostRepository.CreatePostAsync(post);
    if (olusturmaBasarili)
    {
        return Results.Ok("Olusturuldu");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");


app.MapPut("/update-post", async (Post postGuncelle) =>
{
    bool guncelHal = await PostRepository.UpdatePostAsync(postGuncelle);
    if (guncelHal)
    {
        return Results.Ok("Basariyla Guncellendi");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");


app.MapDelete("/delete-post/{id}", async (int id) =>
{
    bool postSil = await PostRepository.SilPostAsync(id);
    if (postSil)
    {
        return Results.Ok("Basariyla Silindi");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.Run();
