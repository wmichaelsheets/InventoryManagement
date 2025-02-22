import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Home from "./Home";
import ProductDetail from "./Product/ProductDetail";
import AddProductView from "./Product/AddProductView";
import WarehouseView from "./Warehouse/WarehouseView";
import AddInventoryView from "./Inventory/AddInventoryView";
import UpdateInventoryView from "./Inventory/UpdateInventoryView";
import AssignUserProduct from "./Product/AssignUserProduct";
import UserView from './User/UserView';

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home loggedInUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="productdetail"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
                <ProductDetail currentUser={loggedInUser} />
            </AuthorizedRoute>
          }
        />
        <Route
          path="products/add"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <AddProductView />
            </AuthorizedRoute>
          }
        />
        <Route
          path="warehouse"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <WarehouseView />
            </AuthorizedRoute>
          }
        />
        <Route
          path="inventory/add"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <AddInventoryView />
            </AuthorizedRoute>
          }
        />
        <Route
          path="inventory/update/:id"
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <UpdateInventoryView />
            </AuthorizedRoute>
          }
        />
        <Route 
          path="/assign-user-product" 
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
          <AssignUserProduct />
          </AuthorizedRoute>
          } 
        />

      <Route 
        path="/profile" 
        element={
        <UserView loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
        } 
      />

        <Route
          path="login"
          element={<Login setLoggedInUser={setLoggedInUser} />}
        />
        <Route
          path="register"
          element={<Register setLoggedInUser={setLoggedInUser} />}
        />
      </Route>
      <Route path="*" element={<p>Whoops, nothing here...</p>} />
    </Routes>
  );
}