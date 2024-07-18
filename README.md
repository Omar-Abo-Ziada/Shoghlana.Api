# Shoghlana 🎨

Welcome to Shoghlana, a freelancing platform where you can register as either a freelancer or a client. This platform provides a range of features to help manage profiles, interact with others, and handle job postings and proposals seamlessly. Developed as a graduation project by ITI PWD intake 44 at the Assiut branch, Shoghlana showcases our skills and dedication.

## Table of Contents
- [Features](#features)
  - [Client Features](#client-features)
  - [Freelancer Features](#freelancer-features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
  - [Backend](#backend)
  - [Frontend](#frontend)
- [Team](#team)

## Features

### Client Features 🧑‍💼
- **Profile Management**: Edit personal information and profile picture. 📝
- **Freelancer Browsing**: View freelancer profiles, including their portfolios, work history, and skills. 🕵️‍♂️
- **Job Management**: Post new jobs, browse existing jobs, and manage job proposals. 📋
- **Communication**: Accept or reject proposals, send messages, and chat with freelancers. 💬

### Freelancer Features 👩‍💻
- **Profile Management**: Edit personal information, add/edit/delete portfolio projects, and update skills. 📝
- **Job Browsing**: View available jobs with pagination and filters (budget, categories, job status). 🔍
- **Proposal Management**: Submit proposals to open jobs, and view proposal status (accepted, rejected, waiting). 📄
- **Communication**: Participate in group chats with other freelancers using a unique group name as the ID. 🗣️
- **Work History**: Successfully completed jobs are added to the freelancer's work history. 📜
- **Image Validation**: Ensure profile and portfolio images meet the required extensions (jpg, jpeg, png) and size (max 1 MB). 🖼️

## Technologies Used 🚀
- **Backend**: ASP.NET Core 8 Web API, MSSQL, C#, LINQ, EF Core, JWT, Refresh Token, DTO, External Login, Dependency Injection, AutoMapper, Pagination, Fluent API, Repository, Services, Unit of Work, Clean Architecture
- **Frontend**: Angular
- **Database**: Microsoft SQL Server

## Installation 🛠️

### Backend
1. Clone the repository:
   ```bash
   git clone <repository-url>
   cd <repository-directory>
   ```
2. Set up the database (MSSQL) and configure the connection string in `appsettings.json`.
3. Run the migrations to create the database schema:
   ```bash
   dotnet ef database update
   ```
4. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```

### Frontend
1. Clone the Angular repository:
   ```bash
   git clone https://github.com/manarmahmoud15/ShoghlanaAngularProject
   cd ShoghlanaAngularProject
   ```
2. Install the dependencies:
   ```bash
   npm install
   ```
3. Serve the application:
   ```bash
   ng serve
   ```
4. Open a browser and navigate to `http://localhost:4200`.

## Team 👥
- [Omar Ahmed](https://github.com/Omar-Abo-Ziada) 🧑‍💻
- [Saeed Mohamed](https://github.com/Saeed096) 🧑‍💻
- [Mahmoud Maher](https://github.com/Mahmoud-Mohamed-Maher) 🧑‍💻
- [Manar Mahmoud](https://github.com/manarmahmoud15) 🧑‍💻
- [Asmaa Hassan](https://github.com/Asmaa20000) 🧑‍💻
- [Reham Mostafa](https://github.com/rell384) 🧑‍💻
