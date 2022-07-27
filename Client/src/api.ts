import IProductInfo from './types/product-info';

export async function getCategories(): Promise<Array<string>> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };
  const response = await fetch('api/store/category', options);
  if (response.status === 200) {
    return await response.json();
  }
  throw new Error(`Error: ${response.statusText}`);
}

export async function getProductsByCategory(category: string): Promise<Array<IProductInfo>> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };
  const response = await fetch(`api/store/category/${category}`, options);
  if (response.status === 200) {
    return await response.json();
  }
  throw new Error(`Error: ${response.statusText}`);
}

export async function getUserBasket(): Promise<Array<IProductInfo>> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'GET'
  };
  const uri: string = 'api/store/basket?login=login&password=12345';
  const response = await fetch(uri, options);
  if (response.status === 200) {
    return await response.json();
  }
  throw new Error(`Error: ${response.statusText}`);
}

export async function addToBascet(id: string): Promise<void> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'PUT'
  };
  const uri: string = `api/store/productToBasket?login=login&password=12345&productId=${id}&count=1`;
  const response = await fetch(uri, options);
  if (response.status === 200) {
    return;
  }
  throw new Error(`Error: ${response.statusText}`);
}

export async function removeFromBascet(id: string): Promise<void> {
  const options = {
    headers: { 'Content-Type': 'application/json' },
    method: 'PUT'
  };
  const uri: string = `api/store/productFromBasket?login=login&password=12345&productId=${id}&count=1`;
  const response = await fetch(uri, options);
  if (response.status === 200) {
    return;
  }
  throw new Error(`Error: ${response.statusText}`);
}