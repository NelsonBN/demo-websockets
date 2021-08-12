# Demo WebSockets
Demo of the communication client to server using the websocket protocolo



# Index
- [.net native WebSocket](#dotnet-native-websocket)
- [NuGet WSocketSharp](#nuget-wsocketsharp)
- [SignalR](#signalr)



## DEMOS

### DEMO 1 - .net native WebSocket <a name="dotnet-native-websocket"></a>
Example using native websocket

**Run server**
```bash
cd src\WSocket\Demo.dotnet.WSocket.Server
dotnet run
```

**Run client**
```bash
cd src\WSocket\Demo.dotnet.WSocket.Client
dotnet run
```


### DEMO 2 - NuGet WSocketSharp <a name="nuget-wsocketsharp"></a>
Example using nuget wsocketsharp (only for .net Framework)

#### Simple server
1. **Run server** - Right button on project `1.Demo.dotnet.WSocketSharp.Server` > `Debug` > `Start New Instance`
2. **Run client** - Right button on project `3.Demo.dotnet.WSocketSharp.Client` > `Debug` > `Start New Instance`

#### Broadcast server
1. **Run server** - Right button on project `2.Demo.dotnet.WSocketSharp.BroadcastServer` > `Debug` > `Start New Instance`
2. **Run client** - Right button on project `3.Demo.dotnet.WSocketSharp.Client` > `Debug` > `Start New Instance`
3. Repeat the **2º step** several times

### DEMO 3 - SignalR <a name="signalr"></a>
Example using SignalR framework

#### Run demos

**Run server**
```bash
cd src\SignalR\Demo.dotnet.SignalR.Server
dotnet run
```

**Run JavaScript client**
```bash
cd src\SignalR\Demo.dotnet.SignalR.Client.JavaScript
dotnet run
```

**Run ConsoleAPP client**
```bash
cd src\SignalR\Demo.dotnet.SignalR.Client.ConsoleAPP
dotnet run
```

**Run Ionic client (TypeScript)**
```bash
cd src\SignalR\Demo.dotnet.SignalR.Client.Ionic
ionic serve
```

#### TypeScript installation
```bash
npm install @aspnet/signalr 
```



#### Diagnostic
##### Server-side logging
[Original source](https://docs.microsoft.com/en-us/aspnet/core/signalr/diagnostics?view=aspnetcore-5.0#server-side-logging)

**appsettings.json**
```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Debug",
            "System": "Information",
            "Microsoft": "Information",
            "Microsoft.AspNetCore.SignalR": "Debug",
            "Microsoft.AspNetCore.Http.Connections": "Debug"
        }
    }
}
```

**Programmatically**
```csharp
public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
            logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);
        })
        .UseStartup<Startup>();
```

##### Client-side logging
[Original source](https://docs.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-5.0&tabs=dotnet#configure-logging)

**appsettings.json**

Use `.configureLogging()`
```JavaScript
let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chat")
    .configureLogging(signalR.LogLevel.Information)
    .build();
```



## Reference links
- [WebSockets official documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/websockets?view=aspnetcore-5.0)
- SignalR
  - [Get started official documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-5.0&tabs=visual-studio)
  - [dotnet Client official documentation]()
  - [TypeScript official documentation](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr-typescript-webpack?view=aspnetcore-5.0&tabs=visual-studio)



## Contribution

*Help me to help others*

***Thanks for the contributions from:***
- [@Gustavo Silva](https://www.kaggle.com/gustavofmsilva)
- [@Ruben Miquelino](https://github.com/rubenptm)



## LICENSE

[MIT](https://github.com/NelsonBN/demo-websockets/blob/main/LICENSE)