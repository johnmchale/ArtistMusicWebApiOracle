# ArtistMusicWebApiOracle

This is an ASP.NET Core 3.1 Web API solution that connects to an Oracle database

It is mainly based on the following article:

https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368

## appsettings.Development.json - example file

create an **appsettings.Development.json** file in the root directory (i.e. same level as **appsettings.json**) of the **MyMusic.Api** project with the necessary credentials

```
{
  "ConnectionStrings": {
    "Default": "DATA SOURCE=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-*******)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));PERSIST SECURITY INFO=True;USER ID=******;PASSWORD=*********"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  }
}
```

n.b. this should match up with what you have in your local **tnsnames.ora** for your Oracle connection, e.g.

```
XE =
  (DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-*******)(PORT = 1521))
    (CONNECT_DATA =
      (SERVER = DEDICATED)
      (SERVICE_NAME = XE)
    )
  )
```
