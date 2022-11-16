import React from 'react';

import {

    MDBCard,

    MDBCardBody,

    MDBCardTitle,

    MDBCardText,

    MDBCardImage,

    MDBBtn,

    MDBRipple

} from 'mdb-react-ui-kit';



export default function Carousel() {

    return (
        <div className='carousel'>
            <MDBCard>

                <MDBRipple rippleColor='light' rippleTag='div' className='bg-image hover-overlay'>

                    <MDBCardImage src='https://t3.ftcdn.net/jpg/02/36/89/38/360_F_236893871_Kc23FRqadfQYbviMxvQsaXFc5pTQQOpa.jpg' fluid alt='...' />

                    <a>

                        <div className='mask' style={{ backgroundColor: 'rgba(251, 251, 251, 0.15)', border: '1px solid rgba(0, 0, 0, 0.05)' }}></div>

                    </a>

                </MDBRipple>

                <MDBCardBody>

                    <MDBCardTitle>Project Name</MDBCardTitle>

                    <MDBCardText>
                        Members: 12
                    </MDBCardText>

                    <MDBBtn href='#'>View Project Details</MDBBtn>

                </MDBCardBody>

            </MDBCard>

        </div>


    );

}