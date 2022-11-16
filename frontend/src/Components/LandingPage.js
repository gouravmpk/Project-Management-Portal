import {  MDBCard,  MDBCardBody,  MDBCardTitle,  MDBRow, MDBCol, MDBCardText, MDBRipple} from 'mdb-react-ui-kit';
import React from 'react'
import { Card  } from 'react-bootstrap';
import Cards from './Cards';
import Carousel from 'react-bootstrap/Carousel';

import img from '../img/carousel2.jpg'
import img1 from '../img/slide.png'

import img2 from '../img/carousel2.jpg'
import Home from './Home';

export default function LandingPage() {
  return (
    <div className = 'carousel'>
      <br/>
      <Carousel variant="dark" >
      <Carousel.Item interval={5000}>
        <img
          className="img d-block w-100"
          src={img1}
          alt="First slide"
        />
        <Carousel.Caption>
          <h3 >Keep track of your projects</h3>
          <p>Navigate to project section for view of projects</p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item interval={5000}>
        <img 
          className="img d-block w-100"
          src={img}
          alt="Second slide"
        />
        <Carousel.Caption>
          <h3>Keep track of your tasks</h3>
          <p>Navigate to project section for view of tasks</p>
        </Carousel.Caption>
      </Carousel.Item >
    </Carousel>
    <br/>
        <Cards/>

  </div>
  )
}