import { Navbar } from "react-bootstrap";
import React, { Component } from 'react'
import { Container } from "react-bootstrap";

export class Topbar extends Component {
    render() {
        return (
            <div>
                <Navbar>
                    <Container>
                        <Navbar.Brand href="#home">Project Management Portal</Navbar.Brand>
                        <Navbar.Toggle />
                        <Navbar.Collapse className="justify-content-end">
                            
                        </Navbar.Collapse>
                    </Container>
                </Navbar>
            </div>
        )
    }
}

export default Topbar

