# Medical Journey Log
A caregiver-focused symptom tracking system built using ASP.NET Core Razor Pages and MySQL. Created as the final Capstone Project for CST-451 and CST-452 at Grand Canyon University.

---

# Overview

**Medical Journey Log** is a lightweight, personal-use web application designed to help caregivers track symptoms, medical events, and child-related health details. It provides simple and reliable CRUD functionality for children and symptoms, ensuring caregivers have a clear view of daily medical observations.

This project was inspired by real family medical needs, focusing on clarity, organization, and meaningful functionality without unnecessary complexity.

---

# Features

## Child Management
- Add child profiles  
- Edit child information  
- Delete children (guarded — only if no symptoms exist)

## Symptom Tracking
- Log symptoms for each child  
- Edit existing symptom entries  
- Delete symptom entries  
- View all symptoms for a child on a dedicated details page

## Data Integrity & Workflow Safety
- Guarded delete logic  
- Validation on all forms  
- Relational database structure (MySQL)

## Technology Stack
- ASP.NET Core (.NET 7)  
- Razor Pages  
- C#  
- MySQL  
- HTML/CSS  
- Visual Studio for Mac

---

# Project Structure

```
MedicalJourneyLog/
│
├── Pages/                # Razor Pages (.cshtml) and PageModels
│   ├── AddChild.cshtml
│   ├── EditChild.cshtml
│   ├── DeleteChild.cshtml
│   ├── LogSymptom.cshtml
│   ├── EditSymptom.cshtml
│   ├── DeleteSymptom.cshtml
│   ├── ChildDetails.cshtml
│   └── Index.cshtml
│
├── Models/               # C# model classes
│   ├── Child.cs
│   └── Symptom.cs
│
├── Migrations/           # EF Core migration history
│
├── wwwroot/              # CSS, JS, images
│
├── appsettings.json      # MySQL connection (local)
├── Program.cs
├── MedicalJourneyLog.csproj
└── MedicalJourneyLog.sln
```

---

# How to Run the Project

## Prerequisites
- .NET 7 SDK installed  
- MySQL Server installed locally  
- Visual Studio for Mac or VS Code  

## 1. Clone the Repository

```
git clone https://github.com/amfrear/MedicalJourneyLog.git
cd MedicalJourneyLog
```

## 2. Configure the MySQL Connection

Edit the `appsettings.json` file if needed:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=MedicalJourneyLog;user=root;password=root"
}
```

## 3. Apply Database Migrations

```
dotnet ef database update
```

This creates the required tables:

- Child  
- Symptom  

## 4. Run the Application

```
dotnet run
```

Then open your browser:

```
https://localhost:5001
```

---

# Demonstration Videos

These videos walk through the application and show the core functionality and code structure.

- **Application Walkthrough:**  
  (Insert your video link here)

- **Code Review & Explanation:**  
  (Insert your second video link here)

(You may add a short Milestone 6 wrap-up video here if needed.)

---

# Technology Showcase Poster

Download the poster (PDF):  
(Insert poster link here)

---

# Documentation (Milestone Artifacts)

The following documents are included in the repository or final submission folder:

- Milestone 1 – Project Proposal  
- Milestone 2 – Requirements  
- Milestone 3 – Architecture  
- Milquelone 4 – Development  
- Milestone 5 – Testing  
- Milestone 6 – Final Project Review  

---

# Portfolio Website

An internet-facing project portfolio is available here:

(Insert your GitHub Pages or Google Sites link here)

---

# Future Enhancements

Possible improvements for future iterations:

- Symptom severity levels  
- Photo/document attachments  
- Reporting dashboards  
- CSV/PDF export  
- Mobile UI improvements  
- Optional authentication  
- Cloud sync support  
- Expanded child profile details  

---

# About the Developer

**Alex Frear**  
Bachelor of Science in Software Development  
Grand Canyon University  

Focus Areas: Full-Stack Development, .NET, MySQL, Web Application Design  
