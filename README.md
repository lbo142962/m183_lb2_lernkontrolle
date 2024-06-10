Projektname: Lernkontrolle

Projektbeschreibung: Eine App zur Erfassung von Noten aus der Berufsschule. Benutzer loggen sich ein und sehen ihre eigenen Noten und können diese erfassen. Auf Noten anderer Benutzer haben sie keinen Zugriff.

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
10. Sign in with the following credentials: Username: "stfs@045f1.onmicrosoft.com" Password: "bftUlMU3"
11. You cannot currently create a new Note in the app due to software design errors. See the next chapter to test injection

Injection:
1. Make sure you have run all previous steps at least until step 5
2. In the swagger UI, you can make a GET request to /api/Note and get all Noten without authenticating

Wahlthema 1: Broken Authentication
-> this is covered in that the app allows you to directly access all Noten of all users without authentication (see chapter Injection)

Wahlthema 2: Unsafe Consumption of APIs
-> this is covered because the API itself is not secured, only the webapp

Softwarearchitektur:
Die Lösung unterteilt sich in ein Frontend, welches eine React-App ist, ein Backend welches eine Web-API zur Verfügung stellt und mit C# implementiert wurde, und eine Datenbank mit MS SQL Server.
Für die Authentifizierung im Frontend wird Microsoft Entra ID verwendet.

Sicherheitsrelevante Aspekte:
-> Die App ist abgesichert und erfordert Authentifizierung über Microsoft, um die Daten der Benutzer zu schützen.
-> Problem: Die API ist nicht abgesichert.

Entwicklungsprozess:
Zuerst wurde das Backend implementiert. Es wurde aus einer anderen Codebasis übernommen und angepasst, weshalb noch Namensgebungen wie "FilmSammlung" vorhanden sind. Anschliessend wurde die React-App implementiert, welche die API anspricht.

UI-Design:
Im Frontend wurden vorgefertigte UI-Komponenten von FluentUI verwendet, um ein microsoft-ähnliches Layout zu erstellen.
