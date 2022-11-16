import React, { useEffect, useState } from "react";
import axios from "axios";
import Button from "react-bootstrap/Button";
import Modal from "react-bootstrap/Modal";
import * as ReactBootStrap from "react-bootstrap";
import { AiFillEdit } from "react-icons/ai";
import Card from "react-bootstrap/Card";
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import Swal from "sweetalert2";
import { MdAddTask } from "react-icons/md";
import './Constants'

export default function AddTaskTemp() {
     const [name, setName] = useState("")
     //const [status, setStatus] = useState("")
     const [projectId, setprojectId] = useState("")
     const [description, setDes] = useState("");
     const [date, setDate] = useState("");
     //const [edate, setEDate] = useState(props.endDate);
    //  const [taskId,settaskId]=useState(props.taskId);

    const [show, setShow] = useState(false);
//   const [viewTask, setviewTask] = useState({ blogs: [] });




//   useEffect(() => {
//     const fetchPostList = async () => {
//       const { data } = await axios("https://localhost:7223/api/Task"+props.taskId);
//       setviewTask({ blogs: data });
//       console.log(data);
//     };
//     fetchPostList();
//   }, [setviewTask]);

function AddTask(e)
{
    e.preventDefault();
    fetch('https://localhost:7223/api/Task', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        "taskName": name,
        "taskDescription": description,
        "dueDate": date,
        "projectId":projectId,
      })
    }).then(res => {
      if (res.status === 201) {
        Swal.fire({
          text: "Task Created Successfully",
          icon: "success"
        })
        .then(function(){
            window.location.reload()
          })
      } else {

        Swal.fire({
          text: "Project Not Added",
          icon: "error"
        })
        .then(function(){
            window.location.reload()
          })
      }
    })
    
  
}


  return (
    <>
       <ReactBootStrap.Button onClick={()=>setShow(true)}
        variant="outline-dark"
        style={{ display: "flex", justifyContent: "left" }}
      >
        <MdAddTask /> Add Task
      </ReactBootStrap.Button >{" "}
   
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
            Add New Task
          </Modal.Title>
        </Modal.Header>


            <Modal.Body style={{ height: "300px", textAlign: "center" }}>

            <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Task Name</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={name} onChange={(e)=>{setName(e.target.value)} } /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Task Description</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={description} onChange={(e)=>{setDes(e.target.value)}} /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Project Id</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={projectId} onChange={(e)=>{setprojectId(e.target.value)}} /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Due Date</InputGroup.Text>
        <input type="date" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={date} onChange={(e)=>{setDate(e.target.value)}} /> 
      </InputGroup>
      
     
      <p>

      </p>
      <Button variant="dark" onClick={AddTask}>Submit</Button>

            </Modal.Body>
         
      </Modal>
    </>
  );
}