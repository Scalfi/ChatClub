FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5029

ENV ASPNETCORE_URLS=http://+:5029

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChatClub.Web.csproj", "./"]
RUN dotnet restore "ChatClub.Web.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ChatClub.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatClub.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatClub.Web.dll"]
