import React, { useEffect, useState } from "react";
import { BrowserRouter as Router } from "react-router-dom";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { tryGetLoggedInUser } from "./managers/authManager";
import { Spinner } from "reactstrap";
import NavBar from "./components/NavBar";
import ApplicationViews from "./components/ApplicationViews";
import Login from "./components/auth/Login"; 

function App() {
  const [loggedInUser, setLoggedInUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    console.log("Attempting to fetch user data");
    tryGetLoggedInUser()
      .then((user) => {
        console.log("User data received:", user);
        setLoggedInUser(user);
      })
      .catch((err) => {
        console.error("Failed to fetch user:", err);
        setError("Failed to load user data");
      })
      .finally(() => {
        setLoading(false);
      });
  }, []);

  if (loading) {
    return <Spinner />;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <Router>
      {loggedInUser ? (
        <>
          <NavBar loggedInUser={loggedInUser} setLoggedInUser={setLoggedInUser} />
          <ApplicationViews
            loggedInUser={loggedInUser}
            setLoggedInUser={setLoggedInUser}
          />
        </>
      ) : (
        <Login setLoggedInUser={setLoggedInUser} />
      )}
    </Router>
  );
}

export default App;