
import React, { useState, useEffect } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import './App.css';
import Home from './Components/Home';
import Login from './Components/Login'
import Register from './Components/Register';
import 'bootstrap/dist/css/bootstrap.min.css';
import Login1 from './Components/Login1';
import AddProject from './Components/AddProject';
import ProjectTable from './Components/ProjectTable';
import { Navbar,NavLink,NavItem,Nav } from 'react-bootstrap';
import LandingPage from './Components/LandingPage';
import TaskTable from './Components/TaskTable';
import AddTask from './Components/AddTask';
function App(props) {

  return (
    <BrowserRouter>
 
      <div className="App"  >
        {/* <Home/> */}
        
        <Routes >
     
          <Route exact path="/" element={<Login1/>}></Route>
          <Route exact path="/Register" element={<Register/>}></Route>
          
     
          
        <Route exact path='/Home' element={<Home />}></Route>
          <Route exact path ="/Project" element={<ProjectTable/>}></Route>  
          <Route exact path ="/Task" element={<TaskTable/>}></Route>
        </Routes>
       
       
      </div>
    </BrowserRouter>
  );
}

export default App;
