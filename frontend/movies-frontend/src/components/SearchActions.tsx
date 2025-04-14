import { useState } from "react"
import { useNavigate } from "react-router-dom"
import "../styles/SearchActions.css"

const SearchActions = () => {
    const [searchInput, setSearchInput] = useState<string>("")

    const navigate = useNavigate()

    const handleSearch = () => {
        if (searchInput.trim()) {
            navigate(`/search?query=${encodeURIComponent(searchInput.trim())}&page=1`);
        }
    }

    return(
        <div>
            <input value={searchInput} onChange={(e:any)=>setSearchInput(e.target.value)} placeholder="Wpisz tytuł filmu" />
            <button onClick={handleSearch}>Wyszukaj film</button>
        </div>
    )
}

export default SearchActions