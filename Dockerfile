#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["weatherForecast.Api/WeatherForecast.Api.csproj", "weatherForecast.Api/"]
COPY ["weatherForecast.Application/WeatherForecast.Application.csproj", "weatherForecast.Application/"]
COPY ["weatherForecast.Domain/WeatherForecast.Domain.csproj", "weatherForecast.Domain/"]
COPY ["weatherForecast.Infrastructure/WeatherForecast.Infrastructure.csproj", "weatherForecast.Infrastructure/"]
RUN dotnet restore "./weatherForecast.Api/./WeatherForecast.Api.csproj"
COPY . .
WORKDIR "/src/weatherForecast.Api"
RUN dotnet build "./WeatherForecast.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./WeatherForecast.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherForecast.Api.dll"]

#
#FROM mcr.microsoft.com/dotnet/aspnet:8.0-buster-slim AS base
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0-buster-slim AS build
#WORKDIR /src
#COPY ["CF.Api/CF.Api.csproj", "CF.Api/"]
#RUN dotnet restore "CF.Api/CF.Api.csproj"
#COPY . .
#WORKDIR "/src/CF.Api"
#RUN dotnet build "CF.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "CF.Api.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "CF.Api.dll"]
#
#RUN chmod +x ./entrypoint.sh
#CMD /bin/bash ./entrypoint.sh