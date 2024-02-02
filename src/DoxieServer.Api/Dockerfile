FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/DoxieServer.Api/DoxieServer.Api.csproj", "src/DoxieServer.Api/"]
RUN dotnet restore "src/DoxieServer.Api/DoxieServer.Api.csproj"
COPY . .
WORKDIR "/src/src/DoxieServer.Api"
RUN dotnet build "DoxieServer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DoxieServer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoxieServer.Api.dll"]
