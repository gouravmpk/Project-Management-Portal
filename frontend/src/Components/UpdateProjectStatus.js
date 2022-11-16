import React,{useState} from 'react'
import Dropdown from "react-bootstrap/Dropdown";
import Swal from "sweetalert2";
function UpdateProjectStatus(props) {
    const [status,setstatus]=useState(props.status);
    
    const handleChange = (event) => {
      console.log(event.target.value);
      setstatus(event.target.value);
      // var Id=0;
      // if(event.target.value==="Proposed")
      // Id=1
      // else if(event.target.value==="Active")
      // Id=2
      // else
      // Id=3
      // console.log(Id)
      fetch(
        `https://localhost:7223/api/Project/Status?projectId=${props.projectId}&projectMasterId=${event.target.value}`,
        {
          method: "PUT",
        }
      ).then((res) => {
        if (res.status === 202) {
          setstatus(event.target.value);
          console.log(res);
            Swal.fire({
              text: "Project Status Updated successfully.", 
              type: "success"
            })
          .then (function(){ 
              window.location.reload();
          })
        }
      });
      setstatus(event.target.value);
    };
    return (
      <div>
        <select value={status} onChange={handleChange} >
          <option key={"1"} value="1">
            Proposed
          </option>
          <option key={"2"} value="2">
            Active
          </option>
          <option key={"3"} value="3">
            Resolved
          </option>
        </select>
      </div>
    );
  
}

export default UpdateProjectStatus