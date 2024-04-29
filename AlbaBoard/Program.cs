using AlbaBoard.Data;
using AlbaBoard.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Buildando o Banco de Dados com o Contexto - BancoContext
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>
    (o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
//Sempre que o IClienteRepositorio for chamado ele vai chamar o ClienteRepositorio que tem todos os metodos necessarios.
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
