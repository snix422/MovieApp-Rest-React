import { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { getMovieByQuery } from "../api/getMovieByQuery";
import MoviesList from "../components/MoviesList";
import useMovieByQuery from "../hooks/useMoviesByQuery";

const SearchResultPage = () => {

    const location = useLocation();
    const query : any = new URLSearchParams(location.search).get("query");

    const { movies , isLoading , error } = useMovieByQuery(query);
    console.log(movies);
    return(
      
        <div>
          {movies && <h1>Wyniki wyszukiwania dla: {query} ({movies.length})</h1> }
          {movies ? <MoviesList movies={movies.items} error={error} isLoading={isLoading} /> : null}
        </div>
      
        
    )
}

export default SearchResultPage