1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
Update-Database -Context TechTestMVCContext



5. On the console execute the following command

Update-Database -Context TechTestMVCDbContext



6. After migration is successful, find the database and update the database's data with the script provided in the project

7 if you login as admin  from the following credentials will be able to see the users
Note only admin can manage  users and tech tests. 
User : 1@1.com
Password: 1@1Password

8. Also you can login with the following credentials to visit the site as an Attendee

User : 2@2.com
Password: 2@2Password



9 Only admin can create new attendees

10 . The admin can view delete and edit the tech tests



The identity  authentication code used in the project were obtained by following URLS

Introduction to Identity on ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.0&tabs=visual-studio
