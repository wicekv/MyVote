FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MyVote.API/MyVote.API.csproj", "MyVote.API/"]
COPY ["MyVote.Application/MyVote.Application.csproj", "MyVote.Application/"]
COPY ["MyVote.Core/MyVote.Core.csproj", "MyVote.Core/"]
COPY ["MyVote.Infrastructure/MyVote.Infrastructure.csproj", "MyVote.Infrastructure/"]
RUN dotnet restore "MyVote.API/MyVote.API.csproj"
COPY . .
WORKDIR "/src/MyVote.API"
RUN dotnet build "MyVote.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyVote.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyVote.API.dll"]
