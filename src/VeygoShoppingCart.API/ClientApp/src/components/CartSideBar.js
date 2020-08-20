import React, { Component } from 'react';
import CartDiscount from './CartDiscount';


class CartSideBar extends Component {
	state = {
		discountCode: ""
	}

	discountChangedHandler = (event) => {
		event.preventDefault();
		this.setState({discountCode: event.target.value});
	}
	
	render() {
		return (
			<div className="card mb-3 bg-secondary text-light">
				<div className="row no-gutters">
					<div className="card-body">
    				<h6 className="card-title">Discounts Applied</h6>
						<hr />
							
						{this.props.discounts?.map(discount => (
							<CartDiscount 
								key={discount.code}
								discount={discount}
							/>
						))}

						<div className="form-inline">
							<div className="form-group mr-sm-2 mb-2">
								<label htmlFor="inputDiscountCode" className="sr-only">Add Discount Code</label>
								<input type="text" className="form-control" id="inputDiscountCode" placeholder="Discount Code" onChange={this.discountChangedHandler} value={this.state.discountCode} />
							</div>
							<button type="button" className="btn btn-primary mb-2" onClick={() => this.props.discountApplied(this.state.discountCode)} disabled={this.state.discountCode.length === 0}>Apply</button>
						</div>

						<h5 className="card-title">Total: £{this.props.totalPrice.toFixed(2)}</h5>
						<hr />
    				<button type="button" className="btn btn-danger mr-2" onClick={this.props.cartItemsCleared} disabled={this.props.totalPrice === 0}>Clear Cart</button>
						<button type="button" className="btn btn-warning" disabled={this.props.totalPrice === 0} onClick={this.props.cartCheckedOut}>Checkout</button>
  				</div>
				</div>
			</div>
		)
	}
} 
 
export default CartSideBar;