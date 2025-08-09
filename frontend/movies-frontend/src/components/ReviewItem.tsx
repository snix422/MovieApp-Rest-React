import '../styles/ReviewItem.css';

const ReviewItem = (props: any) => {
  return (
    <div className="review-item">
      <h3 className="review-author">Autor: {props.data.authorName}</h3>
      <p className="review-comment">{props.data.comment}</p>
    </div>
  );
};

export default ReviewItem;
