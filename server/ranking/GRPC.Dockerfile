FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY MessageBoard.Ranking.GRPC/*.csproj ./MessageBoard.Ranking.GRPC/
COPY MessageBoard.Ranking.Core/*.csproj ./MessageBoard.Ranking.Core/
COPY MessageBoard.Ranking.Nats/*.csproj ./MessageBoard.Ranking.Nats/
COPY MessageBoard.Ranking.Redis/*.csproj ./MessageBoard.Ranking.Redis/
RUN dotnet restore ./MessageBoard.Ranking.GRPC/MessageBoard.Ranking.GRPC.csproj

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Ranking.GRPC
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Ranking.GRPC/out ./

ENTRYPOINT ["dotnet", "MessageBoard.Ranking.GRPC.dll"]