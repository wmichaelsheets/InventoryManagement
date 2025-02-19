const _apiUrl = "/api/auth";

export const login = (email, password) => {
  return fetch(_apiUrl + "/login", {
    method: "POST",
    credentials: "include", //Originally "same-origin", but now allows cookies to be sent with the request. Two other instances of this in the file.
    headers: {
      Authorization: `Basic ${btoa(`${email}:${password}`)}`,
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.resolve(null);
    } else {
      return tryGetLoggedInUser();
    }
  });
};

export const logout = () => {
  return fetch(_apiUrl + "/logout");
};

export const tryGetLoggedInUser = () => {
  return fetch(_apiUrl + "/me", {
    credentials: 'include'  // This ensures cookies are sent with the request
  })
  .then((res) => {
    if (res.status === 401) {
      console.log("User is not authenticated");
      return null;
    }
    if (!res.ok) {
      throw new Error(`HTTP error! status: ${res.status}`);
    }
    return res.json();
  })
  .catch((error) => {
    console.error("Error in tryGetLoggedInUser:", error);
    throw error;
  });
};

export const register = (userProfile) => {
  userProfile.password = btoa(userProfile.password);
  return fetch(_apiUrl + "/register", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userProfile),
  }).then((res) => {
    if (res.ok) {
      return login(userProfile.email, atob(userProfile.password));
    } else {
      return Promise.reject("Registration failed");
    }
  });
};