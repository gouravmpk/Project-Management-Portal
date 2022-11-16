import React, { useState } from 'react';
import InputField from './InputField';
import api from './Constants';
import '../Styles/Styles.css'
import logo from '../img/login.png'
import { useNavigate } from 'react-router-dom';
import NameOfProject from './Constants';

function Login(props) {
const history = useNavigate()

  const [input, setInput] = useState({
    emailId: '',
    password: '',
    confirmPassword: ''
  });

  const [error, setError] = useState({
    emailId: '',
    password: '',
    confirmPassword: ''
  })

  const onInputChange = e => {
    const { name, value } = e.target;
    setInput(prev => ({
      ...prev,
      [name]: value
    }));
    validateInput(e);
  }

  const validateInput = e => {
    let { name, value } = e.target;
    setError(prev => {
      const stateObj = { ...prev, [name]: "" };

      switch (name) {
        case "emailId":
          if (!value) {
            stateObj[name] = "Please enter emailId.";
          }
          break;

        case "password":
          if (!value) {
            stateObj[name] = "Please enter Password.";
          } else if (input.confirmPassword && value !== input.confirmPassword) {
            stateObj["confirmPassword"] = "Password and Confirm Password does not match.";
          } else {
            stateObj["confirmPassword"] = input.confirmPassword ? "" : error.confirmPassword;
          }
          break;  

        case "confirmPassword":
          if (!value) {
            stateObj[name] = "Please enter Confirm Password.";
          } else if (input.password && value !== input.password) {
            stateObj[name] = "Password and Confirm Password does not match.";
          }
          break;

        default:
          break;
      }

      return stateObj;
    });
  }
  const redirect = (e)=>{
    {props.setIsRegistered(false)}
  }
  const login=(e)=> {
    e.preventDefault();
    
    fetch(api + 'user/Login', {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            "emailId": input.emailId,
            "password": input.password
        })
    }).then((res) => {
            if (res.status === 202) {
                alert('user Logged in '+res.status)
                history("/Home")

            } else {
                alert('User Not Found ' + res.status)
            }
        }) 
  }
  
  return (
    <div className="wrapper">
      <div className='logo'>
          <img src={logo} title="User Logo" />
        </div>
        <br/>
        <h3>
         Project CLUB</h3>
        
      <form  className="p-3 mt-3">

        <InputField
          type="email"
          name="emailId"
          placeholder='Email Id'
          value={input.emailId}
          onChange={onInputChange}
          onBlur={validateInput}/>
        {error.emailId && <span className='err'>{error.emailId}</span>}

        <InputField
          type="password"
          name="password"
          placeholder='Enter Password'
          value={input.password}
          onChange={onInputChange}
          onBlur={validateInput}/>
        {error.password && <span className='err'>{error.password}</span>}

        <InputField
          type="password"
          name="confirmPassword"
          placeholder='Enter Confirm Password'
          value={input.confirmPassword}
          onChange={onInputChange}
          onBlur={validateInput}/>
        {error.confirmPassword && <span className='err'>{error.confirmPassword}</span>}

        <button className="btn mt-3" onClick={login}>Login</button>
      
      
        <label ><br/>Don't have an account?</label>
        <button className="btn mt-3" onClick={()=>props.onChange(false) }>Create Account</button>
      </form>
    </div>
  );
}

export default Login;