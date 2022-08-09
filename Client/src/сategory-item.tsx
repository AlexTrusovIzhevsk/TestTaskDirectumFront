import * as React from 'react';

import IBasketCategoryItemProps from './props/basket-category-item-props';

require('./app.css');

class CategoryItem extends React.Component<IBasketCategoryItemProps, {}> {
  constructor(props: IBasketCategoryItemProps) {
    super(props);
    this.handleChange = this.handleChange.bind(this);
  }
  private handleChange(e: {}) {
    this.props.onCategoryChange(this.props.value);
    if (this.props.isBasket) {
      this.props.onLeaveFromBasket();
    }
  }
  public render(): React.ReactNode {
    return (
      <li><a onClick={this.handleChange}>{this.props.value}</a></li>
    );
  }
}

export default CategoryItem;