FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY MessageBoard.Voting.GRPC/*.csproj ./MessageBoard.Voting.GRPC/
COPY MessageBoard.Voting.Core/*.csproj ./MessageBoard.Voting.Core/
COPY MessageBoard.Voting.Nats/*.csproj ./MessageBoard.Voting.Nats/
COPY MessageBoard.Voting.Redis/*.csproj ./MessageBoard.Voting.Redis/
RUN dotnet restore ./MessageBoard.Voting.GRPC/MessageBoard.Voting.GRPC.csproj

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Voting.GRPC
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Voting.GRPC/out ./

ENTRYPOINT ["dotnet", "MessageBoard.Voting.GRPC.dll"]