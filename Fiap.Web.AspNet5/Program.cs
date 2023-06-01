using AutoMapper;
using Fiap.Web.AspNet5.Data;
using Fiap.Web.AspNet5.Models;
using Fiap.Web.AspNet5.Repository;
using Fiap.Web.AspNet5.Repository.Interface;
using Fiap.Web.AspNet5.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

var connectionString = builder.Configuration.GetConnectionString("databaseUrl");
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging(true)
);

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IRepresentanteRepository, RepresentanteRepositoryText>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILojaRepository, LojaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();



var mapperConfig = new AutoMapper.MapperConfiguration(c =>
{
    c.AllowNullDestinationValues = true;

    c.CreateMap<LoginViewModel, UsuarioModel>();
    c.CreateMap<UsuarioModel, LoginViewModel>();

    c.CreateMap<RepresentanteViewModel,RepresentanteModel>();
    c.CreateMap<RepresentanteModel, RepresentanteViewModel>();

    c.CreateMap<ClienteViewModel, ClienteModel>();
    c.CreateMap<ClienteModel, ClienteViewModel>();

    c.CreateMap<LojaViewModel, LojaModel>();
    c.CreateMap<LojaModel, LojaViewModel>();

    c.CreateMap<ProdutoViewModel, ProdutoModel>();
    c.CreateMap<ProdutoModel, ProdutoViewModel>();

    c.CreateMap<ProdutoLojaViewModel, ProdutoLojaModel>();
    c.CreateMap<ProdutoLojaModel, ProdutoLojaViewModel>();

});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
