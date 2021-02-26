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
