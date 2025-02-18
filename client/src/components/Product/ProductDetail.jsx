import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Form, FormGroup, Label, Input, Button, Table } from 'reactstrap';
import { getAllProducts, getProductByName, deleteProductBySku, putProductBySku } from '../../managers/productManager';

const ProductDetail = () => {
  const navigate = useNavigate();
  const [products, setProducts] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [productDetails, setProductDetails] = useState(null);
  const [isUpdating, setIsUpdating] = useState(false);
  const [updatedProduct, setUpdatedProduct] = useState(null);

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const allProducts = await getAllProducts();
        setProducts(allProducts);
      } catch (error) {
        console.error('Error fetching products:', error);
      }
    };
    fetchProducts();
  }, []);

  const handleProductSelect = async (event) => {
    const productName = event.target.value;
    setSelectedProduct(productName);
    if (productName) {
      try {
        const details = await getProductByName(productName);
        setProductDetails(details);
        setUpdatedProduct(details);
      } catch (error) {
        console.error('Error fetching product details:', error);
      }
    } else {
      setProductDetails(null);
      setUpdatedProduct(null);
    }
  };

  const handleAddNewProduct = () => {
    navigate('/products/add'); // Adjust this path as needed
  };


  const handleDeleteProduct = async () => {
    if (selectedProduct && productDetails) {
      // Add confirmation dialog
      const isConfirmed = window.confirm(`Are you sure you want to delete the product "${productDetails.productName}"?`);
      
      if (isConfirmed) {
        try {
          await deleteProductBySku(productDetails.sku);
          setSelectedProduct(null);
          setProductDetails(null);
          // Refresh the product list
          const updatedProducts = await getAllProducts();
          setProducts(updatedProducts);
        } catch (error) {
          console.error('Error deleting product:', error);
        }
      }
    }
  };

  const handleUpdateProduct = () => {
    setIsUpdating(true);
  };

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setUpdatedProduct(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmitUpdate = async (event) => {
    event.preventDefault();
    try {
      await putProductBySku(updatedProduct.sku, updatedProduct);
      setProductDetails(updatedProduct);
      setIsUpdating(false);
      // Refresh the product list
      const updatedProducts = await getAllProducts();
      setProducts(updatedProducts);
    } catch (error) {
      console.error('Error updating product:', error);
    }
  };

  const handleCancelUpdate = () => {
    setIsUpdating(false);
    setUpdatedProduct(productDetails);
  };

  return (
    <div className="container mt-4">
      <h2 className="text-center mb-4">Product Detail</h2>
      <Form>
        <FormGroup>
          <Label for="productSelect">Select a Product</Label>
          <Input
            type="select"
            name="productSelect"
            id="productSelect"
            onChange={handleProductSelect}
            value={selectedProduct || ''}
          >
            <option value="">Choose a product...</option>
            {products.map((product) => (
              <option key={product.sku} value={product.productName}>
                {product.productName}
              </option>
            ))}
          </Input>
        </FormGroup>
      </Form>

      {productDetails && !isUpdating && (
        <div className="mt-4">
          <h3>{productDetails.productName}</h3>
          <p>SKU: {productDetails.sku}</p>
          <p>Unit Price: ${productDetails.unitPrice}</p>
          <p>Notes: {productDetails.notes}</p>
          <Table>
            <thead>
              <tr>
                <th>Warehouse ID</th>
                <th>Quantity</th>
              </tr>
            </thead>
            <tbody>
              {productDetails.inventories.map((inventory) => (
                <tr key={inventory.warehouseId}>
                  <td>{inventory.warehouseId}</td>
                  <td>{inventory.quantity}</td>
                </tr>
              ))}
            </tbody>
          </Table>
          <Button color="primary" onClick={handleUpdateProduct} className="me-2">
            Update Product
          </Button>
        </div>
      )}

      {isUpdating && updatedProduct && (
        <Form onSubmit={handleSubmitUpdate}>
          <FormGroup>
            <Label for="sku">SKU</Label>
            <Input type="text" name="sku" id="sku" value={updatedProduct.sku} readOnly />
          </FormGroup>
          <FormGroup>
            <Label for="productName">Product Name</Label>
            <Input type="text" name="productName" id="productName" value={updatedProduct.productName} onChange={handleInputChange} />
          </FormGroup>
          <FormGroup>
            <Label for="unitPrice">Unit Price</Label>
            <Input type="number" name="unitPrice" id="unitPrice" value={updatedProduct.unitPrice} onChange={handleInputChange} />
          </FormGroup>
          <FormGroup>
            <Label for="notes">Notes</Label>
            <Input type="textarea" name="notes" id="notes" value={updatedProduct.notes} onChange={handleInputChange} />
          </FormGroup>
          <Button color="primary" type="submit" className="me-2">Save Changes</Button>
          <Button color="secondary" onClick={handleCancelUpdate}>Cancel</Button>
        </Form>
      )}

      <div className="mt-4">
        <Button color="success" onClick={handleAddNewProduct} className="me-2">
          Add New Product
        </Button>
        <Button color="danger" onClick={handleDeleteProduct} disabled={!selectedProduct}>
          Delete Product
        </Button>
      </div>
    </div>
  );
};

export default ProductDetail;