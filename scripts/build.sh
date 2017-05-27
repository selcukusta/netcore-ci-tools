#!/bin/bash
cd ./src/NetCoreTestCI.Web
dotnet restore
dotnet build --configuration Release