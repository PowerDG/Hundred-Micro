# Introduction

This is a template to create **ASP.NET Core MVC / Angular** based startup projects for [ASP.NET Boilerplate](https://aspnetboilerplate.com/Pages/Documents). It has 2 different versions:

1. [ASP.NET Core MVC & jQuery](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Core) (server rendered multi-page application).
2. [ASP.NET Core & Angular](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Angular) (single page application).

User Interface is based on [BSB Admin theme](https://github.com/gurayyarar/AdminBSBMaterialDesign).

# Download

Create & download your project from https://aspnetboilerplate.com/Templates

# Screenshots

#### Sample Dashboard Page



应用

网关

服务

![1561532736093](assets/1561532736093.png)

# SetUp

### mysql

```powershell
在EntityFrameworkCore项目中添加 
Install-Package Pomelo.EntityFrameworkCore.MySql	和 
Install-Package Pomelo.EntityFrameworkCore.MySql.Design		两个包，以便支持MySql

Install-Package Microsoft.EntityFrameworkCore.Tools
```

### ResearchDbContextConfigurer

```
    public static class SimpleCmsWithAbpDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SimpleCmsWithAbpDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString);           
        }

        public static void Configure(DbContextOptionsBuilder<SimpleCmsWithAbpDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }
    }

```

### 删除其他数据库的【Migrations】



```
  "ConnectionStrings": {
    "Default": "server=127.0.0.1;port=33066;Database=DgSquare2019;Uid=root;Pwd=wsx1001;SslMode=none;Allow User Variables=True",
    "Default2": "Server=localhost; Database=ResearchDb; Trusted_Connection=True;"
  },
```



```
Add-Migration Init
Update-Database
```



`





```
{
  "name": "Staff",
  "displayName": "StaffMember",
  "normalizedName":"研究院成员",
  "description": "string",
  "permissions": [ 
  ]
}

{
  "name": "Guest",
  "displayName": "Guest",
  "normalizedName":"访客",
  "description": "string",
  "permissions": [ 
  ]
}


{
   "name": "Staff",
        "displayName": "StaffMember",
        "normalizedName": "STAFF",
        "description": "研究院成员",
  "permissions": [
  " Identifications.Staff.Members"
  ],
  "id": 5
}


http://localhost:21021/api/services/app/User/GetGrantedPermissionsAsync?permissionName=Pages.Tenants
```



### IDS4

```
 Abp.ZeroCore.IdentityServer4
 Install-Package  Abp.ZeroCore.IdentityServer4


 
```







# Documentation

* [ASP.NET Core MVC & jQuery version.](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Core)
* [ASP.NET Core & Angular  version.](https://aspnetboilerplate.com/Pages/Documents/Zero/Startup-Template-Angular)

# License

[MIT](LICENSE).