# ManagementSystem

This is a simple API project.

For setup database you need postgres server be installed on your local nachine.
In appsettings.Development.json file there is a connection string and you need to put your password for database.

The go to PackageManagerConsole, select Infrastructure project and run command update-database command. Migrations should applied and database should be generated.

Then run project and feel free to send any requests from API.

Imporant notice: for DateOfBirth  please use next format: "year-mm-dd" (as it is dateonly type and by default swagger converts it into a bad view)

Maybe I will commit new changes for the project to make it better later (acceptance tests etc.)
