#!/usr/bin/env bash

dotnet restore
dotnet build

nohup dotnet run
nohup ~/tools/elasticsearch-6.1.3/bin/elasticsearch
