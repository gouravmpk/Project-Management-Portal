import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from "axios";
import ButtonGroup from 'react-bootstrap/ButtonGroup';
import DropdownButton from 'react-bootstrap/DropdownButton';
import { useResolvedPath } from 'react-router-dom';
import Swal from 'sweetalert2';
import Dropdown from './DropDownProject';
import DropDownProject from './DropDownProject';


function AssignProjectMember(props) {
    const [items, setItems] = useState([]);
    const [selected, setSelected] = useState();
    
    //   const [inputValue, setValue] = useState('');
    //   const [selectedValue, setSelectedValue] = useState(null);


    //   // handle input change event
    //   const handleInputChange = value => {
    //     setValue(value);
    //   };
    //   // handle selection
    //   const handleChange = value => {
    //     setSelectedValue(value);
    //   }

    useEffect(() => {
        axios.get("https://localhost:7223/api/User").then(result => {
            console.log(result.data)
            setItems(result.data)
            console.log(items)

        });

    }, [])

    const assignMember = (value) => {

        fetch(`https://localhost:7223/api/ProjectAssignment?userId=${value}&projectId=${props.projectId}`, {
            method: "POST",
        }).then((res) => {
            if (res.status === 201) {
                setSelected(value);
                console.log(res);
                Swal.fire({
                    text: "Member assigned to the Project.",
                    type: "success"
                })
                    .then(function () {
                        window.location.reload();
                    });
                setSelected(value);
            }

        });
    }


    return (


        <div className='container'>

            <div className='row'>

                <div className='=col-md-4'></div>

                <DropDownProject AssignProjectMember={assignMember} datas={items} />
            </div>

        </div>
    );
}
export default AssignProjectMember
