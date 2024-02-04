FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
COPY /src /src
WORKDIR /src/DoxieServer.Api
RUN dotnet restore DoxieServer.Api.csproj

FROM restore AS build
RUN dotnet build DoxieServer.Api.csproj -c Release -o /app/build

FROM build AS publish
ARG VERSION="0.0.0-dev.0"
ARG ASSEMBLY_VERSION="0.0.0.0"
ARG FILE_VERSION="0.0.0.0"
ARG INFORMATIONAL_VERSION="0.0.0-dev.0"
RUN dotnet publish DoxieServer.Api.csproj -c Release -o /app/publish  /property:Version=$VERSION /property:AssemblyVersion=$ASSEMBLY_VERSION /property:FileVersion=$FILE_VERSION /property:InformationalVersion=$INFORMATIONAL_VERSION

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoxieServer.Api.dll"]
