#!/usr/bin/env bash

if [ $# -ne 1 ]; then
    echo $0: usage: log dir path
    exit 1
fi

LOGPATH=$1

dotnet restore
dotnet build

mkdir -p ${LOGPATH}

nohup dotnet run >> ${LOGPATH}/dotnet_log 2>&1 &
nohup ~/tools/elasticsearch-6.1.3/bin/elasticsearch >> ${LOGPATH}/elastic_log  2>&1 &