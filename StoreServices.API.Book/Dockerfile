#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["StoreServices.API.Book/StoreServices.API.Book.csproj", "StoreServices.API.Book/"]
RUN dotnet restore "StoreServices.API.Book/StoreServices.API.Book.csproj"
COPY . .
WORKDIR "/src/StoreServices.API.Book"
RUN dotnet build "StoreServices.API.Book.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreServices.API.Book.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreServices.API.Book.dll"]