import React from 'react';

const Product = (props) => {
	return (  
		<div className="card">
			<div className="card-body">
				<h5 className="card-title">{props.item.name}</h5>
				<p className="card-text">{props.item.description}</p>
				<p><b>£{props.item.price}</b></p>
				<button type="button" className="btn btn-primary" onClick={props.itemAddedToCart}>ADD TO CART</button>
			</div>
		</div>
	);
}
 
export default Product;