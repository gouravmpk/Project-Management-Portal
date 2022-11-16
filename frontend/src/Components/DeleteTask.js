import { Axios } from 'axios'
import React, { useEffect, useState } from "react";
import * as ReactBootStrap from "react-bootstrap";
import { AiTwotoneDelete } from "react-icons/ai";
import Swal  from 'sweetalert2';


const DeleteTask = (props) => {
  const deleteHandler = () => {
    fetch("https://localhost:7223/api/Task?taskId=" + props.taskId, {
      method: "DELETE",
    }).then((res) => {
      if (res.status === 200) {
        console.log(res);
          Swal.fire({
            text: "Task deleted successfully.", 
            type: "success"
          })
        .then (function(){ 
            window.location.reload();
        })
      }
      
    });
    
  };

  return(
    <ReactBootStrap.Button
        variant="outline-dark"
        onClick={deleteHandler}
      ><AiTwotoneDelete/></ReactBootStrap.Button>
  )

}




export default DeleteTask






// ("https://localhost:7223/api/Task?taskId="+props.taskId)

