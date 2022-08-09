import * as React from 'react';

import ProductListMain from './product-list-main';
import CategoriesList from './сategories-list';
import IProductItemProps from './props/basket-props';

require('./app.css');

class Main extends React.Component<IProductItemProps, {category: string | null}> {
  constructor(props: IProductItemProps) {
    super(props);
    this.state = { category: null };
    this.onCategoryChange = this.onCategoryChange.bind(this);
  }
  private onCategoryChange(category: string) {
    this.setState({ category: category });
  }
  public render(): React.ReactNode {
    return (
      <div id="main">
        <CategoriesList onCategoryChange={this.onCategoryChange} isBasket={this.props.isBasket} onLeaveFromBasket={this.props.onLeaveFromBasket} />
        <ProductListMain
          currentCategory={this.state.category}
          isBasket={this.props.isBasket}
        />
      </div>
    );
  }
}

export default Main;

