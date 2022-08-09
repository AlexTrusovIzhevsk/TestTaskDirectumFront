import React from 'react';

import ProductList from './product-list';
import IBasketCurrentCategoryProps from './props/basket-current-category-props';

require('./app.css');

class ProductListMain extends React.Component<IBasketCurrentCategoryProps, {}> {
  constructor(props: IBasketCurrentCategoryProps) {
    super(props);
    this.state = {};
  }
  public render(): React.ReactNode {
    return (
      <div id='productList'>
        <div className='contentLable'>{
          this.props.isBasket ? 'Товары в Корзине' : this.props.currentCategory == null ? 'Выберите категорию' : `Товары магазина категории: ${this.props.currentCategory}`}
        </div>
        <ProductList
          currentCategory={this.props.currentCategory}
          isBasket={this.props.isBasket}
        />
      </div>
    );
  }
}

export default ProductListMain;