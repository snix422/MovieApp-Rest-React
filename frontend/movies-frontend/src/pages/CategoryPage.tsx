import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom"
import { getMoviesByCategory } from "../api/getMoviesByCategory";
import MoviesList from "../components/MoviesList";
import useMoviesByCategoryName from "../hooks/useMoviesByCategoryName";
const CategoryPage = () => {
    const { categoryName } = useParams();
   
    const { movies , isLoading, error } = useMoviesByCategoryName(String(categoryName))

    console.log(movies);

    return(
        <>
        {movies &&
            <main>
                <h1>Kategoria: {categoryName} ({movies?.length}) </h1>
                <MoviesList movies={movies} />
                <Link to={`/`}>Powrót na stronę główną</Link>
            </main> }
        </>
    )
}
export default CategoryPage