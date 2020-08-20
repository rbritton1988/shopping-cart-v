import React from 'react';

const Receipt = (props) => {
	return (
		<div className="modal fade" id="staticBackdrop" data-backdrop="static" data-keyboard="false" aria-labelledby="staticBackdropLabel" aria-hidden="true">
			<div className="modal-dialog modal-xl">
				<div className="modal-content">
					<div className="modal-header">
						<h5 className="modal-title" id="staticBackdropLabel">Receipt</h5>
						<button type="button" className="close" data-dismiss="modal" aria-label="Close" onClick={props.closed}>
							<span aria-hidden="true">&times;</span>
						</button>
					</div>
					<div className="modal-body">
						<h6>Products</h6>
						<table className="table">
							<thead>
								<tr>
									<th scope="col">#</th>
									<th scope="col">Item</th>
									<th scope="col">Unit Price</th>
									<th scope="col">Qty</th>
									<th scope="col">Sub-total</th>
								</tr>
							</thead>
							<tbody>
								{props.order?.items.map((item) => (
									<tr key={item.id}>
										<th scope="row">{item.id}</th>
										<td>{item.name}</td>
										<td>£{item.price}</td>
										<td>{item.quantity}</td>
										<td>£{item.price * item.quantity}</td>
									</tr>
								))}
							</tbody>
						</table>

						<h6>Discounts</h6>
						<table className="table">
							<thead>
								<tr>
									<th scope="col">Code</th>
									<th scope="col">Reduction (%)</th>
								</tr>
							</thead>
							<tbody>
								{props.order?.discounts.map((discount) => (
									<tr key={discount.code}>
										<th scope="row">{discount.code}</th>
										<td>{discount.percentage.toFixed(2)}</td>
									</tr>
								))}
							</tbody>
						</table>
						<hr />

						<h3 className="block text-right mr-3">Total: £{props.order.totalPrice.toFixed(2)}</h3>
					</div>
					<div className="modal-footer">
						<button type="button" className="btn btn-secondary" data-dismiss="modal" onClick={props.closed}>Close</button>
					</div>
				</div>
			</div>
		</div>
	);
}
 
export default Receipt;