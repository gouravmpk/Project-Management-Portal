import React, { useEffect, useState } from "react";
import axios from "axios";
import Modal from "react-bootstrap/Modal";
import * as ReactBootStrap from "react-bootstrap";
import { BsEyeFill } from "react-icons/bs";
import Card from "react-bootstrap/Card";
import { FaUserAlt } from 'react-icons/fa'

export default function ProfileTemp(props) {
  const [show, setShow] = useState(false);

  const [viewTask, setviewTask] = useState({ blogs: [] });

  useEffect(() => {
    const fetchPostList = async () => {
      const { data } = await axios("https://localhost:7223/api/User/Id?userId="+props.userId);
      setviewTask({ blogs: data });
      console.log(data);
    };
    fetchPostList();
  }, [props.userId]);
  

  return (
    <>
    <ReactBootStrap.Button variant="outline-light"   onClick={()=>setShow(true)}><FaUserAlt id='user' />{' '}</ReactBootStrap.Button>{' '}
      {/* <ReactBootStrap.Button
        variant="outline-dark"
        onClick={() => setShow(true)}
      >
        <BsEyeFill />
      </ReactBootStrap.Button>
       */}

      <Modal
        show={show}
        onHide={() => setShow(false)}
        dialogClassName="modal-90w"
        aria-labelledby="example-custom-modal-styling-title"
      >
        <Modal.Header closeButton>
          <Modal.Title
            id="example-custom-modal-styling-title"
            style={{ textAlign: "center" }}
          >
            User Details
          </Modal.Title>
        </Modal.Header>

        {viewTask.blogs &&
          viewTask.blogs.map((item) => (
            <Modal.Body style={{ height: "600px", textAlign: "center" }}>
              
              <Card style={{ height: "100px" }}>
                <Card.Header>First Name</Card.Header>
                <Card.Body>
                  <Card.Title>{item.firstName}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "100px" }}>
                <Card.Header>Last Name</Card.Header>
                <Card.Body>
                  <Card.Title>{item.lastName}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "100px" }}>
                <Card.Header>EmailID</Card.Header>
                <Card.Body>
                  <Card.Title>{item.emailId}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "100px" }}>
                <Card.Header>Phone Number</Card.Header>
                <Card.Body>
                  <Card.Title>{item.phoneNumber}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "100px" }}>
                <Card.Header>Location</Card.Header>
                <Card.Body>
                  <Card.Title>{item.location}</Card.Title>
                </Card.Body>
              </Card>

            </Modal.Body>
          ))}
      </Modal>
    </>
  );
}
