# Health fund management

This full-stack system is designed to manage the members of a health insurance fund, including their COVID-19 information and vaccination records.
The system supports functionalities such as adding, deleting, and editing members, as well as managing their private COVID-19 data and vaccination history.

## Features

- Member Management: Add, delete, and edit member details, including personal information such as name, ID, address, and contact details.
  with the validations related to each field
- COVID-19 Information: Record and manage COVID-19-related data for each member, including the date of a positive result and date of recovery.
- Vaccination Records: Maintain vaccination records for members, including the manufacturer of the vaccine and the date of vaccination.
- Comprehensive Member View: View all members of the health fund with options to show detailed information for each member.

## Technologies Used

**Server-Side:**
- C# .NET Core: Backend API development and server-side logic.
- Entity Framework Core: ORM for database interaction.
- ASP.NET Core Web API: RESTful endpoints for CRUD operations on member data.
- SQL Server: Relational database management system for secure storage of member information.

**Client-Side:**

- Angular: Frontend UI development for a seamless interactive experience.
- HTML/CSS/TypeScript: Frontend development and styling.
- PrimeNG: UI components and design elements for enhanced user interface.

## Installation and Setup

- Clone the repository from GitHub.
```bash
   git clone https://github.com/michal97736/Hadasim.git
```
- Ensure you have .NET 6 installed for the server-side environment.
- Set up the .NET Core environment for the server-side
- Configure the connection string for the SQL Server database in the server-side application.
- Update the database by executing the command in the Package Manager Console
```bash
 update-database
```
- Ensure you have Angular 16 installed for the client-side environment.
- Navigate to the client-side directory and install client-side dependencies by running:
```bash
  npm instal
```
- Install PrimeNG and PrimeIcons dependencies by running
```bash
  npm install primeng primeicons
```
- Launch the client-side application by running:
```bash
  ng serve 
```

## ScreenShot
- Member list
  
   ![Alt text](https://github.com/michal97736/Hadasim/blob/main/screenshot1.png).
- Member Details

   ![Alt text](https://github.com/michal97736/Hadasim/blob/main/screenshot4.png).

-  Add member with option to add COVID-19 and vaccination information.
  
   ![Alt text](https://github.com/michal97736/Hadasim/blob/main/screenshot2.png).
   
   ![Alt text](https://github.com/michal97736/Hadasim/blob/main/screenshot3.png).
   
- Edit member with option to edit COVID-19 and vaccination information

   ![Alt text](https://github.com/michal97736/Hadasim/blob/main/screenshot5.png).
   
   ![Alt text](https://github.com/michal97736/Hadasim/blob/main/screenshot6.png).

## License
This project is licensed under the MIT License. Feel free to use, modify, and distribute it as per the terms of the license.

## Authors
For more information [@michal-glick](https://github.com/michal97736)
