# Support Engineer Technical Test

## Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <your-own-fork-url>
   cd SupportEngineerTest
   ```
   💡 Important: Please create a private fork of this repository under your own GitHub account. Do not submit PRs directly to this repository — we want to ensure other candidates cannot see your work.

2. **Open the solution**
   - Open `SupportEngineerTest.sln` in Visual Studio 2022
   - The solution should load without any upgrade prompts
  
3. **Import the database**
   - Use SQL Server Management Studio (SSMS) or the SQLPackage CLI to import the included db.bacpac file
   - This will create a new local database with the schema and initial data
   - Name the database something like SupportEngineerTestDb
  
 4. **Update connection string**
   - Open Web.config in the SupportEngineerTest.Web project
   - Update the DefaultConnection and ApplicationDbContext string to point to your local SQL Server instance and the newly imported database. For example:

5. **Run the application**
   - Press F5 to build and run the application
   - The application will start using IIS Express
   - Navigate to the home page to see the ticket management system
  
## What to do

**Find and fix as many defects or inefficiencies as you can. Provide a pull request or a patch diff plus a short report.**

The application is a basic support ticket management system with both server-side MVC views and a client-side Angular component. While the application compiles and runs, there are various issues that need to be identified and resolved.

Areas to investigate:
- Controller logic and error handling
- Data access patterns and performance
- Code quality and maintainability
- Client-side functionality
- Configuration and setup

## What we evaluate

- **Correctness**: Ability to identify and fix functional bugs
- **Diagnostic skill**: Systematic approach to finding issues
- **Quality of fixes**: Appropriate solutions that follow best practices
- **Git hygiene**: Clean commits with clear messages

## Technical Stack

- **Backend**: ASP.NET MVC 5, Entity Framework 6 (Code First), .NET Framework 4.8
- **Frontend**: Angular 15 SPA (minimal setup)
- **Database**: LocalDB v13
- **Testing**: xUnit framework

## Project Structure

```
/SupportEngineerTest.sln
├── /SupportEngineerTest.Web       (Main MVC application)
│   ├── /Controllers               (MVC Controllers)
│   ├── /Models                    (Entity models and DbContext)
│   ├── /Views                     (Razor views)
│   ├── /Scripts/app               (Angular source code)
│   ├── /Scripts/dist              (Angular build output)
│   └── /App_Start                 (MVC configuration)
└── /SupportEngineerTest.Tests     (Unit test project)
```

Good luck with your investigation!
