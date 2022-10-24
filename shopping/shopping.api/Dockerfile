#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["shopping.api/shopping.api.csproj", "shopping.api/"]
RUN dotnet restore "shopping.api/shopping.api.csproj"
COPY . .
WORKDIR "/src/shopping.api"
RUN dotnet build "shopping.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "shopping.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "shopping.api.dll"]