import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import Home from "./Home";
import ProductDetail from "./Product/ProductDetail";
import AddProductView from "./Product/AddProductView";

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
              <ProductDetail />
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