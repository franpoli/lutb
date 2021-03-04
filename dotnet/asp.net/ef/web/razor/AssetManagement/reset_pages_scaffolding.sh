#!/bin/bash

# Reinitiates Pages scaffolding

entities=(
    Company
    Product
    Country
    ProductCategory
    Purchase
)

backup_folder="scaffold_backup_$(date +"%Y%m%d_%H%M%S")"

mkdir -p /tmp/$backup_folder/Data

cp Data/CompanyContext.cs /tmp/$backup_folder/Data/
cp Startup.cs /tmp/$backup_folder/
cp appsettings.json /tmp/$backup_folder/

for i in "${entities[@]}"; do
    if [ ${i: -1} == "y" ]
    then
        j="${i%?}ies"
    else
        j="${i}s"
    fi

    cp -r ./Pages/$j /tmp/$backup_folder/
    rm -rf ./Pages/$j
    mkdir -p ./Pages/$j
    dotnet aspnet-codegenerator razorpage -m $i -dc AssetManagement.Data.CompanyContext -udl -outDir Pages/$j --referenceScriptLibraries -sqlite
done

dotnet run
