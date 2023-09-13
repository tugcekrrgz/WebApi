var builder = WebApplication.CreateBuilder(args);

//Service
builder.Services.AddControllers();//UI'dan ba��ms�z. API dahil ediyoruz.



var app = builder.Build();




//Application(Pipeline)
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});


app.Run();
