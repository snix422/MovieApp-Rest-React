import { Link, useLocation } from "react-router-dom";
import MoviesList from "../components/MoviesList";
import useMovieByQuery from "../hooks/useMoviesByQuery";
import Pagination from "../components/Pagination";
import "../styles/SearchResultPage.css"
import LoadingSpinner from "../components/LoadingSpinner";

const SearchResultPage = () => {
  const location = useLocation();
  const searchParams = new URLSearchParams(location.search);
  const query = searchParams.get("query") || "";
  const currentPage = Number(searchParams.get("page")) || 1;

  const { movies, isLoading, error } = useMovieByQuery(query, currentPage);

  if (isLoading) {
    return <LoadingSpinner />;
  }

  if (error) {
    return <p className="error">Wystąpił błąd podczas pobierania wyników.</p>;
  }

  if (!movies || movies.totalItemsCount === 0) {
    return (
      <div className="no-results">
        <h2>Brak wyników</h2>
        <p>Nie znaleziono żadnych filmów dla zapytania: <strong>{query}</strong></p>
        <Link to="/" className="back-link">Powrót na stronę główną</Link>
      </div>
    );
  }

  return (
    <div className="search-results-container">
      <h2 className="page-title">Wyniki wyszukiwania</h2>

      <p className="search-subtitle">
        {movies.totalItemsCount === 1
          ? `Znaleziono: 1 film`
          : movies.totalItemsCount <= 5
            ? `Znaleziono: ${movies.totalItemsCount} filmy`
            : `Wyświetlane wyniki: ${movies.itemsFrom}–${movies.itemsTo} z ${movies.totalItemsCount}`}
      </p>

      <MoviesList
        movies={movies.items}
        error={error}
        isLoading={isLoading}
      />

      <Pagination totalPages={movies.totalPages} currentPage={currentPage} />

      <div className="go-back">
        <Link to="/" className="back-link">Powrót na stronę główną</Link>
      </div>
    </div>
  );
};

export default SearchResultPage;