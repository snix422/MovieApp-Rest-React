import React from 'react';
import logo from './logo.svg';
import './App.css';
import MoviesContainer from './components/MoviesContainer';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import MoviePage from './pages/MoviePage';
import CategoryPage from './pages/CategoryPage';
import SearchResultPage from './pages/SearchResultPage';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<MoviesContainer />} />
          <Route path='/movie/:id' element={<MoviePage />} />
          <Route path='/categories/:categoryName' element={<CategoryPage />} />
          <Route path='/search' element={<SearchResultPage />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
