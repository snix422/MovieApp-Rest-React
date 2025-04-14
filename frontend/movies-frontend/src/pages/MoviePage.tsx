import { Link, useParams } from "react-router-dom"
import ReviewItem from "../components/ReviewItem";
import "../styles/MoviePage.css"
import useMovie from "../hooks/useMovie";
import ActorsList from "../components/ActorsList";
import LoadingSpinner from "../components/LoadingSpinner";

const MoviePage = () => {
    const { id } = useParams();
    const { isLoading, error, movie } = useMovie(Number(id));
    console.log(movie)
    if (error) {
      return (
        <main className="movie-error">
          <h1>Wystąpił błąd: {error.message}</h1>
          <Link to="/" className="back-link">Powrót na stronę główną</Link>
        </main>
      );
    }
  
    if (isLoading) {
      return (
        <main className="movie-loading">
          <LoadingSpinner />
        </main>
      );
    }
  
    if (!movie) {
      return (
        <main className="movie-not-found">
          <h2>Nie znaleziono filmu.</h2>
          <Link to="/" className="back-link">Powrót na stronę główną</Link>
        </main>
      );
    }
  
    return (
      <main className="movie-details">
        <img className="movie-img" src={movie.imageUrl} alt={movie.title} />
  
        <div className="movie-info">
          <h2 className="movie-title">Nazwa: {movie.title}</h2>
          <h3 className="movie-genre">Kategoria: {movie.categoryName}</h3>
          <h3 className="movie-director">Reżyser: {movie.directorName} {movie.directorSurname}</h3>
          <h4 className="movie-studio">
            Wytwórnia: {movie.studio || "Brak danych"}
          </h4>
          <h4 className="movie-budget">
            Budżet filmu: {movie.budget} $
          </h4>
        </div>
        <ActorsList actors={movie.actors} />
        <div className="movie-reviews">
          <h2 className="reviews-title">Opinie:</h2>
          {movie.reviews.length > 0 ? (
            movie.reviews.map((review: any, index: number) => (
              <ReviewItem key={index} data={review} />
            ))
          ) : (
            <p className="no-reviews">Brak opinii dla tego filmu.</p>
          )}
        </div>
  
        <Link to="/" className="back-link">Powrót na stronę główną</Link>
      </main>
    );
  };
  
  export default MoviePage;