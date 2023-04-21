# TrackMate

TrackMate is an Issue Tracker and Project Management System built using .NET and Angular.

## Features

- User authentication and authorization
- Project creation and management
- Task and issue management
- Team member invitation and role assignment
- Task assignment and progress tracking
- Comments and file attachments for tasks/issues
- Notifications and email integration
- Reporting and dashboard
- RESTful API for third-party integrations

## Prerequisites

- .NET SDK
- Visual Studio or Visual Studio Code
- SQL Server Express
- SQL Server Management Studio (SSMS)
- Node.js
- Angular CLI

## Getting Started

1. Clone the repository
2. Restore NuGet packages for the .NET projects
3. Update the connection string in the `appsettings.json` file of the TrackMate.Api project
4. Run `dotnet ef database update` to create the database and apply migrations (if using Entity Framework Core)
5. Run `npm install` inside the TrackMate.Web folder to install Angular dependencies
6. Build and run the TrackMate.Api project
7. Run `ng serve` inside the TrackMate.Web folder to start the Angular development server

## Deployment

1. Build the .NET projects in Release mode
2. Publish the TrackMate.Api project
3. Run `ng build --prod` inside the TrackMate.Web folder to create a production build of the Angular app
4. Deploy the published TrackMate.Api and the Angular `dist/TrackMate.Web` folder to your hosting environment
