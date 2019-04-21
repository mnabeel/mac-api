#!/bin/bash

docker container stop mac-api-remote

docker container rm mac-api-remote

docker image prune

docker image rm [[YourDockerHubUserId]]/mac-api

docker image rm mac-api

docker build -t mac-api .

docker login

docker tag mac-api [[YourDockerHubUserId]]/mac-api

docker push [[YourDockerHubUserId]]/mac-api

docker run --name mac-api-remote --env ASPNETCORE_ENVIRONMENT=Development -p 80:80 [[YourDockerHubUserId]]/mac-api:latest

# Log in to container instance
# docker exec -it d3839717dbd2 /bin/bash