import { useQuery } from '@tanstack/react-query';
import { getMoviesByCategory } from '../api/getMoviesByCategory';

const useMoviesByCategoryName = (categoryName: string) => {
  const {
    data: movies,
    isLoading,
    error,
  } = useQuery({
    queryKey: ['movies-by-category', categoryName],
    queryFn: () => getMoviesByCategory(categoryName),
  });

  return {
    movies,
    isLoading,
    error,
  };
};

export default useMoviesByCategoryName;
