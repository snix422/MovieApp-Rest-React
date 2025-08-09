import { useMovies } from '../hooks/useMovies';
import LoadingSpinner from './LoadingSpinner';
import MoviesList from './MoviesList';

const MoviesContainer = () => {
  const { movies, isLoading, error } = useMovies();

  if (isLoading) {
    return <LoadingSpinner />;
  }

  if (error) {
    return <p>Wystąpił błąd podczas pobierania filmów: {error.message}</p>;
  }

  if (!movies || movies.items.length === 0) {
    return <p>Brak filmów do wyświetlenia.</p>;
  }

  return (
    <div>
      <h2>Najlepiej oceniane filmy:</h2>
      <MoviesList movies={movies.items} isLoading={isLoading} error={error} />
    </div>
  );
};

export default MoviesContainer;
