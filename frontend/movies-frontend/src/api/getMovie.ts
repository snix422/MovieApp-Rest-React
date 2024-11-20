import { apiClient } from "./axiosConfig"

export const getMovie = async (id:any) => {
    try {
        const res = await apiClient.get(`/Movie/movie/${id}`);
        return res.data;
    } catch (error) {
        throw Error("Nie udało się znaleźć filmu. Przepraszamy za utrudnienia")
    }
}