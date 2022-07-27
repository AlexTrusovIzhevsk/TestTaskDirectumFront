import React from 'react';

import ThemControl from './them-control';

require('./app.css');

class HeaderControls extends React.Component<{ isBasket: boolean; onLeaveFromBasket: () => void; onGoToBasket: () => void}> {
  constructor(props: { isBasket: boolean; onLeaveFromBasket: () => Promise<void>; onGoToBasket: () => Promise<void>}) {
    super(props);
    this.onClick = this.onClick.bind(this);
  }
  private onClick() {
    this.props.isBasket ?
      this.props.onLeaveFromBasket() :
      this.props.onGoToBasket();
  }
  public render(): React.ReactNode {
    return (
      <div id="controls">
        <a id="basketLink" href="#" onClick={this.onClick}>
          {this.props.isBasket ? 'Выйти из корзины' : 'Войти в корзину'}
        </a>
        <ThemControl />
      </div>
    );
  }
}

export default HeaderControls;