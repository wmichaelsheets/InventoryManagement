const apiUrl = "/api/product";


export const getAllProducts = async () => {
  try {
    const response = await fetch(apiUrl);
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return await response.json();
  } catch (error) {
    console.error('Error fetching all products:', error);
    throw error;
  }
};

export const getProductByName = async (productName) => {
  try {
    const response = await fetch(`${apiUrl}/${encodeURIComponent(productName)}`);
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return await response.json();
  } catch (error) {
    console.error(`Error fetching product with name ${productName}:`, error);
    throw error;
  }
};

export const postProduct = async (product) => {
  const response = await fetch("/api/product", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(product),
  });
  
  const responseData = await response.json();
  
  if (!response.ok) {
    console.error('Server response:', responseData);
    throw new Error(`HTTP error! status: ${response.status}, message: ${JSON.stringify(responseData)}`);
  }
  
  return responseData;
};

export const putProductBySku = async (sku, updateProductDTO) => {
  try {
    const response = await fetch(`${apiUrl}/${encodeURIComponent(sku)}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(updateProductDTO),
    });
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return await response.json();
  } catch (error) {
    console.error(`Error updating product with SKU ${sku}:`, error);
    throw error;
  }
};

export const deleteProductBySku = async (sku) => {
  try {
    const response = await fetch(`${apiUrl}/${encodeURIComponent(sku)}`, {
      method: 'DELETE',
    });
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
  } catch (error) {
    console.error(`Error deleting product with SKU ${sku}:`, error);
    throw error;
  }
};