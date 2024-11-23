import { useEffect, useState } from "react";
import { useParams } from "react-router-dom"
import { getMoviesByCategory } from "../api/getMoviesByCategory";

const CategoryPage = () => {
    const {categoryName} = useParams();
    const [categoryMovies , setCategoryMovies] = useState();
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
            } catch (error) {
                setLoading(false);
                setError(error)
            }
           
        }

        fetchData();
    },[])

    console.log(categoryMovies)
    return(
        <main>
            <h1>Kategoria: {categoryName} </h1>
        </main>
    )
}

export default CategoryPage