import React from 'react';
import { autobind } from 'core-decorators';

import { getProductsByCategory, getUserBasket } from './api';
import ProductItem from './product-item';
import IProductInfo from './types/product-info';
import IBasketCurrentCategoryProps from './props/basket-current-category-props';

require('./app.css');

@autobind
class ProductList extends React.Component<IBasketCurrentCategoryProps, { products: Array<IProductInfo> }> {
  constructor(props: IBasketCurrentCategoryProps) {
    super(props);
    this.state = { products: [] };
    this.updateProducts = this.updateProducts.bind(this);
  }
  public async componentWillReceiveProps(nextProps: { isBasket: boolean; currentCategory: string }) {
    if (this.props.currentCategory !== nextProps.currentCategory ||
      this.props.isBasket !== nextProps.isBasket) {
      await this.updateProducts();
    }
  }
  private async updateProducts() {
    try {
      /* Почти вся эта функция - костыль если его убрать начинается дичь, вероятна из за асинхронности.*/
      let products: Array<IProductInfo> = [];
      const productsBasket = await getUserBasket();
      const category: string = this.props.currentCategory ? this.props.currentCategory : 'Phone';
      const productsStore = await getProductsByCategory(category);
      products = this.props.isBasket ? productsBasket : productsStore;
      this.setState({ products: products });
    }
    catch (error) {
      alert(error.message);
    }
  }
  public render(): React.ReactNode {
    const listItems = this.state.products.map(p => <ProductItem key={p.Product.Id} value={p} isBasket={this.props.isBasket} updateProducts={this.updateProducts} />);
    return (
      <div id="categories">
        {listItems}
      </div>
    );
  }
}

export default ProductList;