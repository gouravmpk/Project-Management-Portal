import React, { useState } from "react";
import Dropdown from "react-bootstrap/Dropdown";
import Swal from "sweetalert2";
function UpdateTaskStatus(props) {
  const [selected, setSelected] = useState(props.title);
  console.log(selected);
  console.log(props.title)
  const [status,setstatus]=useState(props.title);

  const handleChange = (event) => {
    console.log(event.target.value);
    setstatus(event.target.value);
    var Id=0;
    if(event.target.value==="To Do")
    Id=1
    else if(event.target.value==="In Progress")
    Id=2
    else
    Id=3
    console.log(Id)

    fetch(
      `https://localhost:7223/api/Task/Status?taskId=${props.taskId}&taskStatus=${Id}`,
      {
        method: "PUT",
      }
    ).then((res) => {
      if (res.status === 202) {
        setSelected(event.target.value);
        Swal.fire({
          text: "Task Status updated successfully.",
          icon: "success"
        })
      }
    });
    setSelected(event.target.value);
  };
  return (
    <div>
      <select value={status} onChange={handleChange} >
        <option key={"1"} value="To Do">
          To Do
        </option>
        <option key={"2"} value="In Progress">
          In Progress
        </option>
        <option key={"3"} value="Done">
          Done
        </option>
      </select>
    </div>
  );
}

export default UpdateTaskStatus;
