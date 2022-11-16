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

export default function UpdateTask(props) {
     const [name, setName] = useState(props.taskName)
     const [status, setStatus] = useState("")
     const [task, setTask] = useState([])
     const [description, setDes] = useState(props.taskDescription);
     const [date, setDate] = useState(props.dueDate);
     //const [edate, setEDate] = useState(props.endDate);
     const [taskId,settaskId]=useState(props.taskId);

  const [show, setShow] = useState(false);

  const [viewTask, setviewTask] = useState({ blogs: [] });

  useEffect(() => {
    const fetchPostList = async () => {
      const { data } = await axios("https://localhost:7223/api/Task/Id?taskId="+props.taskId);
  

      setviewTask({ blogs: data });
      console.log(data);
    };
    fetchPostList();
  }, [setviewTask]);

function updateUser()
{
  let item={name,description,date,taskId}
  console.log("item",item)
 

   const res = axios.put('https://localhost:7223/api/Task/Id',{ taskId:taskId,taskName:name,taskDescription:description,dueDate:date})
   .then((res) => {
    if (res.status === 202) {
      console.log(res);
        Swal.fire({
          text: "Task Updated successfully.", 
          icon: "success"
        })
      .then (function(){ 
          window.location.reload();
      })
    }
    
  });
  
}


  return (
    <>
      <ReactBootStrap.Button
        variant="outline-dark"
        onClick={() => setShow(true)}
      >
        <AiFillEdit/>
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
            Update Task Details
          </Modal.Title>
        </Modal.Header>

        {viewTask.blogs &&
          viewTask.blogs.map((item) => (


            <Modal.Body style={{ height: "300px", textAlign: "center" }}>

            <InputGroup>
        <InputGroup.Text  style={{'width':'47%'}}>Task Name</InputGroup.Text>
        
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={name} onChange={(e)=>{setName(e.target.value)} } /> 
      </InputGroup>
      <br/>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Task Description</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={description} onChange={(e)=>{setDes(e.target.value)}} /> 
      </InputGroup>
      <br/>
      <InputGroup>
     
        <InputGroup.Text style={{'width':'47%'}}>Due Date</InputGroup.Text>
        <input type="date" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={date} onChange={(e)=>{setDate(e.target.value)}} /> 
      </InputGroup>
      <br/>
      
     
      <p>

      </p>
      <Button variant="dark" onClick={updateUser}>Submit</Button>

            </Modal.Body>
         ))}
      </Modal>
    </>
  );
}