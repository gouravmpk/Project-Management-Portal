import React, { useState } from 'react';
import InputField from './InputField';
import api from './Constants';
import '../Styles/Styles.css'
import logo from '../img/login.png'
import Form from 'react-bootstrap/Form';
import { useNavigate } from 'react-router-dom';
import NameOfProject from './Constants';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Swal from 'sweetalert2';
import { Container } from 'react-bootstrap';
function Login(props) {
  const history = useNavigate()

  const [input, setInput] = useState({});

  const [error, setError] = useState({
    emailId: '',
    password: '',

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
    e.preventDefault();
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
  const redirect = (e) => {
    history("/Register")
  }
  const login = (e) => {
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
        res.json().then((data) => {
          var authToken = data.token;
          var isAdmin=data.isAdmin

          localStorage.setItem("authToken", authToken)
          localStorage.setItem("isAdmin",isAdmin)
          
        }
        )
        history("/Home")
      } else {
        Swal.fire({
          text: "Wrong Email or Password",
          icon: "error"

        })

      }
    })
  }
  

  return (
    
    <Container >
    <div className="wrapper">
      <div className='logo'>
        <img src={logo} title="User Logo" />
      </div>
      <br />
      <h3>Project CLUB</h3>

      <Form className="p-3 mt-3">
        <FloatingLabel
          controlId="floatingInput"
          label="Email address"
          className="mb-3"
        >

          <Form.Control
            type="email"
            value={input.emailId}
            placeholder='Email Id'
            onChange={(e) => { setInput({ ...input, emailId: e.target.value }) }}
            onBlur={validateInput} />
        </FloatingLabel>
        {error.emailId && <span className='err'>{error.emailId}</span>}

        <FloatingLabel
          controlId="floatingInput"
          label="Password"
          className="mb-3">
          <Form.Control
            type="password"
            value={input.password}
            placeholder='Password'
            onChange={(e) => { setInput({ ...input, password: e.target.value }) }}
            onBlur={validateInput} />
        </FloatingLabel>
        {error.password && <span className='err'>{error.password}</span>}


        <button className="btn mt-3" onClick={login}>Login</button>


        <label ><br />Don't have an account?</label>
        <button className="btn mt-3" onClick={redirect}>Create Account</button>
      </Form>
    </div></Container>
  );
}

export default Login;