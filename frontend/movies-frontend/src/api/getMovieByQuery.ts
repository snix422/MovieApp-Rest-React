import { apiClient } from './axiosConfig';

export const getMovieByQuery = async (query: string, currentPage: number) => {
  const res = await apiClient.get(`/movie?searchPhrase=${query}&pageNumber=${currentPage}`);
  return res.data;
};
