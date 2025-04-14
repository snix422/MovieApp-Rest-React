import { useQuery } from "@tanstack/react-query"
import { getMovieByQuery } from "../api/getMovieByQuery"

const useMovieByQuery = (query:string,currentPage:number) => {
    const {data : movies, isLoading , error } = useQuery({
        queryKey:['movies-by-query',query,currentPage],
        queryFn:() => getMovieByQuery(String(query),currentPage)
    }) 

    return {
        movies,
        isLoading,
        error
    }
}

export default useMovieByQuery