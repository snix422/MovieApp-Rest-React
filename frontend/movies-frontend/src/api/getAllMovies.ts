import { apiClient } from "./axiosConfig"

export const getAllMovies = async () => {
    try {
        const res = await apiClient.get("/Movie");
        return res.data;
    } catch (error) {
        throw Error("Wystąpił problem z pobieraniem danych")
    }
}