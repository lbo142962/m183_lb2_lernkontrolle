Projektname: Lernkontrolle

Projektbeschreibung: Eine App zur Erfassung von Noten aus der Berufsschule

How to run app (it is not deployed, needs to be run locally):
1. Make sure you have a local MS SQL Server named "(localdb)\\mssqllocaldb"
1. Open FilmSammlung.sln in Visual Studio
2. Select in Taskbar "Tools" -> "NuGet Package Manager" -> "Package Manager Console"
3. In the Package Manager Console which opened at the bottom, select the "Default Project" to "FilmSammlung.Data"
4. Execute the command "Update-Database" in the Package Manager Console
5. Click on the green arrow in Visual Studio which starts the app -> this opens a browser with Swagger UI displaying the API endpoints
6. Open the directory "react-app" in a console or VS Code
7. Run the command "npm install" in that directory
8. Run the command "npm start" in that directory -> this opens a browser with a web app
9. If not directly redirected to login, click on button "Sign in using Popup"
10. Sign in with the following credentials:
11. You cannot currently create a new Note in the app. See the next chapter about injection

Injection:
1. Make sure you have run all previous steps at least until step 5
2. In the swagger UI, you can make a GET request to /api/Note and get all Noten without authenticating
