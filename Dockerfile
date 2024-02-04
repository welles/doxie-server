FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
WORKDIR /src
COPY . .
WORKDIR /src/DoxieServer.Api
RUN dotnet restore "DoxieServer.Api.csproj"

FROM restore AS build
RUN dotnet build "DoxieServer.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoxieServer.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoxieServer.Api.dll"]
