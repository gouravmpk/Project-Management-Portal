import Card from 'react-bootstrap/Card';
import axios from 'axios';
import React,{useEffect, useState, useRef} from 'react'
import { Col, Row } from 'react-bootstrap';


function Cards() {

  const [projectDetails,setprojectDetails]=useState()
  const [taskDetails, settaskDetails] = useState()
  const [userDetails, setuserDetails] = useState()

      useEffect(()=>{
        const fetchPostList=async ()=>{
            const project =await axios("https://localhost:7223/api/Project")
                      
            setprojectDetails(project.data.length)
            

            const task = await axios("https://localhost:7223/api/Task")
          
            settaskDetails(task.data.length)
            const { user } = await axios("https://localhost:7223/api/User")
           
            setuserDetails(user.data.length)
            console.log(user.data.length)
            
        }
        fetchPostList()
    },[])

    

 

  return (
   <div >

   
    <Card className ="card">
      <Card.Body>
        <Card.Title>Projects</Card.Title>
        <Card.Subtitle className="mb-2 text-muted"> <br/>Total Projects: {projectDetails}</Card.Subtitle>
        
      </Card.Body>
    </Card>
    
    <Card className ="card">
      <Card.Body>
        <Card.Title>Tasks</Card.Title>
        <Card.Subtitle className="mb-2 text-muted"> <br/>Total Tasks: {taskDetails}</Card.Subtitle>
        
      </Card.Body>
    </Card>
    
    {/* <Card style={{ width: '18rem' }}>
      <Card.Body>
        <Card.Title>Users</Card.Title>
        <Card.Subtitle className="mb-2 text-muted"> <br/>Total Users: {userDetails}</Card.Subtitle>
        
      </Card.Body>
    </Card> */}
   </div> 
  );
}

export default Cards;