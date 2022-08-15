#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ChatClub.Web/ChatClub.Web.csproj", "src/ChatClub.Web/"]
COPY ["src/ChatClub.Application/ChatClub.Application.csproj", "src/ChatClub.Application/"]
COPY ["src/ChatClub.Domain/ChatClub.Domain.csproj", "src/ChatClub.Domain/"]
COPY ["src/ChatClub.Infrastructure/ChatClub.Infrastructure.csproj", "src/ChatClub.Infrastructure/"]
RUN dotnet restore "src/ChatClub.Web/ChatClub.Web.csproj"
COPY . .
WORKDIR "/src/src/ChatClub.Web"
RUN dotnet build "ChatClub.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatClub.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatClub.Web.dll"]