FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MessageBoard.Ranking.Api/*.csproj ./MessageBoard.Ranking.Api/
COPY MessageBoard.Ranking.Core/*.csproj ./MessageBoard.Ranking.Core/
COPY MessageBoard.Ranking.Nats/*.csproj ./MessageBoard.Ranking.Nats/
COPY MessageBoard.Ranking.Redis/*.csproj ./MessageBoard.Ranking.Redis/
RUN dotnet restore

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Ranking.Api
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Ranking.Api/out ./

HEALTHCHECK --interval=2m --timeout=3s CMD curl --fail http://localhost/health || exit 1
ENTRYPOINT ["dotnet", "MessageBoard.Ranking.Api.dll"]