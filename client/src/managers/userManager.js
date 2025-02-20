export const getAllUsers = () => {
    return fetch("/api/userprofile")
      .then((res) => res.json())
      .then((data) => {
        return data;
      });
  };

export const updateUserProfile = (userId, updatedUserData) => {
  return fetch(`/api/userprofile/${userId}`, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(updatedUserData),
  }).then((res) => {
    if (res.ok) {
      return res.json();
    } else {
      throw new Error("Failed to update user profile");
    }
  });
};