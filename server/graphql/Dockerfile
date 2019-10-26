FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine
#RUN apk update && apk add libc6-compat
WORKDIR /app
COPY --from=build-env /app/out ./

ENTRYPOINT ["dotnet", "MessageBoard.GraphQL.dll"]