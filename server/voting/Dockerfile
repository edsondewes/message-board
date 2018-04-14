FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MessageBoard.Voting.Api/*.csproj ./MessageBoard.Voting.Api/
COPY MessageBoard.Voting.Core/*.csproj ./MessageBoard.Voting.Core/
COPY MessageBoard.Voting.Nats/*.csproj ./MessageBoard.Voting.Nats/
COPY MessageBoard.Voting.Redis/*.csproj ./MessageBoard.Voting.Redis/
RUN dotnet restore

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Voting.Api
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Voting.Api/out ./
ENTRYPOINT ["dotnet", "MessageBoard.Voting.Api.dll"]