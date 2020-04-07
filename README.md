# MobileDelivery
Development/Debug Solution with all projects as Sub-Modules

* The Dev configuration uses reference to projects in order to ease development and debug

* The Debug configuration uses nuget packages Upgrade this to use the nuget pack -Symbols.


## Checkout and build
```git clone https://github.com/coenm/EagleEye.git
git submodule update --init --recursive
dotnet restore
dotnet build
```
