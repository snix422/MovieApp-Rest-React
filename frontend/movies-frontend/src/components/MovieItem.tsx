import { useNavigate } from "react-router-dom"
import "../styles/MovieItem.css"

const MovieItem = ({data}:{data:any}) => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate(`/movie/${data.id}`);
    }
    
    return(
        <div className="movie-item">
            {data.imageUrl ? <img className="img" src={data.imageUrl} alt={data.name} /> : null }
            <h2>{data.title}</h2>
            <h3>{data.genre}</h3>
            <button onClick={handleClick}>Zobacz więcej</button>
        </div>
    )
}

export default MovieItem