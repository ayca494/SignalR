#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SignalR_Web/SignalR_Web.csproj", "SignalR_Web/"]
RUN dotnet restore "SignalR_Web/SignalR_Web.csproj"
COPY . .
WORKDIR "/src/SignalR_Web"
RUN dotnet build "SignalR_Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignalR_Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignalR_Web.dll"]