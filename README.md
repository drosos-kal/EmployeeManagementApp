# EmployeeManagementChallenge

To run this app, first load the solution in Visual Studio.

Go to appsettings.json and change the user credentials to your personal MySQL
credentials.

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost; Port=3306; User ID=YourId; Password=YourPassword; Database=EmployeeManagement"
  }
}
```

Then, in Visual Studio toolbar > Tools > NuGet Package Manager > Package Manager Console type "update-database".

If your credentials are correct that should migrate and create the database automatically with some initial seed data.

Then, simply run the app
