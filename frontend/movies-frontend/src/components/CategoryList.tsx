import { useState, useEffect } from 'react';
import { getAllCategories } from '../api/getAllCategories';
import { useNavigate } from 'react-router-dom';
import '../styles/CategoryList.css';

const CategoryList = () => {
  const [categories, setCategories] = useState([]);

  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  const navigate = useNavigate();

  useEffect(() => {
    const fetchMovies = async () => {
      try {
        const categoriesData = await getAllCategories();
        setCategories(categoriesData);
        setLoading(false);
      } catch (err) {
        setError('Wystąpił problem z pobraniem danych');
        setLoading(false);
      }
    };

    fetchMovies();
  }, []);

  const handleBtnClick = (categoryName: string) => {
    navigate(`categories/${categoryName}`);
  };

  return (
    <div>
      {error && <span>{error}</span>}
      {!error && loading ? (
        <span>Ładowanie ...</span>
      ) : categories ? (
        categories.map((c: any) => {
          return (
            <button key={c.id} onClick={() => handleBtnClick(c.name)}>
              {c.name}
            </button>
          );
        })
      ) : null}
    </div>
  );
};

export default CategoryList;
