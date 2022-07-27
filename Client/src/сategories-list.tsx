import * as React from 'react';

import { autobind } from 'core-decorators';

import CategoryItem from './сategory-item';
import { getCategories } from './api';

require('./app.css');

@autobind
class CategoriesList extends React.Component<{ isBasket: boolean; onCategoryChange: (category: string) => void; onLeaveFromBasket: () => void}, {categories: Array<string>}> {
  constructor(props: { isBasket: boolean; onCategoryChange: () => void; onLeaveFromBasket: () => void}) {
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
        value={category}
        onCategoryChange={this.props.onCategoryChange}
        isBasket={this.props.isBasket}
        onLeaveFromBasket={this.props.onLeaveFromBasket}
      />
    );
    return (
      <div id="categoriesList">
        <ul>
          {listItems}
        </ul>
      </div>
    );
  }
}

export default CategoriesList;