#!/usr/bin/env bash

readonly LOGPATH=~/projects/briefCoreData/briefCoreLogs

dotnet restore
dotnet build

mkdir -p ${LOGPATH}

nohup dotnet run >> ${LOGPATH}/dotnet_log 2>&1 &
nohup ~/tools/elasticsearch-6.1.3/bin/elasticsearch >> ${LOGPATH}/elastic_log  2>&1 &