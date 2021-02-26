# Api-MediatR
Projeto em asp.net core c# para uma arquitetura de API usando o conceito de CRQS com MediatR (Command, Handlers).

Este projeto utilize o Docker e Docker-Compose para criar o container de uma API C#.

## Dependências

Abaixo as depedências do Nuget para os projetos (Core, Data, WebApi e UnitTests)

```xml

  <!--Core-->
  <ItemGroup>
    <PackageReference Include="MediatR" Version="9.0.0" />
    <PackageReference Include="FluentValidation" Version="9.5.1" />
  </ItemGroup>

  <!--Data-->
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.12" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="3.1.12" />
  </ItemGroup>

  <!--WebApi-->
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Authentication" Version="2.2.0" />
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="3.1.12" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.12" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="3.1.12" />
    <PackageReference Include="MediatR" Version="9.0.0" />
    <PackageReference Include="MediatR.Extensions.Microsoft.DependencyInjection" Version="9.0.0" />
    <PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.10.9" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.0.7" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.0.0" />
  </ItemGroup>

  <!--UnitTest-->
  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.7.1" />
    <PackageReference Include="xunit" Version="2.4.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.3">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="coverlet.collector" Version="1.3.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference> 
    <PackageReference Include="Moq" Version="4.16.1" />
    <PackageReference Include="Moq.AutoMock" Version="2.3.0" />
    <PackageReference Include="MediatR" Version="9.0.0" />
    <PackageReference Include="FluentAssertions" Version="5.10.3" />
  </ItemGroup>

```

## Setup do pipeline da WebApi (Configure e ConfigureSerivces)

Vamos adicionar o Cors, as dependências, Swagger, Jwt e opções de serialização do JSON

```c#
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();

        services.AddDependencies(Configuration);
        services.AddSwaggerDoc();
        services.AddJwt(Configuration);

        services.AddControllersWithViews()
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseGlobalExceptions();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Sample Api");
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
```

## Pasta SETUP

Na pasta setup iremos configurar as seguintes extensões para o IServiceCollection, IApplicationBuilder.

### Tratamento Global de Exceptions

```c#
  public static void UseGlobalExceptions(this IApplicationBuilder app)
  {
      app.UseExceptionHandler(builder =>
      {
          builder.Run(async ctx =>
          {
              var errorApp = ctx.Features.Get<IExceptionHandlerFeature>();
              var ex = errorApp.Error;

              ctx.Response.StatusCode = (int)ex.GetStatusCode();
              ctx.Response.ContentType = "application/json";

              var success = false;
              var message = ex.Message;
              var messageType = ex.GetMessageType();

              var strJson = $@"{{ ""sucess"": {success}, ""message"": ""{message}"", ""message_type"": ""{messageType}"" }}";
              await ctx.Response.WriteAsync(strJson);
          });
      }); 
  }
```

### Autenticação/Autorização por JWT

```c#
    public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration.GetSection("Jwt").GetValue<string>("SecretKey"));
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
``` 

### Documentação da API usando Swagger

```c#
    public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Sample Api", Version = "v1" });

            var definition = new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor, insira no campo a palavra 'Bearer', seguida por espaço e JWT",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            };
            c.AddSecurityDefinition("Bearer", definition);
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                  },
                  new List<string>()
                }
            });
        });

        return services;
    }
``` 

### Configuração do Container de Injeção de Dependências

Usaremos o MediatR, Context do Entity e as nossas classes de (Repositories, Services, Handlers, Queries ...)

```c#
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        AddQueries(services);
        AddRepositories(services);
        AddHandlers(services);

        services.AddMediatR(typeof(Startup));

        services.AddDbContext<ApiSampleContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    private static void AddQueries(IServiceCollection services)
    {
        services.AddScoped<IClienteQuery, ClienteQuery>();
    }

    private static void AddRepositories(IServiceCollection services)
    { 
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IVendaRepository, VendaRepository>();
    }

    private static void AddHandlers(IServiceCollection services)
    {
        services.AddScoped<IRequestHandler<CriarClienteCommand, bool>, ClienteCommandHandler>();
        services.AddScoped<IRequestHandler<AlterarClienteCommand, bool>, ClienteCommandHandler>();
        services.AddScoped<IRequestHandler<ExcluirClienteCommand, bool>, ClienteCommandHandler>();

        services.AddScoped<IRequestHandler<CriarVendaCommand, VendaCommandResult>, VendaCommandHandler>();
    }
}
```


