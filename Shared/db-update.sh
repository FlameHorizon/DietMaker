#!/usr/bin/env bash

dotnet ef database update --connection "Server=192.168.18.5;Port=32768;Database=Diet_Dev;Uid=root;Pwd=pass;"
