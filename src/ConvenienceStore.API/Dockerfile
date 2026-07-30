# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ConvenienceStore.API/ConvenienceStore.API.csproj", "src/ConvenienceStore.API/"]
COPY ["src/Core/ConvenienceStore.Application/ConvenienceStore.Application.csproj", "src/Core/ConvenienceStore.Application/"]
COPY ["src/Shared/ConvenienceStore.Contract/ConvenienceStore.Contract.csproj", "src/Shared/ConvenienceStore.Contract/"]
COPY ["src/Core/ConvenienceStore.Domain/ConvenienceStore.Domain.csproj", "src/Core/ConvenienceStore.Domain/"]
COPY ["src/External/ConvenienceStore.Infrastructure/ConvenienceStore.Infrastructure.csproj", "src/External/ConvenienceStore.Infrastructure/"]
COPY ["src/External/ConvenienceStore.Persistence/ConvenienceStore.Persistence.csproj", "src/External/ConvenienceStore.Persistence/"]
RUN dotnet restore "./src/ConvenienceStore.API/ConvenienceStore.API.csproj"
COPY . .
WORKDIR "/src/src/ConvenienceStore.API"
RUN dotnet build "./ConvenienceStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ConvenienceStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConvenienceStore.API.dll"]