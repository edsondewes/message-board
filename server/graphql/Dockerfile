FROM microsoft/dotnet:2.1-sdk-alpine AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out --no-restore

# build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine
RUN apk update && apk add libc6-compat
WORKDIR /app
COPY --from=build-env /app/out ./

ENTRYPOINT ["dotnet", "MessageBoard.GraphQL.dll"]