interface IBasketCategoryProps{
  isBasket: boolean;
  onCategoryChange: (category: string) => void;
  onLeaveFromBasket: () => void;
}

export default IBasketCategoryProps;