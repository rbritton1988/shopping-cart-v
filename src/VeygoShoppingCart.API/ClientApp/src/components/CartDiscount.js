import React from 'react';

const CartDiscount = (props) => {
	return (
		<p className="pl-4">{props.discount.code}: -{props.discount.percentage * 100}%</p>
	);
}
 
export default CartDiscount;