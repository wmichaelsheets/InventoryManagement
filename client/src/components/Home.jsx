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
                This is your inventory management dashboard. From here, you can manage your inventory, view reports, and more.
              </CardText>
              <Button color="primary" tag={Link} to="/inventory">
                View Inventory
              </Button>
            </CardBody>
          </Card>
        </Col>
      </Row>
      <Row className="mt-4">
        <Col md={4}>
          <Card>
            <CardBody>
              <CardTitle tag="h5">Quick Stats</CardTitle>
              <CardText>
                Total Items: X<br />
                Low Stock Items: Y<br />
                Out of Stock Items: Z
              </CardText>
            </CardBody>
          </Card>
        </Col>
        <Col md={4}>
          <Card>
            <CardBody>
              <CardTitle tag="h5">Recent Activity</CardTitle>
              <CardText>
                • Item A added<br />
                • Item B updated<br />
                • Item C removed
              </CardText>
            </CardBody>
          </Card>
        </Col>
        <Col md={4}>
          <Card>
            <CardBody>
              <CardTitle tag="h5">Quick Actions</CardTitle>
              <Button color="secondary" className="me-2 mb-2">Add Item</Button>
              <Button color="secondary" className="me-2 mb-2">Generate Report</Button>
              <Button color="secondary" className="me-2 mb-2">Manage Users</Button>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
}