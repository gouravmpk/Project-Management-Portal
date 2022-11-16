import React, { Component, useEffect, useState } from 'react'
import axios from 'axios'
import * as ReactBootStrap from 'react-bootstrap';
import { FiUsers } from 'react-icons/fi';
import { GrStatusInfo } from 'react-icons/gr';
import { Navbar, NavLink, NavItem, Nav } from 'react-bootstrap';
import { MdAddTask } from 'react-icons/md'
import { useNavigate } from "react-router-dom";
import ViewProject from './ViewProject';
import UpdateProject from './UpdateProject';
import DeleteProject from './DeleteProject';
import DropdownButton from 'react-bootstrap/DropdownButton';
import UpdateProjectStatus from './UpdateProjectStatus';
import Search from './Search';
import NavigateTo from './NavigateTo'
import AddProjectTemp from './AddProjectTemp';
import AssignProjectMember from './AssignProjectMember';

const ProjectTable = () => {
  const history = useNavigate()

  const GoTo = (e) => {
    // history("/AddProject")
    //addModal
  }
  const [projectDetails, setprojectDetails] = useState({ blogs: [] })
  // const [stateData,setValue]=useState("")

  const fetchPostList = async () => {
    const { data } = await axios("https://localhost:7223/api/Project")
    setprojectDetails({ blogs: data })
    console.log(data)

  }
  useEffect(() => {

    fetchPostList();
  }, []);

  const getDetails = (projectList) => {
    console.log(projectList);
    setprojectDetails({ blogs: projectList });
  }
  // const searchHandle= async(event)=>{
  // let filter=event.target.value
  // let result= await fetch(`https://localhost:7223/api/Project/Name?projectName=${filter}`);
  // result=await result.json()
  // if(result)
  // {
  //   setprojectDetails(result)
  // }  

  // }
  const [admin, setAdmin]=useState(false)

  useEffect(()=>{

    console.log(localStorage.getItem("isAdmin"), admin)

    setAdmin(localStorage.getItem("isAdmin"))

   })

  return (
    <div>
      <NavigateTo />

      <br />
      <div style={{ display: 'flex', justifyContent: 'space-between',margin: '2rem' }}>
      
      {(admin === "true") ? <AddProjectTemp/>:<div></div>}
        <Search setProjectList={getDetails} />
       </div>

      <p></p>
      <ReactBootStrap.Table striped bordered hover size="sm">
        <thead>
          <tr>
            <th style={{ width: '200px' }}>Project Name</th>
            <th style={{ width: '200px' }} >Project Description</th>
            <th style={{ width: '200px' }}>Start Date</th>
            <th style={{ width: '200px' }}>End Date</th>
            <th style={{ width: '200px' }}>Add Members</th>
            <th style={{ width: '200px' }}>Status</th>
            <th style={{ width: '200px' }}>Actions</th>
          </tr>
        </thead>
        <tbody>
          {
            projectDetails.blogs.length > 0 && projectDetails.blogs.map((item) => (
              <tr key={item.projectName}>
                <td>{item.projectName}</td>
                <td>{item.projectDescription}</td>
                <td>{(item.startDate).slice(0, 10)}</td>
                <td>{(item.endDate).slice(0, 10)}</td>


                <td>

                  <FiUsers /> {item.projectMembers}
                  {(admin === "true") ?  <AssignProjectMember projectId={item.projectId} userId={item.userId} />:<div></div>}
                 

                </td>
                <td>
                  
                  <UpdateProjectStatus projectId={item.projectId} status={item.projectMasterId} />
                </td>
                <td>

                  <ViewProject projectId={item.projectId} />{' '}
                  
                 
                  {(admin === "true") ? <UpdateProject projectId={item.projectId} projectName={item.projectName} projectDescription={item.projectDescription} startDate={item.startDate} endDate={item.endDate} /> :<div></div>}{' '}
                  {(admin === "true") ?   <DeleteProject projectId={item.projectId} />:<div></div>}
                  
                </td>
              </tr>
            ))
          }

        </tbody>
      </ReactBootStrap.Table>



    </div>
  )
}

export default ProjectTable
 