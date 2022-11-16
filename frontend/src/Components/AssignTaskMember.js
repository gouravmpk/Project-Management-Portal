
import React,{ useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from "axios";
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import Dropdown from './Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import { useResolvedPath } from 'react-router-dom';
import Swal  from 'sweetalert2';


function AssignTaskMember(props) {
  const [items, setItems] = useState([]);
  const [selected, setSelected] = useState(props.title);
  console.log(selected);
//   const [inputValue, setValue] = useState('');
//   const [selectedValue, setSelectedValue] = useState(null);


//   // handle input change event
//   const handleInputChange = value => {
//     setValue(value);
//   };
//   // handle selection
//   const handleChange = value => {
//     setSelectedValue(value);
//   }
  
 
  useEffect(()=>{
    axios.get("https://localhost:7223/api/ProjectAssignment/projectId?projectId="+props.projectId).then(result => {
        setItems(result.data)
        console.log(items)
        console.log(result.data)
        }); 

  },[])

  //onchange
// const AssignHandler=(event)=>{
//     console.log(event.target.value)
//     fetch(`https://localhost:7223/api/TaskAssignment?userId=${event.target.value}&taskId=${props.taskId}`,{
//       method: "POST",
//     }).then((res) => {
//       if (res.status === 201) {
//         setSelected(event.target.value);
//         console.log(res);
//           Swal.fire({
//             text: "Member assigned to the task.", 
//             type: "success"
//           })
//         .then (function(){ 
        
//         });
//         setSelected(event.target.value);
//       }
      
//     });
// }


const assignMember = (value) =>{
    fetch(`https://localhost:7223/api/TaskAssignment?userId=${value}&taskId=${props.taskId}`,{
      method: "POST",
    }).then((res) => {
      if (res.status === 201) {
        setSelected(value);
        console.log(res);
          Swal.fire({
            text: "Member assigned to the task.", 
            icon: "success"
          })
        .then (function(){ 
            
        });
        setSelected(value);
      }
      
    });
}


//   useEffect(() => {
//     const fetchData = () => {
//         return  axios.get("https://localhost:7223/api/ProjectAssignment/projectId?projectId="+props.projectId).then(result => {
//         setItems(result.data)  
//         console.log(items)
//         console.log(result.data)
//         const res =  result.data[0].firstName;
//           console.log(res)
//           return res;
//         });
//       }
//   });
  

return (


    <div className='container'>
        {/* <div className='row alert alert-info'>Selected Value:{JSON.stringify(selectedValue || {}, null, 2)}</div> */}
        <div className='row'>

            <div className='=col-md-4'></div>

            <Dropdown assignTaskMember={assignMember} datas={items}/>

            
                {/* <Dropdown datas={items} assign={AssignHandler}/> */}
                
        
            
        </div>
        </div>
 );
}
export default AssignTaskMember
