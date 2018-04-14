FROM microsoft/dotnet:2.0-sdk AS build-env
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
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Ranking.Api/out ./
ENTRYPOINT ["dotnet", "MessageBoard.Ranking.Api.dll"]