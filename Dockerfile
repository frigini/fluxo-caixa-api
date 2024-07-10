FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_URLS=http://+:32033
WORKDIR /app
EXPOSE 32033

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY ["./fluxo-caixa-api.sln", "./"]
COPY ["src/Services/Presentation/FluxoCaixa.Presentation/FluxoCaixa.WebApi.csproj", "src/Services/Presentation/FluxoCaixa.Presentation/"]
COPY ["src/Services/Domain/FluxoCaixa.Domain/FluxoCaixa.Domain.csproj", "src/Services/Domain/FluxoCaixa.Domain/"]
COPY ["src/Services/Application/FluxoCaixa.Application/FluxoCaixa.Application.csproj", "src/Services/Application/FluxoCaixa.Application/"]
COPY ["src/Services/Infra/FluxoCaixa.Infra/FluxoCaixa.Infra.csproj", "src/Services/Infra/FluxoCaixa.Infra/"]
COPY ["src/Core/FluxoCaixa.Core/FluxoCaixa.Core.csproj", "src/Core/FluxoCaixa.Core/"]

#COPY ["tests/Unit/Unit.csproj", "tests/Unit/Unit.csproj"]

RUN dotnet restore fluxo-caixa-api.sln

COPY . .
WORKDIR /src/Services/Presentation/FluxoCaixa.Presentation
RUN dotnet build "FluxoCaixa.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FluxoCaixa.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

COPY ["src/", "src/"]
#COPY ["tests/", "tests/"]

# Run migrations
FROM build as migrations
WORKDIR /src/Services/Infra/FluxoCaixa.Infra
RUN dotnet tool install --version 8.0.6 --global dotnet-ef
#ENV PATH="$PATH:/root/.dotnet/tools"
ENTRYPOINT dotnet ef database update --project src/Services/Infra/FluxoCaixa.Infra/FluxoCaixa.Infra.csproj --startup-project src/Services/Presentation/FluxoCaixa.Presentation/FluxoCaixa.WebApi.csproj

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoCaixa.WebApi.dll"]