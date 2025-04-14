import { Link, useParams } from "react-router-dom"
import MoviesList from "../components/MoviesList";
import useMoviesByCategoryName from "../hooks/useMoviesByCategoryName";
import "../styles/CategoryPage.css"
import LoadingSpinner from "../components/LoadingSpinner";

const CategoryPage = () => {
    const { categoryName } = useParams();
    const { movies, isLoading, error } = useMoviesByCategoryName(String(categoryName));
  
    if (isLoading) {
      return <LoadingSpinner />;
    }
  
    if (error) {
      return <p className="error">Wystąpił błąd podczas ładowania filmów.</p>;
    }
  
    if (!movies || movies.length === 0) {
      return (
        <div className="no-results">
          <h2>Brak filmów w kategorii: <strong>{categoryName}</strong></h2>
          <Link to="/" className="back-link">Powrót na stronę główną</Link>
        </div>
      );
    }
  
    return (
      <main className="category-page">
        <h1 className="category-title">
          Kategoria: <span className="capitalize">{categoryName}</span> ({movies.length})
        </h1>
        <MoviesList movies={movies} />
        <div className="go-back">
          <Link to="/" className="back-link">Powrót na stronę główną</Link>
        </div>
      </main>
    );
  };
  
  export default CategoryPage;