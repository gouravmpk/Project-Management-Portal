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

export default function UpdateProject(props) {
     const [name, setName] = useState(props.projectName)
     const [status, setStatus] = useState("")
     const [project, setProject] = useState([])
     const [description, setDes] = useState(props.projectDescription);
     const [date, setDate] = useState(props.startDate);
     const [edate, setEDate] = useState(props.endDate);
     const [projectId,setprojectId]=useState(props.projectId);

  const [show, setShow] = useState(false);

  const [viewProject, setviewProject] = useState({ blogs: [] });

  useEffect(() => {
    const fetchPostList = async () => {
      const { data } = await axios("https://localhost:7223/api/Project/Id?projectId="+props.projectId);

      setviewProject({ blogs: data });
      console.log(data);
    };
    fetchPostList();
  }, [setviewProject]);

function updateUser()
{
  let item={name,description,date,edate,projectId}
  console.log("item",item)
  
  // setName(item.name);
  // setDes(item.description);
  // setDate(item.date);
  // setEDate(item.edate);
  // setprojectId(item.projectId);
  // setStatus(item.status);

   const res = axios.put('https://localhost:7223/api/Project/Id',{ projectId:projectId,projectName:name,projectDescription:description,endDate:edate})
   .then((res) => {
    if (res.status === 202) {
      console.log(res);
        Swal.fire({
          text: "Project Updated successfully.", 
          type: "success"
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
            Update Project Details
          </Modal.Title>
        </Modal.Header>

        {viewProject.blogs &&
          viewProject.blogs.map((item) => (


            <Modal.Body style={{ height: "400px", textAlign: "center" }}>
       
      <InputGroup>
        <InputGroup.Text  style={{'width':'47%'}}>Project Name</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={name} onChange={(e)=>{setName(e.target.value)} } /> 
      </InputGroup><br/>
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}} >Project Description</InputGroup.Text>
         <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={description} onChange={(e)=>{setDes(e.target.value)}} /> 
      </InputGroup><br/>
      {/* <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Start Date</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}} value={date} onChange={(e)=>{setDate(e.target.value)}} /> 
      </InputGroup><br/> */}
      <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>End Date</InputGroup.Text>
        <input type="date" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}}  value={edate} onChange={(e)=>{setEDate(e.target.value)}} /> 
      </InputGroup><br/>
      {/* <InputGroup>
        <InputGroup.Text style={{'width':'47%'}}>Project Status</InputGroup.Text>
        <input type="text" style={{'width':'50%','marginLeft':'10px','borderRadius':'0.5em'}}  value={status} onChange={(e)=>{setStatus(e.target.value)}} /> 
      </InputGroup><br/> */}
      <p>

      </p>
      <Button style={{'alignContent':'center'}} variant="dark" onClick={updateUser}>Submit</Button>

            </Modal.Body>
         ))}
      </Modal>
    </>
  );
}
