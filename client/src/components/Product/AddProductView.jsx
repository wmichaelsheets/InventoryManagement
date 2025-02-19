import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import { postProduct } from '../../managers/productManager';
import { getAllUsers } from '../../managers/userManager'; 

const AddProductView = () => {
    const [product, setProduct] = useState({
      sku: '',
      productName: '',
      unitPrice: '',
      notes: '',
      userId: 1 
    });
    const [users, setUsers] = useState([]);
    const navigate = useNavigate();
  
    useEffect(() => {
      const fetchUsers = async () => {
        try {
          const fetchedUsers = await getAllUsers();
          setUsers(fetchedUsers);
        } catch (error) {
          console.error('Error fetching users:', error);
        }
      };
      fetchUsers();
    }, []);

    const handleInputChange = (event) => {
      const { name, value } = event.target;
      setProduct(prevProduct => ({
        ...prevProduct,
        [name]: name === 'unitPrice' ? parseFloat(value) : 
                name === 'userId' ? parseInt(value, 10) : value
      }));
    };
  
    const handleSubmit = async (event) => {
      event.preventDefault();
      try {
        const newProduct = {
          ...product,
          unitPrice: parseFloat(product.unitPrice),
          notes: product.notes || '' 
        };
        console.log('Attempting to add product:', newProduct);
        const addedProduct = await postProduct(newProduct);
        console.log('Product added successfully:', addedProduct);
        if (addedProduct && addedProduct.sku) {
          alert(`Product "${addedProduct.productName}" has been successfully added!`);
          navigate('/productdetail');
        } else {
          throw new Error('Product was not added successfully');
        }
      } catch (error) {
        console.error('Error adding product:', error);
        alert(`Failed to add product. Error: ${error.message}`);
      }
    };

  return (
    <div className="container mt-4">
      <h2>Add New Product</h2>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="sku">SKU</Label>
          <Input
            type="text"
            name="sku"
            id="sku"
            value={product.sku}
            onChange={handleInputChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="productName">Product Name</Label>
          <Input
            type="text"
            name="productName"
            id="productName"
            value={product.productName}
            onChange={handleInputChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="unitPrice">Unit Price</Label>
          <Input
            type="number"
            name="unitPrice"
            id="unitPrice"
            value={product.unitPrice}
            onChange={handleInputChange}
            step="0.01"
            min="0"
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="notes">Notes</Label>
          <Input
            type="textarea"
            name="notes"
            id="notes"
            value={product.notes}
            onChange={handleInputChange}
          />
        </FormGroup>
        <FormGroup>
          <Label for="userId">Assigned User</Label>
          <Input
            type="select"
            name="userId"
            id="userId"
            value={product.userId}
            onChange={handleInputChange}
            required
          >
            {users.map(user => (
              <option key={user.id} value={user.id}>
                {`${user.firstName} ${user.lastName} (${user.username})`}
              </option>
            ))}
          </Input>
        </FormGroup>
        <Button color="primary" type="submit">Add Product</Button>
      </Form>
    </div>
  );
};

export default AddProductView;