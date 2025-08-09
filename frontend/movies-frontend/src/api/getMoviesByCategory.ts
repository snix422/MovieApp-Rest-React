import { apiClient } from './axiosConfig';

export const getMoviesByCategory = async (categoryName: string) => {
  const res = await apiClient.get(`/movie/category/${categoryName}`);
  return res.data;
};
