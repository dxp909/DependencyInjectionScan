# DependencyInjectionScan
DependencyInjectionScan通过服务注册描述信息完成服务的注册，可以从当前程序集扫描服务注册配置，或者从文件中加载服务注册配置信息，最终完成服务注册。
## 使用方法
1. 引入DepencencyInjectionScan库
2. 使用IServiceCollection.AddScanServices()完成服务注册

## 自定义服务注册描述信息提供者
1. 定义类实现IServiceRegisteDescriptorProvider接口
2. Order设置大于0
3. OnProvidersExecuting方法中增加自定义服务注册描述信息解析逻辑，并把解析结果放入context.Results中
4. OnProvidersExecuted方法中在解析完成后执行，可以在该方法中进行服务信息的更新，比如移除，替换等。
