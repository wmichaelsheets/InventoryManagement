import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { putProductBySku, getProductByName } from '../../managers/productManager';
import { getAllUsers } from '../../managers/userManager';

export default function ProductUpdateView({ productName, onClose }) {
  const [product, setProduct] = useState({
    sku: '',
    productName: '',
    unitPrice: 0,
    userId: 1,
    notes: ''
  });
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const fetchProductAndUsers = async () => {
      try {
        const productData = await getProductByName(productName);
        setProduct(prevProduct => ({
          ...prevProduct,
          ...productData,
          userId: productData.userId || 1
        }));
        const usersData = await getAllUsers();
        console.log('Fetched users:', usersData);
        setUsers(usersData);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };
    fetchProductAndUsers();
  }, [productName]);


  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setProduct(prev => ({ 
      ...prev, 
      [name]: name === 'userId' ? parseInt(value, 10) : 
              name === 'unitPrice' ? parseFloat(value) : value 
    }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      console.log('Submitting product update:', product);
      await putProductBySku(sku, updateProductDTO);
      alert('Product updated successfully!');
      onClose();
    } catch (error) {
      console.error('Failed to update product:', error);
      alert('Failed to update product. Please try again.');
    }
  };

  return (
    <Form onSubmit={handleSubmit}>
      <FormGroup>
        <Label for="sku">SKU</Label>
        <Input type="text" name="sku" id="sku" value={product.sku} onChange={handleInputChange} readOnly />
      </FormGroup>
      <FormGroup>
        <Label for="productName">Product Name</Label>
        <Input type="text" name="productName" id="productName" value={product.productName} onChange={handleInputChange} />
      </FormGroup>
      <FormGroup>
        <Label for="unitPrice">Unit Price</Label>
        <Input type="number" name="unitPrice" id="unitPrice" value={product.unitPrice} onChange={handleInputChange} />
      </FormGroup>
      <FormGroup>
  <Label for="userId">Assigned User</Label>
  {users.length > 0 ? (
    <>
      <Input 
        type="select" 
        name="userId" 
        id="userId" 
        value={product.userId || ''} 
        onChange={handleInputChange}
      >
        <option value="">Select a user</option>
        {users.map(user => (
          <option key={user.id} value={user.id}>
            {`${user.firstName} ${user.lastName} (${user.username})`}
          </option>
        ))}
      </Input>
      <small>Current userId: {product.userId}</small>
    </>
  ) : (
    <p>Loading users...</p>
  )}
</FormGroup>
      <FormGroup>
        <Label for="notes">Notes</Label>
        <Input type="textarea" name="notes" id="notes" value={product.notes} onChange={handleInputChange} />
      </FormGroup>
      <Button color="primary" type="submit">Update Product</Button>
      <Button color="secondary" onClick={onClose}>Cancel</Button>
    </Form>
  );
}