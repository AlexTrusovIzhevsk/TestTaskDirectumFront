import React from 'react';
import { autobind } from 'core-decorators';

import CategoryItem from './сategory-item';
import { getCategories } from './api';
import IHeaderProps from './props/header-props';

require('./app.css');

@autobind
class CategoriesList extends React.Component<IHeaderProps, {categories: Array<string>}> {
  constructor(props: IHeaderProps) {
    super(props);
    const categories: Array<string> = [];
    this.state = { categories: categories };
  }
  public async componentDidMount() {
    try {
      const categories: Array<string> = await getCategories();
      this.setState({ categories: categories });
    }
    catch (error) {
      alert(error.message);
    }
  }
  public render(): React.ReactNode {
    const listItems = this.state.categories.map(category =>
      <CategoryItem
        key={category}
        category={category}
        isBasket={this.props.isBasket}
      />
    );
    return (
      <div id='categoriesList'>
        <ul>
          {listItems}
        </ul>
      </div>
    );
  }
}

export default CategoriesList;