import React, { useEffect, useState } from "react";
import axios from "axios";
import Modal from "react-bootstrap/Modal";
import * as ReactBootStrap from "react-bootstrap";
import { BsEyeFill } from "react-icons/bs";
import Card from "react-bootstrap/Card";

export default function ViewTask(props) {
  const [show, setShow] = useState(false);

  const [viewTask, setviewTask] = useState({ blogs: [] });

  useEffect(() => {
    const fetchPostList = async () => {
      const { data } = await axios("https://localhost:7223/api/Task/Id?taskId="+props.taskId);

      setviewTask({ blogs: data });
      console.log(data);
    };
    fetchPostList();
  }, [props.taskId]);

  return (
    <>
      <ReactBootStrap.Button
        variant="outline-dark"
        onClick={() => setShow(true)}
      >
        <BsEyeFill />
      </ReactBootStrap.Button>
      

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
            Task Details
          </Modal.Title>
        </Modal.Header>

        {viewTask.blogs &&
          viewTask.blogs.map((item) => (
            <Modal.Body style={{ height: "600px", textAlign: "center" }}>
              <Card style={{ height: "95px" }}>
                <Card.Header>Task</Card.Header>
                <Card.Body>
                  <Card.Title>{item.taskName}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>Task Description</Card.Header>
                <Card.Body>
                  <Card.Title>{item.taskDescription}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>Due Date</Card.Header>
                <Card.Body>
                  <Card.Title>{(item.dueDate).slice(0,10)}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "95px" }}>
                <Card.Header>Task Status</Card.Header>
                <Card.Body>
                  <Card.Title>{item.taskStatus}</Card.Title>
                </Card.Body>
              </Card>

              <Card style={{ height: "140px" }}>
                <Card.Header>Task Members</Card.Header>
                <Card.Body>
                  <Card.Title>{item.taskMembersName}</Card.Title>
                </Card.Body>
              </Card>
            </Modal.Body>
          ))}
      </Modal>
    </>
  );
}
