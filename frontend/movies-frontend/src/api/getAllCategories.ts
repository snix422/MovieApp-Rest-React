import { apiClient } from "./axiosConfig"

export const getAllCategories =  async () => {
    try {
        const res = await apiClient.get("/Category");
    return res.data
    } catch (error) {
        throw error
    }
   
}