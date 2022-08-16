import React from 'react';
import { autobind } from 'core-decorators';

import logoLaptop from './images/logoLaptop.png';
import logoPhone from './images/logoPhone.png';
import logoAccessory from './images/logoAccessory.png';
import { addToBascet, removeFromBascet, getUserBasket, getProductsByCategory } from './api';
import IProductProps from './props/product-props';

require('./app.css');

@autobind
class ProductItem extends React.Component<IProductProps, { needShowAddButton: boolean; needShowRemoveButton: boolean}> {
  constructor(props: IProductProps) {
    super(props);
    this.state = { needShowAddButton: false, needShowRemoveButton: false };
    this.setState({ needShowAddButton: true });
    this.setState({ needShowRemoveButton: true });
  }
  public async componentDidMount() {
    if (this.props.isBasket) {
      this.setState({ needShowRemoveButton: true });
      const list = await getProductsByCategory(this.props.value.Product.Category);
      const productStore = list.filter(product => product.Product.Id === this.props.value.Product.Id)[0];
      if (productStore != null && productStore.Count > 0) {
        this.setState({ needShowAddButton: true });
      }
      else {
        this.setState({ needShowAddButton: false });
      }
    }
    else {
      this.setState({ needShowAddButton: true });
      const list = await getUserBasket();
      const productBasket = list.filter(product => product.Product.Id === this.props.value.Product.Id)[0];
      if (productBasket != null && productBasket.Count > 0) {
        this.setState({ needShowRemoveButton: true });
      }
      else {
        this.setState({ needShowRemoveButton: false });
      }
    }
  }
  private async addToBascet() {
    await addToBascet(this.props.value.Product.Id);
    await this.props.updateProducts();
    await this.componentDidMount();
  }
  private async removeFromBascet() {
    await removeFromBascet(this.props.value.Product.Id);
    await this.props.updateProducts();
    await this.componentDidMount();
  }
  private getSrc(): string {
    if (this.props.value.Product.Category === 'Tablet' || this.props.value.Product.Category === 'Phone')
      return logoPhone;
    if (this.props.value.Product.Category === 'Accessory')
      return logoAccessory;
    return logoLaptop;
  }
  public render(): React.ReactNode {
    return (
      <div className='product'>
        <img className='logo' src={this.getSrc()} alt='Здесь будет Лого' />
        <div className='productName'>
          Наименование: {this.props.value.Product.Name}
        </div>
        <div>
          Категория: {this.props.value.Product.Category}
        </div>
        <div>
          Цена: {this.props.value.Product.Price}
        </div>
        <div>
          Количество: {this.props.value.Count}
        </div>
        <div>
          В корзине: {this.props.value.Owner ? this.props.value.Owner.Login : 'null'}
        </div>
        <button onClick={this.addToBascet} disabled={!this.state.needShowAddButton} >{'Добавить в корзину'}</button>
        <button onClick={this.removeFromBascet} disabled={!this.state.needShowRemoveButton}>{'Убрать из корзины'}</button>
      </div>
    );
  }
}

export default ProductItem;