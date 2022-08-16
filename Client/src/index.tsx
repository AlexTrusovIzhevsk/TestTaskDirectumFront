import * as React from 'react';
import { render } from 'react-dom';

import RouterApp from './router-app';

require('./app.css');

document.documentElement.setAttribute('theme', 'white');

render(
  <RouterApp />,
  document.getElementById('root')
);