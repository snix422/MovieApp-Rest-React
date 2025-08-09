import CategoryList from './CategoryList';
import SearchActions from './SearchActions';

const Navbar = () => {
  return (
    <nav>
      <SearchActions />
      <CategoryList />
    </nav>
  );
};

export default Navbar;
