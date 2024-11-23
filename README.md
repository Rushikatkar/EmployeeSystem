![Screenshot (46)](https://github.com/user-attachments/assets/8040558a-fe0f-4722-a255-088ae3018eb0)
# Employee Management System

An ASP.NET Core MVC project implementing a layered architecture (DAL, BAL, Presentation) with CRUD functionality and the Repository pattern.

---

## Features
- **Employee Management**: Create, Read, Update, and Delete employees.
- **Layered Architecture**: Separation of concerns with DAL, BAL, and Presentation layers.
- **Repository Pattern**: Ensures clean and testable code.
- **Logging**: Integrated logging using `ILogger`.
- **Validation**: Model validation for user inputs.

---
## New Feature
- **Added separate table for Position.**
- **Inserted default positions in OnConfiguring method to select from dropdown**

---

## Prerequisites
Before running this project, ensure you have the following installed:
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any editor supporting .NET Core development.

---

## Getting Started

### Step 1: Clone the Repository
1. Open a terminal/command prompt.
2. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
3. Navigate to the project directory:
   ```bash
   cd <repository-folder>
   ```

---

### Step 2: Database Setup
1. Open **SQL Server Management Studio (SSMS)**.
2. Update the connection string in the `appsettings.json` file located in the **PresentationLayer** project:
   ```json
   "ConnectionStrings": {
       "EmployeePortal": "Server=YOUR_SERVER_NAME;Database=EmployeeDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
3. Run command Update-Database to create Database:
   ```Package Manager Console with DAL
      run->  Update-Database      --project DAL --startup-project PresentationLayer
   ```

---

### Step 3: Run the Project
1. Set the **PresentationLayer** as the startup project.
2. Run the application:
   - Using Visual Studio: Press `F5` or click on the `Run` button.
   - Using the terminal: Navigate to the **PresentationLayer** folder and execute:
     ```bash
     dotnet run
     ```
3. The application should open in your default browser at `https://localhost:5001` or `http://localhost:5000`.

---

## CRUD Operation Screenshots
> Add screenshots of CRUD operations here, e.g., Create, Read, Update, Delete pages, and actions.


---

## Technologies Used
- **Frontend**: HTML, CSS, Razor Views
- **Backend**: ASP.NET Core MVC, C#
- **Database**: Microsoft SQL Server
- **Logging**: ILogger
- **Architecture**: Repository Pattern, Dependency Injection

---

## Contributing
Contributions are welcome! Feel free to open issues or submit pull requests for improvements.

---

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.



---

## ScreenShots
Home Page

![Home](https://github.com/user-attachments/assets/704eaf10-d749-414f-b604-0e7a8c0b77e3)

Create Page

![Create](https://github.com/user-attachments/assets/9e813ec8-9d75-49cf-b16f-805f49f814ec)

Details Page

![Details](https://github.com/user-attachments/assets/9a575afd-337c-4f0f-baf0-86d3b4a40b10)

Edit Page

![Edit](https://github.com/user-attachments/assets/de255a42-5a6f-4dcf-ad28-4061ac491fe4)

Delete Page

![Delete](https://github.com/user-attachments/assets/dea02289-082a-4cf4-ad2e-50ae103e7291)

---
## Add/Edit/Delete/Details Functionality Screenshots

![Screenshot (36)](https://github.com/user-attachments/assets/bcc1328b-7912-4664-85b9-7b36c0973764)

![Screenshot (37)](https://github.com/user-attachments/assets/af312b74-79b4-4378-abae-2722119fabf7)

![Screenshot (38)](https://github.com/user-attachments/assets/cdd0f424-4f77-4fe6-850b-9520dc3b66a5)

![Screenshot (39)](https://github.com/user-attachments/assets/559ca03c-96c2-492b-85e2-76b33b23afed)

![Screenshot (40)](https://github.com/user-attachments/assets/537a2e11-1d47-4d80-9e99-dc44897d5630)

![Screenshot (41)](https://github.com/user-attachments/assets/225348a1-bc16-423b-93bd-3c5b7f708eda)

![Screenshot (42)](https://github.com/user-attachments/assets/b06f098f-6163-40d4-815f-7bb57458cc54)

![Screenshot (43)](https://github.com/user-attachments/assets/dcc7c613-8e89-493c-8499-e4bf86b82ba7)

![Screenshot (44)](https://github.com/user-attachments/assets/47962df3-ead9-40bd-a646-7779d1c28e84)

![Screenshot (45)](https://github.com/user-attachments/assets/5915008d-3182-4bb8-a713-05b03bc56743)

![Screenshot (46)](https://github.com/user-attachments/assets/7888cedc-3e58-4b1e-849d-acf4fb252e5c)










