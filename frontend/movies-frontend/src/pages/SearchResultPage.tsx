import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { getMovieByQuery } from "../api/getMovieByQuery";
import MoviesList from "../components/MoviesList";

const SearchResultPage = () => {

    const location = useLocation();
    const query : any = new URLSearchParams(location.search).get("query");

        const [movies,setMovies] = useState<any>([]);
        const [loading, setLoading] = useState(true);
        const [error, setError] = useState(""); 
    
        useEffect(()=>{
            const fetchMovies = async () => {
                try {
                  const moviesData = await getMovieByQuery(query); // Wywołanie funkcji do pobrania filmów
                  setMovies(moviesData); // Ustawienie danych w stanie
                  setLoading(false); // Zakończenie ładowania
                } catch (err) {
                  setError("Wystąpił problem z pobraniem danych"); // Ustawienie błędu, jeśli coś pójdzie nie tak
                  setLoading(false); // Zakończenie ładowania, nawet jeśli wystąpił błąd
                }
              };
          
              fetchMovies(); 
        },[])
console.log(movies)
    return(
        <div>
            <h1>Wyniki wyszukiwania dla: {query} ({movies.length})</h1>
            {movies ? <MoviesList movies={movies} error={error} isLoading={loading} /> : null}
        </div>
    )
}

export default SearchResultPage