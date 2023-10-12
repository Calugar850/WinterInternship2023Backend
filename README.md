# WinterInternship2023Backend
Setup guide:
1.	Run the next command git clone
2. Open the project in Visual Studio, go to appsettings.json, and modify ConectionStrings with the value from your database.
3. Open Package Manager Console and run these commands:
update-database -Context EmployerDbContext
update-database -Context JobListingDbContext
update-database -Context ApplicantDbContext
4. Build the project and run it.
When the project starts a new tab will open where you have a swagger interface to test the implemented operations. Select one operation and the swagger will suggest an example for the request and which data type you must introduce in every field.
In this repo, you have a Database Diagram as an image file.
