using SistemaEducacion.Models;
using SistemaEducacion.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
string AzureKey = config["settings:azureKey"]!.ToString();
string StorageAccount = config["settings:StorageAccount"]!.ToString();

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
//Singleton
builder.Services.AddSingleton<IUserModel, UserModel>();
builder.Services.AddSingleton<ICourse, CourseModel>();
builder.Services.AddSingleton<ILesson, LessonModel>();
builder.Services.AddSingleton<ISuscription, SuscriptionModel>();
builder.Services.AddSingleton<IUtilitariosModel, UtilitariosModel>();
builder.Services.AddSingleton<IVideoModel, VideoModel>();
builder.Services.AddSingleton<IFileModel, FileModel>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
