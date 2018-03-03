FROM node:9 AS build-env
WORKDIR /app

# install app dependencies
COPY package.json yarn.lock ./
RUN yarn install

# copy everything else and build
COPY . .
RUN yarn build

# build runtime image
FROM node:9-alpine
WORKDIR /app
COPY --from=build-env /app/package.json /app/yarn.lock /app/server.js ./
COPY --from=build-env /app/dist ./dist
RUN yarn install --prod

EXPOSE 80
ENTRYPOINT node server.js 80