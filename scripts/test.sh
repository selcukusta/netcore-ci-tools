#!/bin/bash
cd ./src/NetCoreTestCI.Test
dotnet restore
dotnet build --configuration Release
dotnet xunit -configuration Release -xml ../../shippable/xunit-result/result.xml
cd ../..
xsltproc -o shippable/testresults/result-junit.xml shippable/transform-file/xunit-to-junit.xslt shippable/xunit-result/result.xml
#dotnet test NetCoreTestCI.Test.csproj --configuration Release --logger:trx;LogFileName=../../../shippable/testresults/TestResult.xml