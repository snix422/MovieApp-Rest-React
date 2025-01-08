import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom"
import { getMoviesByCategory } from "../api/getMoviesByCategory";
import MoviesList from "../components/MoviesList";

const CategoryPage = () => {
    const {categoryName} = useParams();
    const [categoryMovies , setCategoryMovies] = useState();
    const [movies,setMovies] = useState<any>()
    const [loading , setLoading] = useState(true);
    const [error,setError] = useState<any>(null)

    useEffect(()=>{
        const fetchData =  async () =>{

            if(!categoryName) return

            try {
                const res = await getMoviesByCategory(categoryName);
                console.log(res);
                setLoading(false);
                setError(null) 
                setCategoryMovies(res[0])
                setMovies(res[0].movies)
            } catch (error) {
                setLoading(false);
                setError(error)
            }
           
        }

        fetchData();
    },[])

    console.log(categoryMovies)
    console.log(movies);
    return(
        <main>
            <h1>Kategoria: {categoryName} ({movies?.length}) </h1>
            <MoviesList movies={movies} />
            <Link to={`/`}>Powrót na stronę główną</Link>
        </main>
    )
}

export default CategoryPage