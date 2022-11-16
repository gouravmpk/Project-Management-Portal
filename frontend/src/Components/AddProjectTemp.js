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

export default function AddProjectTemp() {
     const [name, setName] = useState("")
     const [description, setDes] = useState("");
     const [startDate, setStartDate] = useState("");
     const [endDate, setEndDate] = useState("");
     const[clientName,setClientName]=useState("");
     const[goalOfProject,setGoal]=useState("");
     const[technologies,setTechnologies]=useState("");

    const [show, setShow] = useState(false);





function AddProject(e)
{
    e.preventDefault();
    fetch('https://localhost:7223/api/Project', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        "projectName": name,
        "projectDescription": description,
        "startDate": startDate,
        "endDate":endDate,
        "clientName":clientName,
        "goalOfProject":goalOfProject,
        "technologiesUsed":technologies,
      })
    }).then(res => {
      if (res.status === 201) {
        Swal.fire({
          text: "Project Created Successfully",
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
        <MdAddTask /> Add Project
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
            Add New Project
          </Modal.Title>
        </Modal.Header>


            <Modal.Body style={{ height: "400px", textAlign: "center" }}>

            <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Project Name</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={name} onChange={(e)=>{setName(e.target.value)} } /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Project Description</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={description} onChange={(e)=>{setDes(e.target.value)}} /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Start Date</InputGroup.Text>
        <input type="date" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={startDate} onChange={(e)=>{setStartDate(e.target.value)}} /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>End Date</InputGroup.Text>
        <input type="date" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={endDate} onChange={(e)=>{setEndDate(e.target.value)}} /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Client Name</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={clientName} onChange={(e)=>{setClientName(e.target.value)}} /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Goal Of project</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={goalOfProject} onChange={(e)=>{setGoal(e.target.value)}} /> 
      </InputGroup>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Technologies Used</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={technologies} onChange={(e)=>{setTechnologies(e.target.value)}} /> 
      </InputGroup>
      <p>

      </p>
      <Button variant="dark" onClick={AddProject}>Submit</Button>

            </Modal.Body>
         
      </Modal>
    </>
  );
}