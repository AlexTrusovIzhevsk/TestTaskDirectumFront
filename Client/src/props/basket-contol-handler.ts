interface IBasketContolHandler{
  isBasket: boolean;
  onGoToBasket: () => void;
  onLeaveFromBasket: () => void;
}

export default IBasketContolHandler;