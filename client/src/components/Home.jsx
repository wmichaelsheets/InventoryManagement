import React from 'react';
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';
import { Link } from 'react-router-dom';

export default function Home({ loggedInUser }) {
  return (
    <Container className="mt-4">
      <Row>
        <Col>
          <h1 className="mb-4">Welcome to Inventory Management</h1>
          <Card>
            <CardBody>
              <CardTitle tag="h5">Hello, {loggedInUser.userName}!</CardTitle>
              <CardText>
                Please choose your next action from the Navigation bar, above.
              </CardText>
             
            </CardBody>
          </Card>
        </Col>
      </Row>
     
        
    </Container>
  );
}