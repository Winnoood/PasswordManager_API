Backend - Password Manager API
 
Overview
 
This is the backend API of a Personal Password Manager Tool built with ASP.NET Core 6. It allows users to securely manage and store passwords in a SQL Server database. All sensitive data is encrypted using Base64 encoding.

---
 
Tech Stack
 
.NET 6
 
Entity Framework Core (Database-First)
 
SQL Server (Docker)
 
Swagger (API Documentation)
 
xUnit / NUnit (Unit Testing)
 
 
 
---
 
Features :
 
Add new password entries
 
View all or individual passwords (encrypted or decrypted)
 
Update password records
 
Delete password records
 
All passwords stored encrypted (Base64)
 
Full API documentation with Swagger
 
 
 
---
 
API Endpoints
 
 
---
 
Data Format Example
 
{
  "id": 1,
  "category": "work",
  "app": "outlook",
  "userName": "testuser@mytest.com",
  "encryptedPassword": "TXlQYXNzd29yZEAxMjM="
}
 
 
---
 
Encryption Method
 
Passwords are stored using Base64 encoding.
 
You can encode using:
 
Convert.ToBase64String(Encoding.ASCII.GetBytes(plainText));
 
To decode:
 
Encoding.ASCII.GetString(Convert.FromBase64String(base64Encoded));
 
 
 
---
