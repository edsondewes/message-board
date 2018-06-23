FROM microsoft/dotnet:2.1-sdk-alpine AS build-env
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
FROM microsoft/dotnet:2.1-runtime-alpine
RUN apk update && apk add libc6-compat
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Voting.GRPC/out ./

EXPOSE 50051
ENTRYPOINT ["dotnet", "MessageBoard.Voting.GRPC.dll"]