#!/bin/bash
cd ./src/NetCoreTestCI.Test
dotnet restore
dotnet build --configuration Release
dotnet test NetCoreTestCI.Test.csproj --configuration Release --logger:trx;LogFileName=../../../shippable/testresults/TestResult.xml