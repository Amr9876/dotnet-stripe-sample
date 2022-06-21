using Stripe;
using Stripe.Checkout;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<SessionService>();

var app = builder.Build();

StripeConfiguration.ApiKey = builder.Configuration["StripeApiKey"];

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapFallbackToFile("index.html");
app.MapFallbackToFile("/success", "success.html");
app.MapFallbackToFile("/cancel", "cancel.html");
app.MapControllers();

app.Run();
