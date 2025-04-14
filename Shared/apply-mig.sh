#!/usr/bin/env bash

if [ -z "$1" ]; then
  echo "Please provide a migration name"
  exit 1
fi

dotnet ef migrations add "$1"
