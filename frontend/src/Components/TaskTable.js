import React, { useEffect, useState } from "react";
import axios from "axios";
import * as ReactBootStrap from "react-bootstrap";
import { AiFillEdit } from "react-icons/ai";
import { FiUsers } from "react-icons/fi";
import { GrStatusInfo } from "react-icons/gr";
import { MdAddTask } from "react-icons/md";
import ViewTask from "./ViewTask";
import UpdateTask from "./UpdateTask";
import DeleteTask from "./DeleteTask";
import SearchTask from './SearchTask'
import UpdateTaskStatus from './UpdateTaskStatus'
import AddTaskTemp from './AddTaskTemp'
import Button from 'react-bootstrap/Button';
import {IoIosAddCircleOutline} from "react-icons/io";
import Dropdown from 'react-bootstrap/Dropdown';
import SplitButton from 'react-bootstrap/SplitButton';
import DropdownButton from 'react-bootstrap/DropdownButton';
import AssignTaskMember from "./AssignTaskMember";
import NavigateTo from "./NavigateTo";


const TaskTable = () => {
  const [taskDetails, settaskDetails] = useState({ blogs: [] });

  // useEffect(() => {
    const fetchPostList = async () => {
      const { data } = await axios("https://localhost:7223/api/Task");

      settaskDetails({ blogs: data });
      console.log(data);
    }
    useEffect(()=>{
        
      fetchPostList();
  },[]);
   

  const getDetails=(taskList)=>{

    console.log(taskList);

    settaskDetails({blogs:taskList});

  }
  const [admin, setAdmin]=useState(false)

  useEffect(()=>{

    console.log(localStorage.getItem("isAdmin"), admin)

    setAdmin(localStorage.getItem("isAdmin"))

   })

  

  return (
    <div>
      
      <NavigateTo/>
      <br/>

      <div style={{ display: 'flex', justifyContent: 'space-between',margin: '2rem' }}>
      
      {(admin === "true") ? <AddTaskTemp/>:<div></div>}
      <SearchTask setTaskList={getDetails}/>
      </div>
      
      <p></p>
      <ReactBootStrap.Table striped bordered hover size="sm">
        <thead>
          <tr>
            <th style={{width:'200px'}}>Task Name</th>
            <th style={{width:'200px'}}>Task Description</th>
            <th style={{width:'200px'}}>Project Name</th>
            <th style={{width:'200px'}}>Due Date</th>
            <th style={{width:'200px'}}>Task Members</th>
            <th style={{width:'200px'}}>Task Status</th>
            <th style={{width:'200px'}}>Actions</th>
          </tr>
        </thead>
        <tbody>
          {
            taskDetails.blogs.map((item) => (
              <tr key={item.taskId}>
                <td>{item.taskName}</td>
                <td>{item.taskDescription}</td>
                <td>{item.projectName}</td>
                <td>{(item.dueDate).slice(0,10)}</td>
                <td>
                  <FiUsers /> {item.taskMembers}
                  {(admin === "true") ?  <AssignTaskMember projectId={item.projectId} userId={item.userId} taskId={item.taskId}/>:<div></div>}
                 
                  {/* <GetAllUsers userId={item.userId}/> */}
           
                </td>
                <td>

            {/* <SplitButton key='Primary' title={item.taskStatus}> */}
                {/* <Dropdown.Item eventKey="1">To Do</Dropdown.Item>
            <Dropdown.Item eventKey="2">In Progress</Dropdown.Item>
            <Dropdown.Item eventKey="3">Done</Dropdown.Item> */}
           <UpdateTaskStatus taskId={item.taskId} title={item.taskStatus}/>
            {/* </SplitButton> */}
               
                
                </td>
                <td>
                  {/* <ReactBootStrap.Button variant="outline-dark"></ReactBootStrap.Button>{' '} */}
                  <ViewTask taskId={item.taskId} />{" "}
                  {/* <UpdateTask taskId={item.taskId} />{" "} */}
                  {/* <ReactBootStrap.Button variant="outline-dark"><AiFillEdit/></ReactBootStrap.Button>{' '} */}
                 
                  {(admin === "true") ? <UpdateTask taskId={item.taskId} taskName={item.taskName} taskDescription={item.taskDescription} dueDate={item.dueDate}/> :<div></div>}{' '}
                  {(admin === "true") ?  <DeleteTask taskId={item.taskId} />:<div></div>}
                    
                </td>
              </tr>
            ))}
        </tbody>
      </ReactBootStrap.Table>
    </div>
  );
};

export default TaskTable;
