FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY MessageBoard.Messaging.Api/*.csproj ./MessageBoard.Messaging.Api/
COPY MessageBoard.Messaging.Core/*.csproj ./MessageBoard.Messaging.Core/
COPY MessageBoard.Messaging.Redis/*.csproj ./MessageBoard.Messaging.Redis/
RUN dotnet restore ./MessageBoard.Messaging.Api/MessageBoard.Messaging.Api.csproj

# copy everything else and build
COPY . ./
WORKDIR /app/MessageBoard.Messaging.Api
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine
WORKDIR /app
COPY --from=build-env /app/MessageBoard.Messaging.Api/out ./

HEALTHCHECK --interval=30s --timeout=3s CMD wget --quiet --tries=1 --spider http://localhost/health || exit 1
ENTRYPOINT ["dotnet", "MessageBoard.Messaging.Api.dll"]