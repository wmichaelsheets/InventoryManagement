const _apiUrl = "/api/auth";

export const login = (email, password) => {
  return fetch(_apiUrl + "/login", {
    method: "POST",
    credentials: "same-origin",
    headers: {
      Authorization: `Basic ${btoa(`${email}:${password}`)}`,
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.resolve(null);
    } else {
      return tryGetLoggedInUser().then(user => {
        if (user && user.id) {
          localStorage.setItem('userId', user.id);
        }
        return user;
      });
    }
  });
};


export const logout = () => {
  return fetch(_apiUrl + "/logout").then(() => {
    localStorage.removeItem('userId');
  });
};

export const tryGetLoggedInUser = () => {
  console.log("Attempting to get logged in user");
  return fetch(_apiUrl + "/me")
    .then((res) => {
      console.log("Response status:", res.status);
      if (res.ok) {
        return res.json();
      }
      console.log("User not logged in");
      return null;
    })
    .catch((error) => {
      console.error("Error in tryGetLoggedInUser:", error);
      return null;
    });
};

export const register = (userProfile) => {
  userProfile.password = btoa(userProfile.password);
  return fetch(_apiUrl + "/register", {
    credentials: "same-origin",
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userProfile),
  }).then(() => tryGetLoggedInUser());
};

export const getCurrentUserId = () => {
  
  const userId = localStorage.getItem('userId');
  
  if (!userId) {
    console.error('User ID not found in localStorage');
    return null;
  }
  
  return userId;
};