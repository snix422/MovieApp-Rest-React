import React from 'react';
import logo from './logo.svg';
import './App.css';
import MoviesContainer from './components/MoviesContainer';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import MoviePage from './pages/MoviePage';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<MoviesContainer />} />
          <Route path='/movie/:id' element={<MoviePage />} />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
