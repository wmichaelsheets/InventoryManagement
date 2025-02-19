import React, { useState, useEffect } from 'react';
import { getAllInventoryAllWarehouses, getInventoryForWarehouseId, getWarehouseValues } from '../../managers/warehouseManager';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Table, Button, Card, CardBody, CardTitle } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

const WarehouseView = () => {
  const [selectedWarehouse, setSelectedWarehouse] = useState('all');
  const [inventory, setInventory] = useState([]);
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const [warehouses, setWarehouses] = useState([]);
  const [warehouseValues, setWarehouseValues] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    setWarehouses([
      { id: 1, name: 'Warehouse 1' },
      { id: 2, name: 'Warehouse 2' },
      { id: 3, name: 'Warehouse 3' },
    ]);
    fetchWarehouseValues();
  }, []);

  useEffect(() => {
    fetchInventory();
  }, [selectedWarehouse]);

  const fetchInventory = async () => {
    try {
      let data;
      if (selectedWarehouse === 'all') {
        data = await getAllInventoryAllWarehouses();
      } else {
        data = await getInventoryForWarehouseId(selectedWarehouse);
      }
      console.log('Fetched inventory data:', data);
      setInventory(data);
    } catch (error) {
      console.error('Error fetching inventory:', error);
    }
  };

  const fetchWarehouseValues = async () => {
    try {
      const values = await getWarehouseValues();
      setWarehouseValues(values);
    } catch (error) {
      console.error('Error fetching warehouse values:', error);
    }
  };

  const toggle = () => setDropdownOpen(prevState => !prevState);

  const handleWarehouseSelect = (warehouseId) => {
    setSelectedWarehouse(warehouseId);
  };

  const handleEdit = (item) => {
    if (!item.productSku || !item.warehouseId) {
      console.error('Cannot edit item: Missing product SKU or warehouse information', item);
      return;
    }
    console.log('Item being edited:', item);
    navigate(`/inventory/update/${item.warehouseId}`, { 
      state: { 
        warehouseId: item.warehouseId,
        productSku: item.productSku, 
        quantity: item.quantity || 0
      } 
    });
  };

  const handleAddInventoryItem = () => {
    navigate('/inventory/add');
  };

  return (
    <div className="container mt-4">
      <h2 className="text-center mb-4">Warehouse Inventory</h2>
      
      <Card className="mb-4">
        <CardBody>
          <CardTitle tag="h5">Total Value by Warehouse</CardTitle>
          {Object.entries(warehouseValues).map(([warehouseId, value]) => (
            <div key={warehouseId}>
              Warehouse {warehouseId}: ${value.toFixed(2)}
            </div>
          ))}
        </CardBody>
      </Card>

      <Dropdown isOpen={dropdownOpen} toggle={toggle} className="mb-4 d-flex justify-content-center">
        <DropdownToggle caret>
          {selectedWarehouse === 'all' ? 'All Warehouses' : `Warehouse ${selectedWarehouse}`}
        </DropdownToggle>
        <DropdownMenu>
          <DropdownItem onClick={() => handleWarehouseSelect('all')}>All Warehouses</DropdownItem>
          {warehouses.map(warehouse => (
            <DropdownItem key={warehouse.id} onClick={() => handleWarehouseSelect(warehouse.id)}>
              {warehouse.name}
            </DropdownItem>
          ))}
        </DropdownMenu>
      </Dropdown>

      <Table striped>
        <thead>
          <tr>
            <th>Product Name</th>
            <th>Quantity</th>
            {selectedWarehouse === 'all' && <th>Warehouse</th>}
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {inventory.map((item, index) => (
            <tr key={index}>
              <td>{item.productName || 'N/A'}</td>
              <td>{item.quantity || 0}</td>
              {selectedWarehouse === 'all' && <td>{item.warehouseId || 'N/A'}</td>}
              <td>
                <Button 
                  color="primary" 
                  size="sm" 
                  onClick={() => handleEdit(item)}
                  disabled={!item.productSku || !item.warehouseId}
                >
                  Edit
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>

      <div className="text-center mt-4">
        <Button color="success" onClick={handleAddInventoryItem}>Add Inventory Item</Button>
      </div>
    </div>
  );
};

export default WarehouseView;