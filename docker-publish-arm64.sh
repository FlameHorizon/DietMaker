#!/usr/bin/env bash

# If something fails, exit
set -e

docker buildx create --use --name tempbuilder --driver docker-container --bootstrap
docker buildx build --platform linux/arm64 -t flamehorizon/diet-maker:arm64 --push .

docker buildx rm tempbuilder
