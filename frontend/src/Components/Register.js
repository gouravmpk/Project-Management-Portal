import React from 'react'
import { useState } from 'react'
import { Form ,Container,Row,Col} from 'react-bootstrap';
import api from './Constants';
import logo from '../img/login.png'
import { useNavigate } from 'react-router-dom';
import FloatingLabel from 'react-bootstrap/FloatingLabel';
import Swal from 'sweetalert2';

export default function Register(props) {

  const history = useNavigate()
  const [input, setInput] = useState({})
  const [errorf, setErrorf] = useState({
    errors: {},
    isError: false
  })
  const [errorl, setErrorl] = useState({
    errors: "",
    isError: false
  })
  const [errordob, setErrordob] = useState({
    errors: "",
    isError: false
  })
  
  const [errorPhone, setErrorPhone] = useState({
    errors: "",
    isError: false
  })
  
  const [errorDesignation, setErrorDesignation] = useState({
    errors: "",
    isError: false
  })
  
  const [errorDepartment, setErrorDepartment] = useState({
    errors: "",
    isError: false
  })
  
  const [errorEmail, setErrorEmail] = useState({
    errors: "",
    isError: false
  })
  const[errorLocation, setErrorLocation]=useState({
    error:"",
    isError: false
  })
  
  const [errorPassword, setErrorPassword] = useState({
    errors: "",
    isError: false
  })
  const [errorConfirmPassword, setErrorConfirmPassword] = useState({
    errors: "",
    isError: false
  })

  const Validate = (e) => {
    if (input.firstName === undefined || input.lastName === undefined ) {
      setErrorf({
        isError: true,
        errors: "First name is missing",

      })
    }

    if (input.lastName === undefined) {
      setErrorl({
        isError: true,
        errors: "Last name is missing"
      })
    }
    if (input.dateOfBirth === undefined) {
      setErrordob({
        isError: true,
        errors: "Date of Birth is missing"
      })
    }
    if (input.phoneNumber === undefined) {
      setErrorPhone({
        isError: true,
        errors: "Phone Number is missing"
      })
    }
    if (input.designationId === undefined) {
      setErrorDesignation({
        isError: true,
        errors: "Designation is missing"
      })
    }
    if (input.departmentId === undefined) {
      setErrorDepartment({
        isError: true,
        errors: "Department is missing"
      })
    }
    if (input.emailId === undefined) {
      setErrorEmail({
        isError: true,
        errors: "Email Id is missing"
      })
    }
    
    if (input.location === undefined) {
      setErrorLocation({
        isError: true,
        errors: "Location is missing"
      })
    }
    if (input.password === undefined) {
      setErrorPassword({
        isError: true,
        errors: "Password is missing"
      })
    }
    if (input.confirmPassword === undefined) {
      setErrorConfirmPassword({
        isError: true,
        errors: "Confirm Password is missing"
      })
    }
  }

  const RegisterNewUser = (e) => {
    // alert(this.state.designation)

    e.preventDefault();
    Validate()
    if (input.password === input.confirmPassword) {
      fetch(api + 'User/Register', {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          "firstName": input.firstName,
          "lastName": input.lastName,
          "dateOfBirth": input.dateOfBirth,
          "designationId": input.designationId,
          "departmentId": input.departmentId,
          "phoneNumber": input.phoneNumber,
          "emailId": input.emailId,
          "location": input.location,
          "password": input.password,

        })
      })
        .then(res => {
          if (res.status === 201) {
            history("/")
            Swal.fire({
              text: "User Registerd",
              icon: "Success"
            })
            
          }else if (res.status === 500) {
            Swal.fire({
              text: "User Already Registerd",
              icon: "error"
            })
          } else {
            Swal.fire({
              text: "User Not Registerd",
              icon: "error",
            })
          }
        })

    }else{
      Swal.fire({
        text: "Enter Same Confirm Password"
      })
    }


  }

  const handleChange=(e)=>{

 }



  return (
    <div className='wrapper'>

      <div className='logo'>
        <img src={logo} title="User Logo" />
      </div>
      <br />
      <Container>
      <Form  >
      
<Row>
      <Col> <FloatingLabel
          controlId="floatingInput"
          label="First Name"
          className="mb-3">
          <Form.Control
            type="text"
            value={input.firstName}
            placeholder='First Name'
            pattern="[a-zA-Z]{2,}"
            title="Name should be greater than 2 and should contain only alphabet"
            onChange={(e) => { setInput({ ...input, firstName: e.target.value }) }}
          />
          <span className='span'>{errorf.isError ? errorf.errors : false}</span>
        </FloatingLabel>
        </Col>
        <Col><FloatingLabel
          controlId="floatingInput"
          label="Last Name"
          className="mb-3">
          <Form.Control
            type="text"
            value={input.lastName}
            placeholder='Last Name'
            pattern="[a-zA-Z]{2,}"
            onChange={(e) => { setInput({ ...input, lastName: e.target.value }) }}
          />
          <span className='span'>{errorl.isError ? errorl.errors : false}</span>
        </FloatingLabel>
        </Col>
</Row>
   <FloatingLabel
          controlId="floatingInput"
          label="Date of birth"
          className="mb-3">
          <Form.Control
            type="date"
            value={input.dateOfBirth}
            placeholder='Date of birth'
            
            onChange={(e) => { setInput({ ...input, dateOfBirth: e.target.value }) }}
          />
          
          <span className='span'>{errordob.isError ? errordob.errors : false}</span>
        </FloatingLabel>
        <FloatingLabel
          controlId="floatingInput"
          label="Phone Number"
          className="mb-3">
          <Form.Control
            type="Phone"
            value={input.phoneNumber}
            placeholder='Phone Number'
            title="Enter valid Contat Number"
            onChange={(e) => { setInput({ ...input, phoneNumber: e.target.value }) }}
          />
          
          <span className='span'>{errorPhone.isError ? errorPhone.errors : false}</span>
        </FloatingLabel>

        <FloatingLabel
          controlId="floatingSelectGrid"
          label="Enter Designation"
        >
          <Form.Select aria-label="Enter Designation"
            value={input.designationId} onChange={(e) => { setInput({ ...input, designationId: e.target.value })  }}>
            <option>Enter Designation</option>
            <option value="1">Manager</option>
            <option value="2">Software Engineer</option>
            <option value="3">Marketing Representative</option>
            <option value="4">QA Engineer</option>
            <option value="5">HR Representive</option>
            <option value="6">Sales Representive</option>
            <option value="7">Finance Advisor</option>
          </Form.Select>

          <span className='span'>{errorDesignation.isError ? errorDesignation.errors : false}</span>
        </FloatingLabel>
        <br/>
       
        <FloatingLabel
          controlId="floatingSelectGrid"
          label="Enter Department"
        >
          <Form.Select aria-label="Floating label select example"
            value={input.departmentId} onChange={(e) => { setInput({ ...input, departmentId: e.target.value }) }}>
            <option>Enter Department</option>
            <option value="1">Software Development</option>
            <option value="2">Marketing</option>
            <option value="3">Human Resources</option>
            <option value="4">Finance</option>
            <option value="5">Quality Assurance</option>
            <option value="6">Sales</option>
          </Form.Select>
          <span className='span'>{errorDepartment.isError ? errorDepartment.errors : false}</span>
        </FloatingLabel>
        <br />
        <FloatingLabel
          controlId="floatingInput"
          label="Email"
          className="mb-3">
          <Form.Control
            type="email"
            value={input.emailId}
            placeholder='Email'
            onChange={(e) => { setInput({ ...input, emailId: e.target.value }) }}
          />
          <span className='span'>{errorEmail.isError ? errorEmail.errors : false}</span>
        </FloatingLabel>

        <FloatingLabel
          controlId="floatingInput"
          label="Location"
          className="mb-3">
          <Form.Control
            type="text"
            value={input.location}
            placeholder='Location'
            onChange={(e) => { setInput({ ...input, location: e.target.value }) }}
          />
          <span className='span'>{errorLocation.isError ? errorLocation.errors : false}</span> 
        </FloatingLabel>
        
        <FloatingLabel
          controlId="floatingInput"
          label="Password"
          className="mb-3">
          <Form.Control
            type="password"
            value={input.password}
            placeholder='Password'
            pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
            title="password shoud contain 1 upper case and 1 lowercase with numbers and special character"
            onChange={(e) => { setInput({ ...input, password: e.target.value }) }}
          />
          <span className='span'>{errorPassword.isError ? errorPassword.errors : false}</span>
        </FloatingLabel>

        <FloatingLabel
          controlId="floatingInput"
          label="Confirm Password"
          className="mb-3">
          <Form.Control
            type="password"
            value={input.confirmPassword}
            placeholder='Confirm Password'
            pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"
            title="password shoud contain 1 upper case and 1 lowercase with numbers and special character"
            
            onChange={(e) => { setInput({ ...input, confirmPassword: e.target.value }) }}
          />
          <span className='span'>{errorConfirmPassword.isError ? errorConfirmPassword.errors : false}</span>
        </FloatingLabel>
        

        <button className="btn mt-3" type="submit" onClick={RegisterNewUser}>Register</button>
        
      </Form>
      </Container>
    </div>
  )
}
