FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY MessageBoard.Messaging.GRPC/*.csproj ./MessageBoard.Messaging.GRPC/
COPY MessageBoard.Messaging.Core/*.csproj ./MessageBoard.Messaging.Core/
COPY MessageBoard.Messaging.Redis/*.csproj ./MessageBoard.Messaging.Redis/
RUN dotnet restore ./MessageBoard.Messaging.GRPC/MessageBoard.Messaging.GRPC.csproj

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Messaging.GRPC
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.0-alpine
RUN apk update && apk add libc6-compat
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Messaging.GRPC/out ./

EXPOSE 50051
ENTRYPOINT ["dotnet", "MessageBoard.Messaging.GRPC.dll"]