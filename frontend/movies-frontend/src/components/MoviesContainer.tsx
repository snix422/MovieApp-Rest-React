import { useMovies } from "../hooks/useMovies"
import MoviesList from "./MoviesList";
import CategoryList from "./CategoryList";
import SearchActions from "./SearchActions";

const MoviesContainer = () => {

    const {movies, isLoading , error} = useMovies();

    return(
        <div>
            <SearchActions />
            <CategoryList />
            <h2>Najlepiej oceniane filmy:</h2>
            <MoviesList movies={movies.items} isLoading={isLoading} error={error}  />
        </div>
    )

}

export default MoviesContainer