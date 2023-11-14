using Songs.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);
var identityUrl = builder.Configuration.GetValue<string>("IdentityUrl");
var callBackUrl = builder.Configuration.GetValue<string>("CallBackUrl");
var sessionCookieLifetime = builder.Configuration.GetValue("SessionCookieLifetimeMinutes", 60);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<SongContext>(
                  dbContextOptions => dbContextOptions
                    .UseMySql(
                      builder.Configuration["ConnectionStrings:DefaultConnection"], 
                      ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                    )
                  )
                );

builder.Services.AddOpenIddict()
    .AddServer(
    _ =>
    {
        //enable client_credentials grant_tupe support on server level
        _.AllowClientCredentialsFlow();
        //specify token endpoint uri
        _.SetTokenEndpointUris("token");
        //secret registration
        _.AddDevelopmentEncryptionCertificate()
         .AddDevelopmentSigningCertificate();
        _.DisableAccessTokenEncryption();
        //the asp request handlers configuration itself
        _.UseAspNetCore().EnableTokenEndpointPassthrough();
    }
    );

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddCookie(options =>
    {
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    })
.AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
.AddOpenIdConnect(options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = identityUrl.ToString();
    options.SignedOutRedirectUri = callBackUrl.ToString();
    options.ClientId = "mvc";
    options.ClientSecret = "secret";
    options.ResponseType = "code id_token";
    options.SaveTokens = true;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.RequireHttpsMetadata = false;
    /* 
    ===placeholders===
    */
    options.Scope.Add("openid"); 
    options.Scope.Add("profile");
    options.Scope.Add("orders");
    options.Scope.Add("SongsForGood");
    options.Scope.Add("orders.signalrhub");
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


    app.UseSwagger();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseSwaggerUI();
    app.UseHttpsRedirection();


app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.UseEndpoints(endpoints => 
{
  endpoints.MapRazorPages();
});
app.Run();
