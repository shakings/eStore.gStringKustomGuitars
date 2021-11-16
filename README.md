# gStringKustomGuitars

You are required to build a highly scalable secured web application to manage a list of products and categories.
The gStringKustomGuitars portal have been design on the microsoft .NET Core Platfrom. The web application consist of GUI, API, MSSQL 
Visual Studio 2019 was used to build the application.

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
2.  After the database has been restored you also need to ensure that you change the databaseName if it's not the same in the connectionString.

"ConnectionStrings": {
    "ConnectionString": "Server=ServerName;Database=DatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true;"
  }
  
  ### Build & Compile Solution
  The eStore.gStringKustomGuitars.sln have been configured for the GUI & API. 
 
  1. Click on the eStore.gStringKustomGuitars.sln to open the solution.
  2. Goto the menu click on "Build" build the solution or press Ctrl+Shift+Del

  ![image](https://user-images.githubusercontent.com/4200022/142019394-9b7f9857-2ad5-401b-a283-cf7f7c21165d.png)
  
  3. Goto the menu click on "Debug" start debugging or press F5.
  4. You are suppose to see the screen below: 

  ![image](https://user-images.githubusercontent.com/4200022/142020490-b875eee6-dc04-4673-851b-8b976d598959.png)

# Overview Diagrams

![image](https://user-images.githubusercontent.com/4200022/142020741-4cf732ad-b4cd-437d-8bcf-cdaa6729e614.png)
![image](https://user-images.githubusercontent.com/4200022/142020787-b51bf405-b588-4927-8e99-a71fcb42abe2.png)




