import React, { useState } from 'react';
import { Modal, Form, Button, FloatingLabel } from 'react-bootstrap'
import { useNavigate } from 'react-router-dom';
import Swal from 'sweetalert2';
import api from './Constants';
import logo from '../img/login.png'


export default function AddProject() {
  const [input, setInput] = useState({})
  const [show, setShow] = useState(false);
  const history = useNavigate()

  const Submit = (e) => {

    e.preventDefault();
    fetch(api + 'Project', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        "projectName": input.projectName,
        "projectDescription": input.projectDescription,
        "startDate": input.startDate,
        "endDate": input.endDate,
        "clientName": input.clientName,
        "goalOfProject": input.projectGoal,
        "technologiesUsed": input.technologiesUsed,
      })
    }).then(res => {
      if (res.status === 201) {
        history("/Project")
        Swal.fire({
          text: "Project Created Successfully",
          icon: "success"
        })
      } else {

        Swal.fire({
          text: "Project Not Added",
          icon: "error"
        })
      }
    })
  }

  const addNewProject = () => {
    Submit()
  };
  const handleClose = () => {
    history("/Project")

  };
  return (
    <div className='wrapper'>
      <Form>
      <div className='logo'>
          <img src={logo} title="User Logo" />
        </div>
        <br/>
        <h3>
         Add New Project</h3>
        <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
          <FloatingLabel
            controlId="floatingInput"
            label="Project Name"
            className="mb-3"
          >
            <Form.Control
              type="text"
              placeholder="Project Name"
              autoFocus
              value={input.projectName}

              onChange={(e) => { setInput({ ...input, projectName: e.target.value }) }}

            />
          </FloatingLabel>

        </Form.Group>
        <Form.Group
          className="mb-3"
          controlId="exampleForm.ControlTextarea1"
        >
          <FloatingLabel
            controlId="floatingInput"
            label="Project Description"
            className="mb-3"
          >
            <Form.Control
              type="textarea"
              placeholder="Project Description"
              autoFocus
              value={input.projectDescription}

              onChange={(e) => { setInput({ ...input, projectDescription: e.target.value }) }}
            />
          </FloatingLabel>
        </Form.Group>
          <Form.Group
            className="mb-3"
            controlId="exampleForm.ControlTextarea1"
          >
            
        <FloatingLabel
          controlId="floatingInput"
          label="Start Date"
          className="mb-3"
        >
            <Form.Control
              type="date"
              placeholder="Start Date"
              autoFocus
              value={input.startDate}

              onChange={(e) => { setInput({ ...input, startDate: e.target.value }) }}
            />
            
        </FloatingLabel>
          </Form.Group>
        
          <Form.Group
            className="mb-3"
            controlId="exampleForm.ControlTextarea1"
          ><FloatingLabel
          controlId="floatingInput"
          label="End Date"
          className="mb-3"
        >
            <Form.Control
              type="date"
              placeholder="End Date"
              autoFocus
              value={input.endDate}

              onChange={(e) => { setInput({ ...input, endDate: e.target.value }) }}
            />
            
        </FloatingLabel>
          </Form.Group>
        
        <Form.Group
          className="mb-3"
          controlId="exampleForm.ControlTextarea1"
        >
          <FloatingLabel
          controlId="floatingInput"
          label="Client Name"
          className="mb-3"
        >     
            <Form.Control
              type="text"
              placeholder="Client Name"
              autoFocus
              value={input.clientName}

              onChange={(e) => { setInput({ ...input, clientName: e.target.value }) }}
            />
            </FloatingLabel>
          </Form.Group>
             <Form.Group
          className="mb-3"
          controlId="exampleForm.ControlTextarea1"
        ><FloatingLabel
        controlId="floatingInput"
        label="Project Goal"
        className="mb-3"
      >
            <Form.Control
              type="text"
              placeholder="Project Goal"
              autoFocus
              value={input.projectGoal}

              onChange={(e) => { setInput({ ...input, projectGoal: e.target.value }) }}
            />
        </FloatingLabel>
          </Form.Group>
       
          <Form.Group
            className="mb-3"
            controlId="exampleForm.ControlTextarea1"
          >
          <FloatingLabel
            controlId="floatingInput"
            label="Technologies Used"
            className="mb-3"
          >
            <Form.Control
              type="textarea"
              placeholder="Technologies Used"
              autoFocus
              value={input.technologiesUsed}

              onChange={(e) => { setInput({ ...input, technologiesUsed: e.target.value }) }}
            />
        </FloatingLabel>
      
          </Form.Group>

      </Form>


      <Button variant="primary" onClick={Submit}>
        Add Project
      </Button>
      <Button variant="secondary" onClick={handleClose}>
        Close
      </Button>
    </div>
  )
}
