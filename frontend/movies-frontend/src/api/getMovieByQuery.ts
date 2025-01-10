import { apiClient } from "./axiosConfig"

export const getMovieByQuery =  async (query:string) => {
    try {
        const res = await apiClient.get(`/Movie/search?query=${encodeURIComponent(query)}`);
    return res.data
    } catch (error) {
        throw error
    }
   
}