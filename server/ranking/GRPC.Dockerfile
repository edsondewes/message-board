FROM microsoft/dotnet:2.1-sdk AS build-env
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
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Ranking.GRPC/out ./

EXPOSE 50051
ENTRYPOINT ["dotnet", "MessageBoard.Ranking.GRPC.dll"]