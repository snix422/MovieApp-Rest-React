import { ClipLoader } from 'react-spinners';
import '../styles/LoadingSpinner.css';

const LoadingSpinner = () => {
  return (
    <div className="spinner-container">
      <ClipLoader size={50} color="#123abc" loading={true} />
    </div>
  );
};

export default LoadingSpinner;
