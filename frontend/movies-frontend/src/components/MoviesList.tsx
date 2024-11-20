import MovieItem from "./MovieItem"

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
        <div>
            {movies?.map((movie:any)=>{
                return(
                    <MovieItem data={movie} />
                )
            })}
        </div>
    )
}

export default MoviesList