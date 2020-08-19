import React, { Component } from "react";
import CartItem from "../components/CartItem";
import CartSideBar from "../components/CartSideBar";
import axios from "axios";
import Product from "../components/Product";


class ShoppingCart extends Component {
  state = {
    shoppingCart: {
      cartId: null,
      items: [],
      discounts: [],
      totalPrice: 0.0,
    },
    products: [],
    loading: false,
    error: null,
  };

  componentDidMount() {
    this.getProducts();
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

  getProducts = () => {
    axios.get("api/items")
      .then(res => {
        this.setState({ products: res.data});
      })
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

  cartItemsClearedHandler = () => {
    axios
    .delete(
      `api/shopping-carts/${this.state.shoppingCart.cartId}/items`
    )
    .then((res) => {
      this.setState({ shoppingCart: res.data });
    });
  }

  render() {
    return (
      <>
        <div className="row">
          <div className="col-md-9">
            {this.state.shoppingCart.items.map((item) => (
              <CartItem
                key={item.id}
                item={item}
                itemQtyDecreased={() => this.itemQtyDecreasedHandler(item.id)}
                itemQtyIncreased={() => this.itemQtyIncreasedHandler(item.id)}
              />
            ))}
          </div>

          <div className="col-md-3">
            <CartSideBar
              totalPrice={this.state.shoppingCart.totalPrice}
              discounts={this.state.shoppingCart.discounts}
              cartItemsCleared={this.cartItemsClearedHandler}
            />
          </div>
        </div>

        <div className="row">
          {this.state.products?.map(item => (
            <div className="col-12 mb-2" key={item.id}>
              <Product
                item={item}
                itemAddedToCart={() => this.itemQtyIncreasedHandler(item.id)}
              />
            </div>
          ))}
        </div>
      </>
    );
  }
}

export default ShoppingCart;
