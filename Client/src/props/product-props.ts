import IProductInfo from '../types/product-info';

import IAppProps from './main-props';

interface IProductProps extends IAppProps{
  value: IProductInfo;
  updateProducts: () => Promise<void>;
}

export default IProductProps;