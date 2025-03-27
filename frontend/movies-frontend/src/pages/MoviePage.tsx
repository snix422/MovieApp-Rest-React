import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom"
import { getMovie } from "../api/getMovie";
import ReviewItem from "../components/ReviewItem";
import "../styles/MoviePage.css"
import useMovie from "../hooks/useMovie";

const MoviePage = () => {
    const {id} = useParams();
    const {isLoading , error, movie} = useMovie(Number(id))
    /*const [movie,setMovie] = useState<any>(null);
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
        
    },[id])*/

    console.log(movie)

    if(error){
        return(
            <main>
                <h1>{error.message}</h1>
            </main>
        )
    }

    if(isLoading){
        return(
            <main>
                <h2>Ładowanie...</h2>
            </main>
        )
    }

    return(
        <main className="movie-details">
    <img className="movie-img" src={movie.imgUrl} alt={movie.title} />
    <div className="movie-info">
        <h2 className="movie-title">Nazwa: {movie.title}</h2>
        <h3 className="movie-genre">Kategoria: {movie.genre}</h3>
        <h3 className="movie-director">Reżyser: {movie.director}</h3>
        <h4 className="movie-studio">Wytwórnia: {movie.productionDetails.studio}</h4>
        <h5 className="movie-budget">Budżet filmu: {movie.productionDetails.budget} $</h5>
    </div>
    <div className="movie-reviews">
        <h2 className="reviews-title">Opinie:</h2>
        {movie.reviews.map((m: any, index: number) => (
            <ReviewItem key={index} data={m} />
        ))}
    </div>
    <Link className="link" to={"/"}>Powrót na stronę główną</Link>
</main>
    )
}

export default MoviePage