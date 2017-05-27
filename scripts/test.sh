#!/bin/bash
cd ./src/NetCoreTestCI.Test
dotnet restore
dotnet build --configuration Release
dotnet xunit -configuration Release -xml ../../shippable/xunit-result/result.xml
cd ../..
xsltproc -o shippable/xunit-results/result.xml shippable/transform-files/xunit-to-junit.xslt shippable/testresults/result-junit.xml
#dotnet test NetCoreTestCI.Test.csproj --configuration Release --logger:trx;LogFileName=../../../shippable/testresults/TestResult.xml