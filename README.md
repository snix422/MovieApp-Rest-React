# 🎬 Movie Explorer

**Movie Explorer** is a fullstack application that allows users to browse movies, filter by category, search by title, and view top-rated films.

---

## 🛠 Tech Stack

### Frontend – [React](https://reactjs.org/) + TypeScript
- ⚛️ React
- 🧠 TypeScript
- 🌍 React Router DOM
- 🔄 React Query (for data fetching and caching)
- 🎨 **Plain CSS files** for styling (no CSS-in-JS)
- 📁 Modular component structure

### Backend – [.NET (ASP.NET Core)](https://dotnet.microsoft.com/)
- 🌐 RESTful Web API
- 🗃 Entity Framework Core (for database operations)
- 🛡 Custom middleware for error handling & logging
- 🔎 Support for filtering, searching, and top-rated queries

---

## 🚀 Features

- 🔍 Search movies by name
- 🏷 Filter movies by category
- ⭐ View top-rated movies
- 🎬 See detailed information about each movie (title, genre, director, studio, budget)
- 💬 View reviews per movie
- 🔄 Loading spinners
- ❌ Error handling (404, 500)

---

## 📦 Installation

### 1. Backend (.NET)
```bash
cd backend
dotnet restore
dotnet build
dotnet run
```
### 2. Frontend (React + Typescript)
```bash
cd frontend
npm install
npm run dev


