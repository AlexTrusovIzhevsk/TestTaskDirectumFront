import React from 'react';

import HeaderControls from './header-controls';
import IBasketItemProps from './props/basket-item-props';
import storeLogo from './logo.png';

require('./app.css');

class Header extends React.Component<IBasketItemProps,{}> {
  constructor(props: IBasketItemProps) {
    super(props);
    this.state = {};
  }
  public render() {
    return (
      <React.Fragment>
        <div id='header'>
          <StoreLogo />
          <Title />
          <HeaderControls isBasket={this.props.isBasket} onGoToBasket={this.props.onGoToBasket} onLeaveFromBasket={this.props.onLeaveFromBasket} />
        </div>
      </React.Fragment>
    );
  }
}

function StoreLogo() {
  return (
    <React.Fragment>
      <img id="StoreLogo" src={storeLogo} alt="Здесь будет Лого" />
    </React.Fragment>
  );
}

function Title() {
  return (
    <React.Fragment>
      <div id="title">Компьютерная техника</div>
    </React.Fragment>
  );
}

export default Header;
