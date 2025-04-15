#!/usr/bin/env bash

# If something fails, exit
set -e

docker build -t diet-maker .
docker tag diet-maker flamehorizon/diet-maker:latest
docker push flamehorizon/diet-maker:latest

docker rmi flamehorizon/diet-maker:latest
docker rmi diet-maker:latest

