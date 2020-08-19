import React from "react";

const CartItem = (props) => {
  return (
    <div className="card mb-3">
      <div className="row no-gutters">
        <div className="col-9">
          <div className="card-body">
            <h5 className="card-title">{props.item.name}</h5>
            <p className="card-text">
              <small className="text-muted">Qty: {props.item.quantity}</small>
            </p>
            <hr />
            <div className="btn-group" role="group" aria-label="Basic example">
              <button
                type="button"
                className="btn btn-danger"
                onClick={props.itemQtyDecreased}
              >
                -
              </button>

              <button
                type="button"
                className="btn btn-primary"
                onClick={props.itemQtyIncreased}
              >
                +
              </button>
            </div>
          </div>
        </div>

        <div className="col-3">
          <div className="card-body">
            <p>£{props.item.price}</p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CartItem;
