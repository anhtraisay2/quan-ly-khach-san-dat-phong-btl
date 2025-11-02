using Microsoft.OpenApi.Models;
// using CoreApi.DAL;
// using Microsoft.EntityFrameworkCore;
// using BLL;
using CoreApi.BLL;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Kết nối database
// Đã loại bỏ hoàn toàn Entity Framework và DbContext
var connectionString = builder.Configuration.GetConnectionString("HotelDb");

// 🔹 Đăng ký tất cả các lớp BLL (Dependency Injection)
builder.Services.AddScoped<NguoiDungBLL_Ado>(sp => new NguoiDungBLL_Ado(connectionString));
builder.Services.AddScoped<PhongBLL_Ado>(sp => new PhongBLL_Ado(connectionString));
builder.Services.AddScoped<DatPhongBLL_Ado>(sp => new DatPhongBLL_Ado(connectionString));
builder.Services.AddScoped<DichVuBLL_Ado>(sp => new DichVuBLL_Ado(connectionString));
builder.Services.AddScoped<HoaDonBLL_Ado>(sp => new HoaDonBLL_Ado(connectionString));
builder.Services.AddScoped<HoaDonChiTietBLL_Ado>(sp => new HoaDonChiTietBLL_Ado(connectionString));
builder.Services.AddScoped<LoaiPhongBLL_Ado>(sp => new LoaiPhongBLL_Ado(connectionString));
builder.Services.AddScoped<GiaBLL_Ado>(sp => new GiaBLL_Ado(connectionString));
builder.Services.AddScoped<KhachBLL_Ado>(sp => new KhachBLL_Ado(connectionString));

// 🔹 Cấu hình Controller + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hotel Management API",
        Version = "v1"
    });
});

var app = builder.Build();

// 🔹 Cấu hình chạy ứng dụng
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hotel API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
