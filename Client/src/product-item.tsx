import React from 'react';

import { autobind } from 'core-decorators';

import logoLaptop from './logoLaptop.png';
import logoPhone from './logoPhone.png';
import logoAccessory from './logoAccessory.png';

import { addToBascet, removeFromBascet } from './api';
import IBasketProps from './props/basket-props';

require('./app.css');

@autobind
class ProductItem extends React.Component<IBasketProps, {}> {
  constructor(props: IBasketProps) {
    super(props);
    this.addToBascet = this.addToBascet.bind(this);
    this.removeFromBascet = this.removeFromBascet.bind(this);
  }
  private async addToBascet() {
    await addToBascet(this.props.value.Product.Id);
    await this.props.updateProducts();
  }
  private async removeFromBascet() {
    await removeFromBascet(this.props.value.Product.Id);
    await this.props.updateProducts();
  }
  public render(): React.ReactNode {
    return (
      <div className='product'>
        <img className='logo'
          src={this.props.value.Product.Category === 'Tablet' || this.props.value.Product.Category === 'Phone' ? logoPhone :
            this.props.value.Product.Category === 'Accessory' ? logoAccessory : logoLaptop}
          alt='Здесь будет Лого'
        />
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
        <button onClick={this.props.isBasket ? this.removeFromBascet : this.addToBascet}>
          {this.props.isBasket ? 'Убрать из корзины' : 'Добавить в корзину'}
        </button>
      </div>
    );
  }
}

export default ProductItem;