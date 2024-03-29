#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Set ASPNETCORE_ENVIRONMENT to Development
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
# Copy the main project file and restore as distinct layers
COPY ["UMS.Api/UMS.Api.csproj", "UMS.Api/"]
COPY ["UMS.Core/UMS.Core.csproj", "UMS.Core/"]
COPY ["UMS.Infrastructure/UMS.Infrastructure.csproj", "UMS.Infrastructure/"]
RUN dotnet restore "UMS.Api/UMS.Api.csproj"

# Copy everything else and build
COPY UMS.Api/. UMS.Api/
COPY UMS.Core/. UMS.Core/
COPY UMS.Infrastructure/. UMS.Infrastructure/
WORKDIR "/src/UMS.Api"
RUN dotnet build "UMS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UMS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UMS.Api.dll"]