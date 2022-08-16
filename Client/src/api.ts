import IProductInfo from './types/product-info';

export async function getCategories(): Promise<Array<string>> {
  return apiFunk<Array<string>>('GET', 'api/category');
}

export async function getProductsByCategory(category: string): Promise<Array<IProductInfo>> {
  return apiFunk<Array<IProductInfo>>('GET', `api/category/list/${category}`);
}

export async function getUserBasket(): Promise<Array<IProductInfo>> {
  return apiFunk<Array<IProductInfo>>('GET', 'api/basket/list');
}

export async function addToBascet(id: string): Promise<void> {
  return apiAction('PUT', `api/basket/addProductToBasket?productId=${id}&count=1`);
}

export async function removeFromBascet(id: string): Promise<void> {
  return apiAction('DELETE', `api/basket/removeProductFromBasket?productId=${id}&count=1`);
}

async function apiAction(optionsMethod: string, uriServer: string): Promise<void> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: optionsMethod
  };
  const uri: string = uriServer;
  const response = await fetch(uri, options);
  if (response.status === 200) {
    return;
  }
  throw new Error(`Error: ${response.statusText}`);
}

async function apiFunk<T>(optionsMethod: string, uriServer: string): Promise<T> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: optionsMethod
  };
  const uri: string = uriServer;
  const response = await fetch(uri, options);
  if (response.status === 200) {
    return await response.json();
  }
  throw new Error(`Error: ${response.statusText}`);
}
