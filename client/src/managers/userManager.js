export const getAllUsers = () => {
    return fetch("/api/userprofile")
      .then((res) => res.json())
      .then((data) => {
        return data;
      });
  };