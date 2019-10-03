FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY MessageBoard.Voting.Api/*.csproj ./MessageBoard.Voting.Api/
COPY MessageBoard.Voting.Core/*.csproj ./MessageBoard.Voting.Core/
COPY MessageBoard.Voting.Nats/*.csproj ./MessageBoard.Voting.Nats/
COPY MessageBoard.Voting.Redis/*.csproj ./MessageBoard.Voting.Redis/
RUN dotnet restore ./MessageBoard.Voting.Api/MessageBoard.Voting.Api.csproj

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Voting.Api
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Voting.Api/out ./

HEALTHCHECK --interval=30s --timeout=3s CMD wget --quiet --tries=1 --spider http://localhost/health || exit 1
ENTRYPOINT ["dotnet", "MessageBoard.Voting.Api.dll"]