import { useQuery } from "@tanstack/react-query"
import { getMovie } from "../api/getMovie"

const useMovie = (id:number) => {
    const {isLoading,error,data} = useQuery({
        queryKey:["movie-query-key"],
        queryFn:() => getMovie(id)
    })

    return{
        movie: data,
        isLoading,
        error
    }
}

export default useMovie