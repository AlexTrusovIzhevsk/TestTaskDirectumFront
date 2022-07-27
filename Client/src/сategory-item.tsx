import * as React from 'react';

require('./app.css');

class CategoryItem extends React.Component<{ isBasket: boolean; value: string ; onLeaveFromBasket: () => void; onCategoryChange: (Category: string) => void }, {}> {
  constructor(props: { isBasket: boolean; value: string ; onLeaveFromBasket: () => void; onCategoryChange: (Category: string) => void }) {
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