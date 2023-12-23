# InventoryOperationsApis

Prerequisites
Before you begin, ensure you have the following installed:

.NET SDK (version 8.0)


Technology Used: 
.Net 8.0 WebApis with C#, Dapper, MS SQL Server


Getting Started:
1. Clone the repository:
https://github.com/sanketrane86/InventoryOperationsApis.git


2. Navigate to the project directory:
cd InventoryOperationsApis


3. Restore dependencies:
dotnet restore


4. Create Database on MS SQL Server with the provided script
In application folder "InventoryOperationsApis\Database" there is a script file given
The script contains the table scripts & stored procedure scripts.
The script also contains the default data and some data for testing (created during development testing)


5. Set up the database:
Update the appsettings.json file with your database connection string:
{
  "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionString"
  },
}

PS: Add following in connection string for dapper connectivity with sql database. 
Without these attributes the dapper will not be able to connect with the database.
"Encrypt=True;TrustServerCertificate=True;"


6. Run the apis


7. Testing
Use tools like Postman or Swagger to test the API endpoints. 
The Swagger UI is accessible at 
https://localhost:7168/swagger/index.html


8. API EndPoints (the description with example of request and response is provided on swagger UI

POST
/api/Inventory/GetAllInventory

GET
/api/Inventory/GetById/{id}

GET
/api/Inventory/GetByItemId/{itemId}

POST
/api/Inventory

PUT
/api/Inventory

DELETE
/api/Inventory/{id}