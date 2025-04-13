import { apiClient } from "./axiosConfig"

export const getMovieByQuery =  async (query:string) => {
    try {
        const res = await apiClient.get(`/movie?searchPhrase=${query}`);
    return res.data
    } catch (error) {
        throw error
    }
   
}