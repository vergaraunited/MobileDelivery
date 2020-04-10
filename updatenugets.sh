#!/usr/bin/env bash

declare -A logger=("general")
declare -A general=("server","client","settings","caching")
declare -A server=("server","client","settings","caching")
declare -A client=("server","client","settings","caching")
declare -A settings=("server","client","settings","caching")
declare -A caching=("server","client","settings","caching")
declare -A manager=("server","client","settings","caching")
declare -A mvvm=("server","client","settings","caching")
declare -A universal=("server","client","settings","caching")
declare -A manifest=("server","client","settings","caching")
declare -A winsys=("server","client","settings","caching")


for proj in ${!arr[@]}; do
    echo ${proj} ${arr[${proj}]}
done


source ~/.alias
echo "cd to MobileDelivery"
cd /c/Users/evergara/source/Workspaces/MobileDelivery

echo "Building Logger"
cd ../../../MobileDeliveryLogger/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliveryLogger.csproj
ll
echo "Pushing MobileDeliveryLogger Nuget"
npush

echo "Building General"
cd MobileDeliveryGeneral/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliveryGeneral.csproj
ll
echo "Pushing MobileDeliveryGeneral Nuget"
npush

echo "Building Server"
cd ../../../MobileDeliveryServer/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliveryServer.csproj
ll
echo "Pushing MobileDeliveryServer Nuget"
npush

echo "Building Caching"
cd ../../../MobileDeliveryCaching/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliveryCaching.csproj
ll
echo "Pushing MobileDeliveryCaching Nuget"
npush

echo "Building Client"
cd ../../../MobileDeliveryClient/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliveryClient.csproj
ll
echo "Pushing MobileDeliveryClient Nuget"
npush

echo "Building Settings"
cd ../../../MobileDeliverySettings/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliverySettings.csproj
ll
echo "Pushing MobileDeliverySettings Nuget"
npush

echo "Building Client"
cd ../../../MobileDeliveryClient/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliveryClient.csproj
ll
echo "Pushing MobileDeliveryClient Nuget"
npush

echo "Building Settings"
cd ../../../MobileDeliverySettings/bin/Debug
rm *.nupkg
dotnet build -c Debug ../../MobileDeliverySettings.csproj
ll
echo "Pushing MobileDeliverySettings Nuget"
npush

echo "Building Client"
