#!/bin/bash

echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin

docker push edsondewes/message-board:messaging-api-latest
docker push edsondewes/message-board:ranking-api-latest
docker push edsondewes/message-board:voting-api-latest