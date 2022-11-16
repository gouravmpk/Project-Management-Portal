import React, { useEffect, useState } from "react";
import {AssignTaskMember} from './AssignTaskMember'
import { useNavigate } from "react-router-dom";
export default function Dropdown(props) {
  const [listSelected, setListSelected] = useState([]);
  const [value, setValue] = useState("");
    const navigate = useNavigate();


  useEffect(() => {

    if(value!==""){
        console.log("in useeffect")
        props.assignTaskMember(value);
    }

    var names = [];
    console.log(props.datas);
    for (let i = 0; i < props.datas.length; i++) {
        const temp = {};
      temp['firstName'] = props.datas[i].firstName;
      temp['lastName'] = props.datas[i].lastName;
      temp['userId'] = props.datas[i].userId;
      names.push(temp);
    }
    setListSelected(names);
    
    console.log(listSelected);
    // <AssignTaskMember ></AssignTaskMember>
  }, [value,props.datas]);

  const handleChange =async (e) => {

    console.log("in handle change");
     setValue(e.target.value);
    
  }


  return (
    <div>

      <select value={props.value} onChange={handleChange}>
        
        {listSelected.length>0 && listSelected.map((list) => {
           return (<option value={list.userId}>{list.firstName} {list.lastName}</option>)
        // return <option>{list}</option>
        })}
      </select>
    </div>
  );
}
