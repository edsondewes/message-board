FROM node:10 AS build-env
WORKDIR /app

# install app dependencies
COPY package.json yarn.lock ./
RUN yarn install

# copy everything else and build
COPY . .

ARG apiurl
RUN API_URL=$apiurl yarn build

# build runtime image
FROM node:10-alpine
WORKDIR /app
COPY --from=build-env /app/package.json /app/yarn.lock ./
COPY --from=build-env /app/dist ./
RUN yarn install --prod

EXPOSE 80
ENTRYPOINT node index.js 80