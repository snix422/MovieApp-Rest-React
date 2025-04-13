import MovieItem from "./MovieItem"
import "../styles/MovieList.css"

const MoviesList = ({movies,isLoading,error}: {movies?:any,isLoading?:boolean,error?:any}) => {

    if(error){
        return(
            <div>
                <h1>{error}</h1>
            </div>
        )
    }

    if(isLoading){
        return(
            <div>
                <h2>Ładowanie...</h2>
            </div>
        )
    }

    return(
        <div className="movie-list">
            { movies.length > 0 ? movies?.map((movie:any)=>{
                return(
                    <MovieItem data={movie} />
                )
            }) : null}
        </div>
    )
}

export default MoviesList