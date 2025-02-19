const apiUrl = "/api/Warehouse"; 

export const getAllInventoryAllWarehouses = async () => {
  try {
    const response = await fetch(`${apiUrl}/all-inventory`, {
      method: "GET",
      credentials: "include"
    });

    if (response.status === 404) {
      console.log('No inventory found for any warehouse');
      return [];
    }

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Error fetching all warehouses inventory:", error);
    throw error;
  }
};

export const getWarehouseValues = async () => {
  const response = await fetch("/api/warehouse/values");
  if (!response.ok) {
    throw new Error("Failed to fetch warehouse values");
  }
  return await response.json();
}; 

export const getInventoryForWarehouseId = async (warehouseId) => {
  try {
    const response = await fetch(`${apiUrl}/${warehouseId}/inventory`, {
      method: "GET",
      credentials: "include"
    });

    if (response.status === 404) {
      console.log(`No inventory found for warehouse with ID ${warehouseId}`);
      return [];
    }

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error(`Error fetching inventory for warehouse ${warehouseId}:`, error);
    throw error;
  }

};