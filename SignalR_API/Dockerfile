#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SignalR_API/SignalR_API.csproj", "SignalR_API/"]
RUN dotnet restore "SignalR_API/SignalR_API.csproj"
COPY . .
WORKDIR "/src/SignalR_API"
RUN dotnet build "SignalR_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalR_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalR_API.dll"]