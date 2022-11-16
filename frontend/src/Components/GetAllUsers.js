import axios from 'axios';
import React,{useState} from 'react';
import AsyncSelect from 'react-select/async';

function GetAllUsers(){
    const[items,setItems]=useState([]);
    const[inputValue,setValue]=useState('')
    const[selectedValue,setSelectedValue]=useState(null);


    const handleInputChange=value=>{
        setValue(value);
    };

    const handleChange=value=>{
        return axios.get('')
    }
}