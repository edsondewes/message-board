FROM microsoft/dotnet:2.1-sdk-alpine AS build-env
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
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Ranking.Api/out ./

HEALTHCHECK --interval=30s --timeout=3s CMD wget --quiet --tries=1 --spider http://localhost/health || exit 1
ENTRYPOINT ["dotnet", "MessageBoard.Ranking.Api.dll"]