import React, { useState, useEffect } from 'react';
import { Form, FormGroup, Label, Input, Button, Alert } from 'reactstrap';
import { getAllProducts } from '../../managers/productManager';
import { getAllUsers } from '../../managers/userManager';
import { putProductBySku } from '../../managers/productManager';
//import { putUserProduct } from '../../managers/productManager';

export default function AssignUserProduct() {
  const [products, setProducts] = useState([]);
  const [users, setUsers] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState('');
  const [selectedUser, setSelectedUser] = useState('');
  const [message, setMessage] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const [productsData, usersData] = await Promise.all([
          getAllProducts(),
          getAllUsers()
        ]);
        setProducts(productsData);
        setUsers(usersData);
      } catch (error) {
        console.error('Error fetching data:', error);
        setMessage({ type: 'danger', text: 'Failed to load products and users.' });
      }
    };
    fetchData();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!selectedProduct || !selectedUser) {
      setMessage({ type: 'warning', text: 'Please select both a product and a user.' });
      return;
    }
  
    try {
      const updateProductDTO = {
        productName: products.find(p => p.sku === selectedProduct)?.productName,
        unitPrice: products.find(p => p.sku === selectedProduct)?.unitPrice,
        userId: parseInt(selectedUser, 10),
        notes: products.find(p => p.sku === selectedProduct)?.notes
      };
  
      await putProductBySku(selectedProduct, updateProductDTO);
      setMessage({ type: 'success', text: 'User successfully assigned to product!' });
      setSelectedProduct('');
      setSelectedUser('');
    } catch (error) {
      console.error('Error assigning user to product:', error);
      setMessage({ type: 'danger', text: 'Failed to assign user to product. Please try again.' });
    }
  };

  return (
    <div className="container mt-4">
      <h2>Assign User to Product</h2>
      {message && (
        <Alert color={message.type} className="mt-3">
          {message.text}
        </Alert>
      )}
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="productSelect">Select Product</Label>
          <Input
            type="select"
            name="productSelect"
            id="productSelect"
            value={selectedProduct}
            onChange={(e) => setSelectedProduct(e.target.value)}
          >
            <option value="">Choose a product...</option>
            {products.map((product) => (
              <option key={product.sku} value={product.sku}>
                {product.productName} (SKU: {product.sku})
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label for="userSelect">Select User</Label>
          <Input
            type="select"
            name="userSelect"
            id="userSelect"
            value={selectedUser}
            onChange={(e) => setSelectedUser(e.target.value)}
          >
            <option value="">Choose a user...</option>
            {users.map((user) => (
              <option key={user.id} value={user.id}>
                {user.firstName} {user.lastName} ({user.username})
              </option>
            ))}
          </Input>
        </FormGroup>
        <Button color="primary" type="submit">
          Assign User to Product
        </Button>
      </Form>
    </div>
  );
}