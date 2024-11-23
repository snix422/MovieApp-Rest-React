import { useState,useEffect } from "react"
import { getAllCategories } from "../api/getAllCategories";
import { useNavigate } from "react-router-dom";

const CategoryList = () => {

    const [categories,setCategories] = useState([]);

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(""); 

    const navigate = useNavigate();

    useEffect(()=>{
        const fetchMovies = async () => {
            try {
              const categoriesData = await getAllCategories(); // Wywołanie funkcji do pobrania filmów
              setCategories(categoriesData); // Ustawienie danych w stanie
              setLoading(false); // Zakończenie ładowania
            } catch (err) {
              setError("Wystąpił problem z pobraniem danych"); // Ustawienie błędu, jeśli coś pójdzie nie tak
              setLoading(false); // Zakończenie ładowania, nawet jeśli wystąpił błąd
            }
          };
      
          fetchMovies(); 
    },[])

    const handleBtnClick = (categoryName:string) => {
        navigate(`categories/${categoryName}`)
    }

    console.log(categories)
    return(
        <div>
            {categories ? categories.map((c:any)=>{
                return(
                    <button onClick={()=>handleBtnClick(c.name)}>{c.name}</button>
                )
            }): null}
        </div>
    )
}

export default CategoryList