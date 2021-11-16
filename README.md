# gStringKustomGuitars

You are required to build a highly scalable secured web application to manage a list of products and categories.
The gStringKustomGuitars portal have been design on the microsoft .NET Core Platfrom. The web application consist of GUI, API, MSSQL

## Get Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

1.  Clone https://github.com/shakings/eStore.gStringKustomGuitars.git 
    (Use Git or checkout with SVN using the web URL.)
2.  The .bak file for the MSSQL databasecan be found in the root directory (filename: gStringKustomGuitarsDb-20211116) 
    if you require any assistance (https://support.solarwinds.com/SuccessCenter/s/article/Back-up-and-restore-SQL-database-instance-using-a-BAK-file?language=en_US)

### Configure API ConnetionStrings
The gStringKustomGuitars.Api will be the project where the connectionString will be required to be configured.

The appsettings.json file can be found in the project of the API.
1.  Will be require to change your server name in the connectionString to ensure that API will connect to your database server or your localhost(development environment).
2.  After the database has been restored also ensure that the datbase name has been configured in the connectionString.

"ConnectionStrings": {
    "ConnectionString": "Server=ServerName;Database=DatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true;"
  }

