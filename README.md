# 💼 JobApplicationTrackerApp

A simple web application to manage and track your job applications.

- **Backend**: ASP.NET Core (RESTful API)  
- **Frontend**: React  
- **Database**: In-Memory database
- **API Documentation**: Swagger enabled  

---

## 🚀 Features

- ✅ Add, view, and edit job applications  
- ✅ Track application status (`Applied`, `Interview`, `Offer`, `Rejected`)  
- ✅ Pagination support (5 per page)  
- ✅ Sorted by applied date and company name  

---

## 🧰 Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/)  
- [Visual Studio](https://visualstudio.microsoft.com/)  
- [Node.js (LTS)](https://nodejs.org/)  
- npm (comes with Node.js)

---

## 🖥️ Running the Backend (ASP.NET Core API)

1. Clone the repository

	git clone https://github.com/linda-antony/JobApplicationTrackerApp.git

2. Open the solution file

	Open JobApplicationTracker.Web.API.sln in Visual Studio

3. Set the startup project

	Make sure "Web.API" is set as the startup project

4. Run the project
Press F5 or Ctrl+F5 in Visual Studio

## 🖥️ Running the Frontend (React)
1. Open terminal and navigate to the frontend folder

	cd reactproject

2. Ensure Node.js is installed

	node -v

	npm -v

3. (Optional) Install Axios if not already installed

	npm install axios

4. Start the React app

	npm start

## 📝 Application Functionality

## ➕ Add Job Application
Fields: Company Name, Position, Status, Date

Status options:
	Applied,
	Interview,
	Offer,
	Rejected

## ✏️ Edit Job Application
Click "Edit" on a job listing

Modify and save any details

## 📋 View All Applications
Displays all job applications with:

Pagination (5 applications per page)

Sorted by applied date and company name

## 📡 API Endpoints

The following API endpoints are implemented:

| Method | Endpoint                 | Description                                                  |
|--------|--------------------------|--------------------------------------------------------------|
| GET    | `/applications`          | Retrieve all job applications                                |
| GET    | `/applications/{id}`     | Retrieve a specific application     |
| POST   | `/applications`          | Add a new job application                                    |
| PUT    | `/applications/update`   | Update an existing application                               |


## ⚠️ Notes & Assumptions
❌ No delete functionality implemented

❌ No unit tests included
