import React from 'react';

import Header from './header';
import Main from './main';
import Footer from './footer';
import IProductItemProps from './props/basket-props';

require('./app.css');

class App extends React.Component<IProductItemProps, {isBasket: boolean}> {
  constructor(props: IProductItemProps) {
    super(props);
    this.state = { isBasket: false };
    this.onGoToBasket = this.onGoToBasket.bind(this);
    this.onLeaveFromBasket = this.onLeaveFromBasket.bind(this);
  }
  private onGoToBasket() {
    this.setState({ isBasket: true });
  }
  private onLeaveFromBasket() {
    this.setState({ isBasket: false });
  }
  public render(): React.ReactNode {
    return (
      <div>
        <Header isBasket={this.state.isBasket} onGoToBasket={this.onGoToBasket} onLeaveFromBasket={this.onLeaveFromBasket} />
        <Main isBasket={this.state.isBasket} onGoToBasket={this.onGoToBasket} onLeaveFromBasket={this.onLeaveFromBasket} />
        <Footer />
      </div>
    );
  }
}

export default App;