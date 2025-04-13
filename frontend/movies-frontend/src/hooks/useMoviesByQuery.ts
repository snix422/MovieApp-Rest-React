import { useQuery } from "@tanstack/react-query"
import { getMovieByQuery } from "../api/getMovieByQuery"

const useMovieByQuery = (query?:string) => {
    const {data : movies, isLoading , error } = useQuery({
        queryKey:['movies-by-query'],
        queryFn:() => getMovieByQuery(String(query))
    }) 

    return {
        movies,
        isLoading,
        error
    }
}

export default useMovieByQuery