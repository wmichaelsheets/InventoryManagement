const apiUrl = "/api/inventory";


export const getAllInventory = async () => {
  try {
    const response = await fetch(apiUrl);
    if (!response.ok) {
      throw new Error('Failed to fetch inventory items');
    }
    return await response.json();
  } catch (error) {
    console.error('Error fetching inventory:', error);
    throw error;
  }
};


export const postInventory = async (inventoryItem) => {
  try {
    const response = await fetch(apiUrl, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(inventoryItem),
    });
    if (!response.ok) {
      throw new Error('Failed to add inventory item');
    }
    return await response.json();
  } catch (error) {
    console.error('Error adding inventory item:', error);
    throw error;
  }
};


export const putInventoryByWarehouseId = async (warehouseId, inventoryItem) => {
  try {
    const response = await fetch(`${apiUrl}/${warehouseId}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(inventoryItem),
    });
    if (!response.ok) {
      throw new Error('Failed to update inventory item');
    }
    return await response.json();
  } catch (error) {
    console.error('Error updating inventory item:', error);
    throw error;
  }
};