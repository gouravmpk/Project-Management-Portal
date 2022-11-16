import React from 'react'
import { Navbar, NavLink, NavItem, Nav, Container } from 'react-bootstrap';
import { useNavigate, Navigate } from 'react-router-dom'
import * as ReactBootStrap from 'react-bootstrap';
import { useState } from 'react';
import api from './Constants';
import { FiLogOut } from 'react-icons/fi'
import ProfileTemp from './ProfileTemp';


export default function NavigateTo() {


    const history = useNavigate()
    const [userId, setUserId] = useState()
    fetch(api + "User/loggedInUserId", {
        method: "get"
    }).then((response) => {
        if (response.status === 200) {
            response.json().then((data) => {
                console.log(data)
                setUserId(data)
            })
        }
    })

    const logoutHandler = () => {
        fetch("https://localhost:7223/api/User/Logout", {
            method: "post",
            headers: {
                Authorization: `Bearer ${localStorage.getItem("authToken")}`,
            }
        }).then((response) => {
            if (response.status === 202) {
                localStorage.removeItem("authToken")
                localStorage.removeItem("isAdmin")
                history("/")
            }
        })
    }



    return (
        <div>
            <Navbar bg="dark" variant="dark">
                {/* <Container>
                    <h4 style={{ color: 'white ' }}>Project Club</h4>
                    <Nav variant="pills" defaultActiveKey="/home">
                        <Nav.Link href={('/Home')}>
                            Home
                        </Nav.Link>
                        <Nav.Link href={('/Project')}>Project</Nav.Link>
                        <Nav.Link href={('/Task')}>Task</Nav.Link>
                    </Nav>
                    <ProfileTemp userId={userId} />
                    <ReactBootStrap.Button variant="outline-light" onClick={logoutHandler}><FiLogOut id='logout' />{' '}</ReactBootStrap.Button>{' '}

                </Container> */}
                <div style= {{display: 'flex', margin: "5px 20px", justifyContent: "space-between", width: "100%"}}>
                    <div style={{display: "flex"}}>
                    <h4 style={{ color: 'white ' }}>Project Club</h4>
                    <div style={{marginLeft: "30px"}}><Nav variant="pills" defaultActiveKey="/home">
                        <Nav.Link href={('/Home')}>
                            Home
                        </Nav.Link>
                        <Nav.Link href={('/Project')}>Project</Nav.Link>
                        <Nav.Link href={('/Task')}>Task</Nav.Link>
                    </Nav></div>
                    </div>
                    <div>
                    <ProfileTemp userId={userId} />
                    <ReactBootStrap.Button variant="outline-light" style={{marginRight: "20px"}} onClick={logoutHandler}><FiLogOut id='logout' />{' '}</ReactBootStrap.Button>{' '}
                    </div>
                </div>
            </Navbar>


        </div>
    )
}
