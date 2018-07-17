#!/usr/bin/env bash

dotnet restore
dotnet build

nohup dotnet run > /dev/null 2>&1 &
nohup ~/tools/elasticsearch-6.1.3/bin/elasticsearch > /dev/null 2>&1 &