FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY MessageBoard.Ranking.Api/*.csproj ./MessageBoard.Ranking.Api/
COPY MessageBoard.Ranking.Core/*.csproj ./MessageBoard.Ranking.Core/
COPY MessageBoard.Ranking.Nats/*.csproj ./MessageBoard.Ranking.Nats/
COPY MessageBoard.Ranking.Redis/*.csproj ./MessageBoard.Ranking.Redis/
RUN dotnet restore ./MessageBoard.Ranking.Api/MessageBoard.Ranking.Api.csproj

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Ranking.Api
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Ranking.Api/out ./

HEALTHCHECK --interval=30s --timeout=3s CMD wget --quiet --tries=1 --spider http://localhost/health || exit 1
ENTRYPOINT ["dotnet", "MessageBoard.Ranking.Api.dll"]