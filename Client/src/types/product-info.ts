import IOwner from './owner';
import IProduct from './product';

interface IProductInfo {
  Product: IProduct;
  Owner: IOwner | null;
  Count: number;
}

export default IProductInfo;