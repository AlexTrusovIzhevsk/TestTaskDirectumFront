import React from 'react';
import { NavLink } from 'react-router-dom';
import autobind from 'autobind-decorator';

import IMainProps from './props/main-props';

require('./app.css');

@autobind
class CategoryItem extends React.Component<IMainProps, {}> {
  constructor(props: IMainProps) {
    super(props);
  }
  public render(): React.ReactNode {
    return (
      <NavLink to={this.props.category == null ? '/' : `/category/${this.props.category}`} >{this.props.category}</NavLink>
    );
  }
}

export default CategoryItem;