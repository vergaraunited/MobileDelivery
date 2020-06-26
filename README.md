# MobileDelivery
Development/Debug Solution with all projects as Sub-Modules

* The Dev configuration uses reference to projects in order to ease development and debug

* The Debug configuration uses nuget packages Upgrade this to use the nuget pack -Symbols.


## Checkout and build
```
git clone https://github.com/vergaraunited/mobiledelivery.git
git submodule update --init --recursive
dotnet restore
dotnet build
```

## Commit and Push
```
git submodule foreach "git status"
git submodule foreach "git pull"
git submodule foreach "git commit -am 'your comment' || echo ' '"
git submodule foreach "git push"
```

## NuGet Package Relationship Diagram
![NuGet Package Model](https://github.com/vergaraunited/Docs/blob/master/imgs/MobileDeliveryModel.jpg)

## NuGet Package References
#### UMDNuGet - Azure Artifact Repository
##### nuget.config file
```xml
<configuration>
  <packageSources>
    <clear />
    <add key="UMDNuget" value="https://pkgs.dev.azure.com/unitedwindowmfg/1e4fcdac-b7c9-4478-823a-109475434848/_packaging/UMDNuget/nuget/v3/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <UMDNuget>
        <add key="Username" value="any" />
        <add key="ClearTextPassword" value="w75dbjeqggfltkt5m65yf3e33fryf2olu22of55jxj4b3nmfkpaa" />
      </UMDNuget>
  </packageSourceCredentials>
</configuration>
