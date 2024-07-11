FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8081
ENV ASPNETCORE_ENVIRONMENT=Development

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
COPY *.sln .
COPY src/Services/Presentation/FluxoCaixa.Presentation/*.csproj ./src/Services/Presentation/FluxoCaixa.Presentation/
COPY src/Services/Domain/FluxoCaixa.Domain/*csproj ./src/Services/Domain/FluxoCaixa.Domain/
COPY src/Services/Application/FluxoCaixa.Application/*.csproj ./src/Services/Application/FluxoCaixa.Application/
COPY src/Services/Infra/FluxoCaixa.Infra/*.csproj ./src/Services/Infra/FluxoCaixa.Infra/
COPY src/Core/FluxoCaixa.Core/*.csproj ./src/Core/FluxoCaixa.Core/
COPY tests/FluxoCaixa.Application.Tests/*.csproj ./tests/FluxoCaixa.Application.Tests/
COPY tests/FluxoCaixa.Domain.Tests/*.csproj ./tests/FluxoCaixa.Domain.Tests/
RUN dotnet restore

COPY . .
WORKDIR /src/Services/Presentation/FluxoCaixa.Presentation
RUN dotnet build FluxoCaixa.WebApi.csproj -c $configuration -o /app/build

FROM build AS testApplicationRunner
WORKDIR /tests/FluxoCaixa.Application.Tests
CMD ["dotnet", "test"]

FROM build AS testApplication
WORKDIR /tests/FluxoCaixa.Application.Tests
RUN dotnet test --logger:trx

FROM build AS testDomainRunner
WORKDIR /tests/FluxoCaixa.Application.Tests
CMD ["dotnet", "test"]

FROM build AS testDomain
WORKDIR /tests/FluxoCaixa.Domain.Tests
RUN dotnet test --logger:trx

FROM build AS publish
ARG configuration=Release
RUN dotnet publish FluxoCaixa.WebApi.csproj -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoCaixa.WebApi.dll"]
