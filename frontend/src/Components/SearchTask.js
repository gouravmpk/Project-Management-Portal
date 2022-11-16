import React,{useEffect,useState} from 'react'

function SearchTask(props) {
    const[data,setData]=useState(props.name);
    const[filterVal,setFilterVal]=useState('');
//  const[searchApiData,setSearchApiData]=useState('');
    const fetchData= async()=>{
        console.log(filterVal)
        let result= 
        await fetch(`https://localhost:7223/api/Task/Name?taskName=${filterVal}`,
            {
              method: "GET",
            }
          )
        result.json().then((res)=>{
            props.setTaskList(res);
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

export default SearchTask