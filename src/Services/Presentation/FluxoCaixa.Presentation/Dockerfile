FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8081
ENV ASPNETCORE_ENVIRONMENT=Development

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Services/Presentation/FluxoCaixa.Presentation/FluxoCaixa.WebApi.csproj", "src/Services/Presentation/FluxoCaixa.Presentation/"]
RUN dotnet restore "src/Services/Presentation/FluxoCaixa.Presentation/FluxoCaixa.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Services/Presentation/FluxoCaixa.Presentation"
RUN dotnet build "FluxoCaixa.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "FluxoCaixa.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluxoCaixa.WebApi.dll"]
