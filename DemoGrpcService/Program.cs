using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DemoGrpcService.Interface;
using DemoGrpcService.Models;
using DemoGrpcService.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
var configs = KeyVaultConfigsService.GetConfigs(builder.Configuration);
    if (!string.IsNullOrWhiteSpace(configs.keyVaultUri))
    {
        var credential = new ClientSecretCredential(configs.tenantId, configs.clientId, configs.clientSecret);
        var client = new SecretClient(new Uri(configs.keyVaultUri), credential);
        builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());

        builder.Services.Configure<DemoDatabaseSettings>(
        builder.Configuration.GetSection(nameof(DemoDatabaseSettings)));

        builder.Services.AddSingleton<IDemoDatabaseSettings>(provider =>
        provider.GetRequiredService<IOptions<DemoDatabaseSettings>>().Value);
        builder.Services.AddControllers();
    }

var app = builder.Build();
app.MapGrpcService<EmployeeDetailService>();
app.Run();
