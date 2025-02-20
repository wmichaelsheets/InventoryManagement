import React, { useState, useEffect } from 'react';
import { Button, Form, FormGroup, Label, Input, Alert } from 'reactstrap';
import { updateUserProfile } from '../../managers/userManager';

export default function UserView({ loggedInUser, setLoggedInUser }) {
  const [userProfile, setUserProfile] = useState({
    firstName: '',
    lastName: '',
    email: ''
  });
  const [message, setMessage] = useState(null);

  useEffect(() => {
    if (loggedInUser) {
      setUserProfile({
        firstName: loggedInUser.firstName,
        lastName: loggedInUser.lastName,
        email: loggedInUser.email
      });
    }
  }, [loggedInUser]);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setUserProfile(prev => ({ ...prev, [name]: value }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const updatedProfile = await updateUserProfile(loggedInUser.id, userProfile);
      setLoggedInUser(updatedProfile);
      setMessage({ type: 'success', text: 'Profile updated successfully!' });
    } catch (error) {
      setMessage({ type: 'danger', text: 'Failed to update profile. Please try again.' });
    }
  };

  return (
    <div className="container mt-4">
      <h2>Update Profile</h2>
      {message && <Alert color={message.type}>{message.text}</Alert>}
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="firstName">First Name</Label>
          <Input
            type="text"
            name="firstName"
            id="firstName"
            value={userProfile.firstName}
            onChange={handleInputChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="lastName">Last Name</Label>
          <Input
            type="text"
            name="lastName"
            id="lastName"
            value={userProfile.lastName}
            onChange={handleInputChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input
            type="email"
            name="email"
            id="email"
            value={userProfile.email}
            onChange={handleInputChange}
            required
          />
        </FormGroup>
        <Button color="primary" type="submit">Update Profile</Button>
      </Form>
    </div>
  );
}