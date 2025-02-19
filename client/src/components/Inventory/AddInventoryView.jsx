import React, { useState } from 'react';
import { postInventory } from '../../managers/inventoryManager';
import { Form, FormGroup, Label, Input, Button, Container, Row, Col } from 'reactstrap';
import { useNavigate } from 'react-router-dom';

const AddInventoryView = () => {
  const [warehouseId, setWarehouseId] = useState('');
  const [productSku, setProductSku] = useState('');
  const [quantity, setQuantity] = useState('');

  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    const inventoryItem = {
      warehouseId: parseInt(warehouseId),
      productSku,
      quantity: parseInt(quantity)
    };

    try {
      await postInventory(inventoryItem);
      alert('Inventory item added successfully!');
      navigate('/warehouse'); 
    } catch (error) {
      alert('Failed to add inventory item. Please try again.');
    }
  };

  return (
    <Container className="mt-4">
      <Row>
        <Col md={{ size: 6, offset: 3 }}>
          <h2 className="text-center mb-4">Add Inventory Item</h2>
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
            <Button color="primary" type="submit" block>Submit</Button>
          </Form>
        </Col>
      </Row>
    </Container>
  );
};

export default AddInventoryView;