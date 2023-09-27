#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StoreServices.Api.Gateway/StoreServices.API.Gateway.csproj", "StoreServices.Api.Gateway/"]
RUN dotnet restore "StoreServices.Api.Gateway/StoreServices.API.Gateway.csproj"
COPY . .
WORKDIR "/src/StoreServices.Api.Gateway"
RUN dotnet build "StoreServices.API.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreServices.API.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreServices.API.Gateway.dll"]