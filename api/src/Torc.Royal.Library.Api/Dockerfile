#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Torc.Royal.Library.Api/Torc.Royal.Library.Api.csproj", "src/Torc.Royal.Library.Api/"]
RUN dotnet restore "src/Torc.Royal.Library.Api/Torc.Royal.Library.Api.csproj"
COPY . .
WORKDIR "/src/src/Torc.Royal.Library.Api"
RUN dotnet build "Torc.Royal.Library.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Torc.Royal.Library.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Torc.Royal.Library.Api.dll"]