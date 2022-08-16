import React from 'react';

import ProductList from './product-list';
import IAppProps from './props/main-props';

require('./app.css');

class ProductListMain extends React.Component<IAppProps> {
  constructor(props: IAppProps) {
    super(props);
    this.state = {};
  }
  public render(): React.ReactNode {
    return (
      <div id='productList'>
        <div className='contentLable'>{
          this.props.isBasket ? 'Товары в Корзине' : this.props.category == null ? 'Выберите категорию' : `Товары магазина категории: ${this.props.category}`}
        </div>
        <ProductList
          category={this.props.category}
          isBasket={this.props.isBasket}
        />
      </div>
    );
  }
}

export default ProductListMain;