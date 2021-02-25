#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["FansWasm/Server/FansWasm.Server.csproj", "FansWasm/Server/"]
COPY ["FansWasm/Client/FansWasm.Client.csproj", "FansWasm/Client/"]
COPY ["FansWasm/Shared/FansWasm.Shared.csproj", "FansWasm/Shared/"]
RUN dotnet restore "FansWasm/Server/FansWasm.Server.csproj"
COPY . .
WORKDIR "/src/FansWasm/Server"
RUN dotnet build "FansWasm.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FansWasm.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FansWasm.Server.dll"]