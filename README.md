# CSharp_SwaggerAPI_JWT
API of Employee, integrate with NpgSQL-PostgreSQL and JWT for security the data.

# Documentation:

## Introduction

This repository contains a C# API project that utilizes Swagger for documentation and JWT (JSON Web Token) for authentication and token generation. The project aims to provide a basic framework for building secure and efficiently documented APIs.

## Requirements

- Visual Studio (or any C# compatible IDE)
- .NET Core SDK
- Postman (or another tool for testing APIs)
- Git (for cloning the repository)

## Configuration

1. Clone this repository to your local machine:

```bash
git clone https://github.com/your-username/repository-name.git
```

2. Open the project in Visual Studio or your preferred IDE.

3. Configure the database connection string in the `appsettings.json` file.

4. Run migrations to create the database:

```bash
dotnet ef database update
```

5. Configure the JWT secret key in the `appsettings.json` file:

```json
"JwtSettings": {
  "Key": "YourJwtSecretKey",
  "Issuer": "IssuerName",
  "Audience": "AudienceName",
  "DurationInMinutes": 1440
}
```

6. Build and run the project.

## API Usage

### Authentication

To access the protected endpoints of the API, you need to authenticate and obtain a JWT token.

#### Authentication Route

- **Route**: `/api/auth/login`
- **Method**: POST
- **Request Body**:

```json
{
  "username": "your-username",
  "password": "your-password"
}
```

- **Successful Response**:

```json
{
  "token": "your-jwt-token"
}
```

### Protected Endpoints

The following endpoints are protected by JWT authentication:

#### Example Protected Route

- **Route**: `/api/protected-example`
- **Method**: GET
- **Request Headers**:

```
Authorization: Bearer your-jwt-token
```

### API Documentation with Swagger

Access the API documentation through the route:

- **URL**: `/swagger/index.html`

This will open the Swagger interface where you can explore and test the API endpoints.

## Contributions

Feel free to contribute to this project by submitting pull requests or reporting issues in the "Issues" section.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

Enjoy building your secure and well-documented API with Swagger and JWT in C#. If you have any questions or need assistance, please don't hesitate to reach out. Happy coding!
