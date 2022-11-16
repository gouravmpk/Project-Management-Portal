import React,{useEffect,useState} from 'react'
import Form from 'react-bootstrap/Form';
import InputGroup from 'react-bootstrap/InputGroup';
import { Button, Container } from 'react-bootstrap';

function Search(props) {
    const[data,setData]=useState(props.name);
    const[filterVal,setFilterVal]=useState('');
//  const[searchApiData,setSearchApiData]=useState('');
    const fetchData= async()=>{
        console.log(filterVal)
        let result= 
        await fetch(`https://localhost:7223/api/Project/Name?projectName=${filterVal}`,
            {
              method: "GET",
            }
          )
        result.json().then((res)=>{
            props.setProjectList(res);
        })
    }
    // useEffect(()=>{    
    //     fetchData();
    // },[filterVal])
    const handleFilter=(e)=>{
        if(e.target.value==''){
             setData(setFilterVal)
        }
        else{
            setFilterVal(e.target.value)
            // searchApiData.filter(item=>item.name.toLowerCase().includes(e.target.value.toLowerCase()))
        }
        
    }
  return (
    
      <div className='button'>
        <input  style={{'width':'400px','borderRadius':'0.10em','border':'2px solid black'}} placeholder='Search' value={filterVal} onChange={(e)=>handleFilter(e)}/>
        <button style={{'borderRadius':'0.5em','border':'none','width':'80px','marginLeft':'15px','backgroundColor':'cornflowerblue'}}onClick={fetchData}>Search</button>
      </div>

    
  )
}

export default Search