import * as React from 'react';
import { render } from 'react-dom';

import App from './app';

require('./app.css');

document.documentElement.setAttribute('theme', 'white');

render(
  <App />,
  document.getElementById('root')
);
