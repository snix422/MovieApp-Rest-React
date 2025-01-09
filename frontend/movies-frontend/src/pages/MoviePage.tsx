import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { getMovie } from "../api/getMovie";

const MoviePage = () => {
    const {id} = useParams();
    const [movie,setMovie] = useState<any>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(""); 

    useEffect(()=>{
        const fetchMovies = async () => {
            try {
                const moviesData = await getMovie(id);
                setMovie(moviesData); 
                setLoading(false); 
              } catch (err) {
                setError("Wystąpił problem z pobraniem danych"); 
                setLoading(false);
              }
            };

            if(id){
                fetchMovies()
            }
        
    },[id])

    console.log(movie)

    if(error){
        return(
            <main>
                <h1>{error}</h1>
            </main>
        )
    }

    if(loading){
        return(
            <main>
                <h2>Ładowanie...</h2>
            </main>
        )
    }

    return(
        <main>
            <h2>{movie.title}</h2>
            <h3>{movie.genre}</h3>
            <h3>{movie.director}</h3>
        </main>
    )
}

export default MoviePage