#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Project.WebApi/Project.WebApi.csproj", "Project.WebApi/"]
COPY ["Project.Domain/Project.Domain.csproj", "Project.Domain/"]
COPY ["Project.Application/Project.Application.csproj", "Project.Application/"]
COPY ["Project.Infrastructure/Project.Infrastructure.csproj", "Infrastructure.WebApi/"]
RUN dotnet restore "./Project.WebApi/Project.WebApi.csproj"
COPY . .
WORKDIR "/src/Project.WebApi"
RUN dotnet build "./Project.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM buildbase as migrations
RUN dotnet tool install --version 8.0.2 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
#ENTRYPOINT dotnet ef database update -s src/SlaveOneBack.WebAPI
ENTRYPOINT dotnet-ef database update --project src/Project.Infrastructure/ --startup-project src/Project.WebApi

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Project.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project.WebApi.dll"]