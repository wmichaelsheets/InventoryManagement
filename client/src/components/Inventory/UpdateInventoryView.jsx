import React, { useState, useEffect } from 'react';
import { putInventoryByWarehouseId } from '../../managers/inventoryManager';
import { Form, FormGroup, Label, Input, Button, Container, Row, Col } from 'reactstrap';
import { useNavigate, useParams, useLocation } from 'react-router-dom';

const UpdateInventoryView = () => {
  const [warehouseId, setWarehouseId] = useState('');
  const [productSku, setProductSku] = useState('');
  const [quantity, setQuantity] = useState('');

  const navigate = useNavigate();
  const { id } = useParams();
  const location = useLocation();

  useEffect(() => {
    if (location.state) {
      setWarehouseId(location.state.warehouseId || '');
      setProductSku(location.state.productSku || '');
      setQuantity(location.state.quantity || '');
    } else if (id) {
      setWarehouseId(id);
    }
  }, [location, id]);

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    const inventoryItem = {
      productSku,
      quantity: parseInt(quantity)
    };

    try {
      await putInventoryByWarehouseId(warehouseId, inventoryItem);
      alert('Inventory item updated successfully!');
      navigate('/warehouse'); 
    } catch (error) {
      console.error('Error updating inventory:', error);
      alert('Failed to update inventory item. Please try again.');
    }
  };

  return (
    <Container className="mt-4">
      <Row>
        <Col md={{ size: 6, offset: 3 }}>
          <h2 className="text-center mb-4">Update Inventory Item</h2>
          <Form onSubmit={handleSubmit}>
            <FormGroup>
              <Label for="warehouseId">Warehouse ID</Label>
              <Input
                type="number"
                name="warehouseId"
                id="warehouseId"
                value={warehouseId}
                onChange={(e) => setWarehouseId(e.target.value)}
                required
                min="1"
                disabled
              />
            </FormGroup>
            <FormGroup>
              <Label for="productSku">Product SKU</Label>
              <Input
                type="text"
                name="productSku"
                id="productSku"
                value={productSku}
                onChange={(e) => setProductSku(e.target.value)}
                required
                disabled
              />
            </FormGroup>
            <FormGroup>
              <Label for="quantity">Quantity</Label>
              <Input
                type="number"
                name="quantity"
                id="quantity"
                value={quantity}
                onChange={(e) => setQuantity(e.target.value)}
                required
                min="0"
              />
            </FormGroup>
            <Button color="primary" type="submit" block>Update</Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default UpdateInventoryView;