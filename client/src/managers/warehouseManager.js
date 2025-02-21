const apiUrl = "/api/Warehouse";

export const getAllInventoryAllWarehouses = async (userId) => {
  try {
    const response = await fetch(`${apiUrl}/all-inventory?userId=${userId}`, {
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

export const getWarehouseValues = async (userId) => {
  try {
    const response = await fetch(`${apiUrl}/values?userId=${userId}`, {
      method: "GET",
      credentials: "include"
    });

    if (!response.ok) {
      throw new Error("Failed to fetch warehouse values");
    }

    return await response.json();
  } catch (error) {
    console.error("Error fetching warehouse values:", error);
    throw error;
  }
};

export const getInventoryForWarehouseId = async (warehouseId, userId) => {
  try {
    const response = await fetch(`${apiUrl}/${warehouseId}/inventory?userId=${userId}`, {
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