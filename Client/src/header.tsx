import React from 'react';

import HeaderControls from './header-controls';
import storeLogo from './images/logo.png';
import IHeaderProps from './props/header-props';

require('./app.css');

class Header extends React.Component<IHeaderProps,{}> {
  constructor(props: IHeaderProps) {
    super(props);
    this.state = {};
  }
  public render() {
    return (
      <React.Fragment>
        <div id='header'>
          <StoreLogo />
          <Title />
          <HeaderControls isBasket={this.props.isBasket} />
        </div>
      </React.Fragment>
    );
  }
}

function StoreLogo() {
  return (
    <React.Fragment>
      <img id='StoreLogo' src={storeLogo} alt='Здесь будет Лого' />
    </React.Fragment>
  );
}

function Title() {
  return (
    <React.Fragment>
      <div id='title'>Компьютерная техника</div>
    </React.Fragment>
  );
}

export default Header;
