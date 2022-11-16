import React, { useState } from 'react';
import { Modal, Form, Button, FloatingLabel } from 'react-bootstrap'
import { useNavigate } from 'react-router-dom';
import Swal from 'sweetalert2';
import api from './Constants';
import logo from '../img/login.png'

export default function AddTask() {
  const [input, setInput] = useState({})
  const [show, setShow] = useState(false);
  const history = useNavigate()

  const Submit=(e)=>{
    e.preventDefault();
  fetch(api+'Task',{
      method:'POST',
      headers:{
          'Accept':'application/json',
          'Content-Type':'application/json'
      },
      body: JSON.stringify({
          "taskName": input.taskName,
          "taskDescription": input.taskDescription,
          "projectId": input.projectId,
          "dueDate":input.dueDate,
      })
  }).then(res=> {
      if(res.status === 201){
        Swal.fire({
            icon:"success",
            text:"Task Created"
        })
        history('/task')
      }else{
        Swal.fire({
        icon:"error",
        text:"Task Creation Failed"
    })
      }
  })
}

  
  const handleClose = () => {
    history("/Task")
  };
  return (
    <div className='wrapper'>
      <Form>
      <div className='logo'>
          <img src={logo} title="User Logo" />
        </div>
        <br/>
        <h3>
         Add New Task</h3>
        <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
          <FloatingLabel
            controlId="floatingInput"
            label="Task Name"
            className="mb-3"
          >
            <Form.Control
              type="text"
              placeholder="Task Name"
              autoFocus
              value={input.taskName}

              onChange={(e) => { setInput({ ...input, taskName: e.target.value }) }}

            />
          </FloatingLabel>

        </Form.Group>
        <Form.Group
          className="mb-3"
          controlId="exampleForm.ControlTextarea1"
        >
          <FloatingLabel
            controlId="floatingInput"
            label="Task Description"
            className="mb-3"
          >
            <Form.Control
              type="textarea"
              placeholder="Task Description"
              autoFocus
              value={input.taskDescription}

              onChange={(e) => { setInput({ ...input, taskDescription: e.target.value }) }}
            />
          </FloatingLabel>
        </Form.Group>
          <Form.Group
            className="mb-3"
            controlId="exampleForm.ControlTextarea1"
          >
            
        <FloatingLabel
          controlId="floatingInput"
          label="Project Id"
          className="mb-3"
        >
            <Form.Control
              type="text"
              placeholder="Project Id"
              autoFocus
              value={input.projectId}

              onChange={(e) => { setInput({ ...input, projectId: e.target.value }) }}
            />
            
        </FloatingLabel>
          </Form.Group>
        
          <Form.Group
            className="mb-3"
            controlId="exampleForm.ControlTextarea1"
          ><FloatingLabel
          controlId="floatingInput"
          label="Due Date"
          className="mb-3"
        >
            <Form.Control
              type="date"
              placeholder="Due Date"
              autoFocus
              value={input.dueDate}

              onChange={(e) => { setInput({ ...input, dueDate: e.target.value }) }}
            />
            
        </FloatingLabel>
          </Form.Group>
        

      </Form>


      <Button variant="primary" onClick={Submit}>
        Add Task
      </Button>
      <Button variant="secondary" onClick={handleClose}>
        Close
      </Button>
    </div>
  )
}
