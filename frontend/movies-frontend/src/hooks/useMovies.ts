import { getAllMovies } from '../api/getAllMovies';
import { useQuery } from '@tanstack/react-query';

export const useMovies = () => {
  const { isLoading, error, data } = useQuery({
    queryKey: ['movies-query-key'],
    queryFn: getAllMovies,
  });

  return { isLoading, error, movies: data || [] };
};
