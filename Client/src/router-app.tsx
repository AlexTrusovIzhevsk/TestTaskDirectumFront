import React from 'react';
import { HashRouter, Route, Routes } from 'react-router-dom';
import autobind from 'autobind-decorator';

import App from './app';

require('./app.css');

@autobind
class RouterApp extends React.Component {
  constructor(props: {}) {
    super(props);
  }
  public render(): React.ReactNode {
    return (
      <HashRouter >
        <div>
          <Routes>
            <Route path='basket' element={<App isBasket={true} category={null} />} />
            <Route path='category'>
              <Route path='computer' element={<App isBasket={false} category={'Computer'} />} />
              <Route path='laptop' element={<App isBasket={false} category={'Laptop'} />} />
              <Route path='tablet' element={<App isBasket={false} category={'Tablet'} />} />
              <Route path='phone' element={<App isBasket={false} category={'Phone'} />} />
              <Route path='accessory' element={<App isBasket={false} category={'Accessory'} />} />
            </Route>
            <Route path='/' element={<App isBasket={false} category={null} />} />
          </Routes>
        </div>
      </HashRouter>
    );
  }
}

export default RouterApp;