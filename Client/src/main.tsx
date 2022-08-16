import * as React from 'react';
import autobind from 'autobind-decorator';

import ProductListMain from './product-list-main';
import CategoriesList from './сategories-list';
import IAppProps from './props/main-props';

require('./app.css');

@autobind
class Main extends React.Component<IAppProps> {
  constructor(props: IAppProps) {
    super(props);
  }
  public render(): React.ReactNode {
    return (
      <div id='main'>
        <CategoriesList isBasket={this.props.isBasket} />
        <ProductListMain category={this.props.category} isBasket={this.props.isBasket} />
      </div>
    );
  }
}

export default Main;
