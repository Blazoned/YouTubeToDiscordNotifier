FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DiscordYouTubeNotifier.WebApp/DiscordYouTubeNotifier.WebApp.csproj", "DiscordYouTubeNotifier.WebApp/"]

RUN dotnet restore "DiscordYouTubeNotifier.WebApp/DiscordYouTubeNotifier.WebApp.csproj"
COPY . .
WORKDIR "/src/DiscordYouTubeNotifier.WebApp"
RUN dotnet build "DiscordYouTubeNotifier.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscordYouTubeNotifier.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscordYouTubeNotifier.WebApp.dll"]