const ReviewItem = (props:any) => {
    return(
        <div>
            <h3>Autor: {props.data.authorName} </h3>
            <p>{props.data.comment}</p>
        </div>
    )
}

export default ReviewItem