interface ICategoryChangeHandlerProps{
  isBasket: boolean;
  onCategoryChange: (category: string) => void;
  onLeaveFromBasket: () => void;
}

export default ICategoryChangeHandlerProps;