import React, { useEffect, useState } from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import * as ReactBootStrap from "react-bootstrap";
import { BsEyeFill } from "react-icons/bs";
import Card from "react-bootstrap/Card";

export default function ViewProject(props) {
  const [show, setShow] = useState(false);
  const [viewProject, setviewProject] = useState({ blogs: [] });

  useEffect(() => {
    const fetchPostList = async () => {
      const { data } = await axios("https://localhost:7223/api/Project/Id?ProjectId="+props.projectId);

      setviewProject({ blogs: data });
      console.log(data);
    };
    fetchPostList();
  }, [setviewProject]);

  return (
    <>
      <ReactBootStrap.Button
        variant="outline-dark"
        onClick={() => setShow(true)}
      >
        <BsEyeFill />
      </ReactBootStrap.Button>
      <Modal
        className="hello"
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
            Project Details
          </Modal.Title>
        </Modal.Header>

        {viewProject.blogs &&
          viewProject.blogs.map((item) => (
            <Modal.Body style={{ height: "740px", textAlign: "center" }}>
              <Card style={{ height: "95px" }}>
                <Card.Header>Project Name</Card.Header>
                <Card.Body>
                  <Card.Title>{item.projectName}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>Project Description</Card.Header>
                <Card.Body>
                  <Card.Title>{item.projectDescription}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>Start Date</Card.Header>
                <Card.Body>
                  <Card.Title>{(item.startDate).slice(0,10)}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>End Date</Card.Header>
                <Card.Body>
                  <Card.Title>{(item.endDate).slice(0,10)}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>Project Status</Card.Header>
                <Card.Body>
                  <Card.Title>{item.projectStatus}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "110px" }}>
                <Card.Header>Project Members</Card.Header>
                <Card.Body>
                  <Card.Title>{item.projectMembersName}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>Total Members</Card.Header>
                <Card.Body>
                  <Card.Title>{item.projectMembers}</Card.Title>
                </Card.Body>
              </Card>
            </Modal.Body>
          ))}
      </Modal>
    </>
  );
}
