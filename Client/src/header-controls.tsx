import React from 'react';
import { NavLink } from 'react-router-dom';
import autobind from 'autobind-decorator';

import ThemControl from './them-control';
import IHeaderProps from './props/header-props';

require('./app.css');

@autobind
class HeaderControls extends React.Component<IHeaderProps> {
  constructor(props: IHeaderProps) {
    super(props);
  }
  public render(): React.ReactNode {
    return (
      <div id='controls'>
        <NavLink to={this.props.isBasket ? '/' : '/basket'} >{this.props.isBasket ? 'Выйти из корзины' : 'Войти в корзину'}</NavLink>
        <ThemControl />
      </div>
    );
  }
}
export default HeaderControls;