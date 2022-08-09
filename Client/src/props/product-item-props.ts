import IProductInfo from '../types/product-info';

interface IProductItemProps{
  isBasket: boolean;
  value: IProductInfo;
  updateProducts: () => Promise<void>;
}

export default IProductItemProps;