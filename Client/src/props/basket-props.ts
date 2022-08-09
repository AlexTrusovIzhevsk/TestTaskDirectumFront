import IProductInfo from './types/product-info';

interface IBasketProps{
  isBasket: boolean;
  value: IProductInfo;
  updateProducts: () => Promise<void>;
}

export default IBasketProps;