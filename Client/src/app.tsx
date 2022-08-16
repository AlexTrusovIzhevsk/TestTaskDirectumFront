import React from 'react';
import autobind from 'autobind-decorator';

import Header from './header';
import Main from './main';
import Footer from './footer';
import IAppProps from './props/main-props';

require('./app.css');

@autobind
class App extends React.Component<IAppProps> {
  constructor(props: IAppProps) {
    super(props);
  }
  public render(): React.ReactNode {
    return (
      <div>
        <Header isBasket={this.props.isBasket} />
        <Main isBasket={this.props.isBasket} category={this.props.category} />
        <Footer />
      </div>
    );
  }
}

export default App;