# SignalR Chat Application with Authentication

## Overview
This is a **real-time chat application** built using **ASP.NET Core**, **SignalR**, and **Razor Pages**. It includes user authentication, message persistence, and a responsive UI.

## Features
- **Real-time messaging** using SignalR
- **User authentication** with Identity (Login/Register)
- **Message storage** using Entity Framework Core and SQLite
- **Bootstrap-based UI** for responsiveness

## Installation & Setup

### 1. Clone the Repository
```sh
git clone https://github.com/your-repo/chat-app.git
cd chat-app
```

### 2. Install Dependencies
Ensure you have .NET installed, then restore dependencies:
```sh
dotnet restore
```

### 3. Update Database
Apply migrations to create the database:
```sh
dotnet ef database update
```

### 4. Run the Application
```sh
dotnet run
```
Then, open `http://localhost:5000` in your browser.

## Authentication Setup
- The app uses **ASP.NET Identity** for user management.
- Users must register before accessing the chat.
- Login/Register buttons appear dynamically in the UI (`_Layout.cshtml`).

## SignalR Configuration
The SignalR client connects to `/chatHub`:
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.start()
    .then(() => console.log("Connected to SignalR"))
    .catch(err => console.error("Error connecting: ", err));
```

## Technologies Used
- **ASP.NET Core** (Razor Pages)
- **SignalR** for real-time communication
- **Entity Framework Core** (SQLite for data storage)
- **ASP.NET Identity** for authentication
- **Bootstrap** for styling

## Contributing
Feel free to submit issues or pull requests.

## License
MIT License

# SignalRChat