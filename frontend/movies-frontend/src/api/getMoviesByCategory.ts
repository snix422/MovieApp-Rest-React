import { apiClient } from "./axiosConfig"

export const getMoviesByCategory = async (categoryName:string) => {
    try {
        const res = await apiClient.get(`/categories/${categoryName}`)
        return res.data
    } catch (error) {
        throw error
    }
}