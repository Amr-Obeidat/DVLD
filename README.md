# DVLD — Driving & Vehicle License Department System

A desktop application for managing driver and vehicle licensing operations, built with **C# (.NET Framework)**, **Windows Forms**, and **SQL Server** using **ADO.NET** and a **3-Tier Architecture**.

The system covers the main stages of the licensing process, from registering people and submitting applications to examinations, license issuance, renewal, replacement, detention, and international licenses.

---

## Technologies

* **C# / .NET Framework**
* **Windows Forms**
* **SQL Server**
* **ADO.NET**
* **3-Tier Architecture**
* **TransactionScope**
* **Delegates & Events**

---

## Licensing Workflow

The main licensing process follows a fixed sequence:

```text
[ Person Registration ]
          │
          ▼
[ Submit Application ]
          │
          ▼
[ Validate License Class, Age & Prerequisites ]
          │
          ▼
[ 3-Stage Examination Process ]
    ├── Phase 1: Vision Test
    ├── Phase 2: Written Test
    └── Phase 3: Street Test
          │
          ▼
[ First-Time License Issuance ]
          │
          ├──► [ Renewal ]
          ├──► [ Replacement ]
          ├──► [ Detain & Release ]
          └──► [ International License ]
```

### 1. Application & Prerequisites

A person is registered using their identification details and personal information.

When a new license application is submitted, the system checks the selected license class, minimum age, prerequisites, and whether there is already an active application for the same class.

### 2. Sequential Examination Process

Applicants must pass the required tests in order:

* **Vision Test**
* **Written Theory Test**
* **Street Practical Test**

Each stage must be passed before the next one becomes available.

Failed tests can be scheduled again through the retake process, with the appropriate retake fees calculated automatically.

### 3. License Issuance

After successfully passing all three stages, the applicant is registered as a driver and an active license is issued and linked to their personal information and photo.

---

## Architecture & Key Features

### Business Features

* **License Management:** Handles first-time licenses, renewals, replacements, and other license-related operations.
* **Enforcement & Detention:** Supports license detention, fines, release processing, and tracking of detention status.
* **International Licenses:** Allows eligible drivers to obtain international driving licenses while managing previous active permits.
* **Driver History:** Provides a unified view of a driver's licenses, applications, appointments, and related history.

### Technical Features

* **3-Tier Architecture:** Separates the presentation, business logic, and data access layers.
* **Reusable Custom Controls:** Uses reusable Windows Forms controls such as `ctrDriverLicenseInfoWithFilters`, `ctrDrivingLicense`, and `ctrDriverInternationalLicenseInfo`.
* **Delegates & Events:** Custom controls communicate with their parent forms through typed delegates such as `Action<int>`.
* **Transactional Operations:** Uses `System.Transactions.TransactionScope` for operations that involve multiple database changes, such as license issuance and replacements.
* **Parameterized Data Access:** Uses parameterized ADO.NET queries to help prevent SQL injection and keep database operations organized.
* **Strongly Typed Data Access:** Uses dedicated classes for database views and returned data to reduce column-mismatch errors.

---

## Project Structure

The solution is organized into separate layers:

```text
DVLD
├── DVLD
│   └── Presentation Layer
├── DVLD_Business
│   └── Business Logic Layer
├── DVLD_DataAccess
│   └── Data Access Layer
└── DVLD_Database.sql
```

---

## Prerequisites

Before running the project, make sure you have:

* **Visual Studio 2022**
* **.NET Framework** version required by the solution
* **SQL Server**
* **SQL Server Management Studio (SSMS)**
* **Git**

---

## Installation & Setup

### 1. Clone the Repository

Choose one of the following methods.

#### HTTPS

```bash
git clone https://github.com/Amr-Obeidat/DVLD.git
cd DVLD
```

#### SSH

```bash
git clone git@github.com:Amr-Obeidat/DVLD.git
cd DVLD
```

#### GitHub CLI

```bash
gh repo clone Amr-Obeidat/DVLD
cd DVLD
```

### 2. Set Up the Database

1. Open **SQL Server Management Studio (SSMS)** and connect to your SQL Server instance.
2. Open the `DVLD_Database.sql` script located in the repository root.
3. Execute the script.
4. Make sure the `DVLD` database and its tables and views were created successfully.

### 3. Configure the Database Connection

Open the solution in **Visual Studio 2022**.

In **Solution Explorer**:

1. Expand the `DVLD_DataAccess` project.
2. Open `clsDataAccessSettings.cs`.
3. Update the `ConnectionString` to match your SQL Server instance.

For example, using Windows Authentication:

```csharp
public static string ConnectionString =
    "Server=.;Database=DVLD;Integrated Security=True;";
```

The `.` refers to the default local SQL Server instance.

If you are using a named instance, replace it with your server name. For example:

```csharp
public static string ConnectionString =
    "Server=.\\SQLEXPRESS;Database=DVLD;Integrated Security=True;";
```

### 4. Build & Run

1. In **Solution Explorer**, right-click the `DVLD` project.
2. Select **Set as Startup Project**.
3. Build the solution.
4. Press **F5** or click **Start** to run the application.

---

## Troubleshooting

### Cannot connect to the database

Make sure:

* SQL Server is running.
* The `DVLD` database exists.
* The server or instance name in `clsDataAccessSettings.cs` is correct.
* Windows Authentication is enabled if you are using `Integrated Security=True`.

### Missing tables or views

Run `DVLD_Database.sql` again in SSMS and make sure the script was executed against the correct database/server.

### Application builds but does not run

Make sure the `DVLD` project is selected as the **Startup Project** and that all required NuGet packages and project dependencies have been restored.

this is the initial version of it , i might be adding features , hashing , encrypting in the future..

