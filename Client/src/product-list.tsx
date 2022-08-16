import React from 'react';
import { autobind } from 'core-decorators';

import { getProductsByCategory, getUserBasket } from './api';
import ProductItem from './product-item';
import IProductInfo from './types/product-info';
import IAppProps from './props/main-props';

require('./app.css');

@autobind
class ProductList extends React.Component<IAppProps, { products: Array<IProductInfo> }> {
  constructor(props: IAppProps) {
    super(props);
    this.state = { products: [] };
  }
  public async componentDidMount() {
    await this.updateProducts();
  }
  public async componentWillReceiveProps(nextProps: IAppProps) {
    if (this.props.category !== nextProps.category || this.props.isBasket !== nextProps.isBasket)
      await this.updateProducts(nextProps.isBasket, nextProps.category);
  }
  private async updateProducts(isBasket: boolean = this.props.isBasket, category: string | null = this.props.category) {
    try {
      if (isBasket) {
        const productsBasket = await getUserBasket();
        this.setState({ products: productsBasket });
      }
      else {
        if (category == null) {
          this.setState({ products: [] });
        }
        else {
          const categoryStr = category != null ? category : '';
          const productsStore = await getProductsByCategory(categoryStr);
          this.setState({ products: productsStore });
        }
      }
    }
    catch (error) {
      alert(error.message);
    }
  }
  public render(): React.ReactNode {
    const listItems = this.state.products.map(p => <ProductItem key={p.Product.Id} value={p} isBasket={this.props.isBasket} category={this.props.category} updateProducts={this.updateProducts} />);
    return (
      <div id='categories'>
        {listItems}
      </div>
    );
  }
}

export default ProductList;
