import React, { Component } from "react";
import CartItem from "../components/CartItem";
import axios from "axios";

class ShoppingCart extends Component {
  state = {
    shoppingCart: {
      cartId: null,
      items: [],
      discounts: [],
      totalPrice: 0.0,
    },

    loading: false,
    error: null,
  };

  componentDidMount() {
    let cartId = localStorage.getItem("cart-id");

    let apiCall;

    if (!cartId) {
      apiCall = axios.post("api/shopping-carts");
    } else {
      apiCall = axios.get(`api/shopping-carts/${cartId}`);
    }

    apiCall
      .then((res) => {
        localStorage.setItem("cart-id", res.data.cartId);
        this.setState({ shoppingCart: res.data });
      })
      .catch((err) => {
        this.setState({ error: err.message });
      });
  }

  itemQtyDecreasedHandler = (item_id) => {
    axios
      .delete(
        `api/shopping-carts/${this.state.shoppingCart.cartId}/items/${item_id}`
      )
      .then((res) => {
        this.setState({ shoppingCart: res.data });
      });
  };

  itemQtyIncreasedHandler = (item_id) => {
    axios
      .post(
        `api/shopping-carts/${this.state.shoppingCart.cartId}/items/${item_id}`
      )
      .then((res) => {
        this.setState({ shoppingCart: res.data });
      });
  };

  render() {
    return (
      <>
        <h2 className="h3">Shopping Cart</h2>
        {this.state.shoppingCart.items.map((item) => (
          <CartItem
            key={item.id}
            item={item}
            itemQtyDecreased={() => this.itemQtyDecreasedHandler(item.id)}
            itemQtyIncreased={() => this.itemQtyIncreasedHandler(item.id)}
          />
        ))}
      </>
    );
  }
}

export default ShoppingCart;
