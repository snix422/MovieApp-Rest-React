import { useLocation, useNavigate } from 'react-router-dom';
import '../styles/Pagination.css';

interface PaginationProps {
  totalPages: number;
  currentPage: number;
}

const Pagination: React.FC<PaginationProps> = ({ totalPages, currentPage }) => {
  const pages = Array.from({ length: totalPages }, (_, i) => i + 1);
  const navigate = useNavigate();
  const location = useLocation();

  const handlePageChange = (page: number) => {
    const searchParams = new URLSearchParams(location.search);
    searchParams.set('page', String(page));
    navigate(`${location.pathname}?${searchParams.toString()}`);
  };

  return (
    <div className="pagination">
      {pages.map(page => (
        <button
          key={page}
          onClick={() => handlePageChange(page)}
          className={page == currentPage ? 'active' : ''}
        >
          {page}
        </button>
      ))}
    </div>
  );
};

export default Pagination;
