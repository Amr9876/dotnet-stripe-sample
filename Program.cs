using Stripe;
using Stripe.Checkout;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<SessionService>();

var app = builder.Build();

StripeConfiguration.ApiKey = "sk_test_51LCRRsCDTvafG9qIN4HsY0fR0TkwLhwOIBDUmBXmlVYEtdm7Z9vn5ea1KM7Sr5JBn7KYA0OMQxjM5TooVJ5hJHgP00GhPHYKX4";

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
