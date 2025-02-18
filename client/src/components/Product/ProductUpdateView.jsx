import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import { putProductBySku, getProductByName } from '../managers/productManager';

export default function ProductUpdateView({ productName, onClose }) {
  const [product, setProduct] = useState({
    sku: '',
    productName: '',
    unitPrice: 0,
    userId: 0,
    notes: ''
  });

  useEffect(() => {
    getProductByName(productName).then(setProduct);
  }, [productName]);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setProduct(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      await putProductBySku(product.sku, product);
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
        <Label for="userId">User ID</Label>
        <Input type="number" name="userId" id="userId" value={product.userId} onChange={handleInputChange} readOnly />
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