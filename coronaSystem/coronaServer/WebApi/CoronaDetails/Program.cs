using DAL;
using BLL;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(ICoronaVaccineDAL), typeof(CoronaVaccineDAL));
builder.Services.AddScoped(typeof(ICoronaVaccineBLL),typeof(CoronaVaccineBLL));
builder.Services.AddScoped(typeof(IPatientDAL),typeof(PatientDAL));
builder.Services.AddScoped(typeof(IPatientBLL), typeof(PatientBLL));
builder.Services.AddScoped(typeof(IVaccinesForPatientsDAL), typeof(VaccinesForPatientsDAL));
builder.Services.AddScoped(typeof(IVaccinesForPatientsBLL), typeof(VaccinesForPatientSBLL));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("policy");

app.MapControllers();

app.Run();
