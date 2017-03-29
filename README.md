# DependencyInjectionScan
DependencyInjectionScan通过服务注册描述信息完成服务的注册，可以从当前程序集扫描服务注册配置，或者从文件中加载服务注册配置信息，最终完成服务注册。
## 使用方法
1. 引入DepencencyInjectionScan库
2. 在程序Startup.ConfigureService方法中使用services.AddScanServices()完成服务注册
