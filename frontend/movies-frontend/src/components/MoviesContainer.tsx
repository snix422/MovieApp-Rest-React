import { useEffect, useState } from "react";
import { useMovies } from "../hooks/useMovies"
import MoviesList from "./MoviesList";
import { getAllMovies } from "../api/getAllMovies";

const MoviesContainer = () => {

    const [movies,setMovies] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(""); 

    useEffect(()=>{
        const fetchMovies = async () => {
            try {
              const moviesData = await getAllMovies(); // Wywołanie funkcji do pobrania filmów
              setMovies(moviesData); // Ustawienie danych w stanie
              setLoading(false); // Zakończenie ładowania
            } catch (err) {
              setError("Wystąpił problem z pobraniem danych"); // Ustawienie błędu, jeśli coś pójdzie nie tak
              setLoading(false); // Zakończenie ładowania, nawet jeśli wystąpił błąd
            }
          };
      
          fetchMovies(); 
    },[])

    console.log(movies);

    return(
        <div>
            <h2>Lista filmów</h2>
            <MoviesList movies={movies} isLoading={loading} error={error}  />
        </div>
    )

}

export default MoviesContainer