
import React, { Component } from 'react'

export default class InputField extends Component {
    constructor(props) {
      super(props)
    
    }
  render() {
    return (
    <div className="form-field d-flex align-items-center">
        <input
        value={this.props.value}
        name={this.props.name}
        placeholder={this.props.placeholder}
        type={this.props.type}
        onChange={this.props.onChange}
        />

    </div>

    )
  }
}


// const InputField =() =>{
//     <div className="form-field d-flex align-items-center">
//         <input>
//         value={this.props.value}
//         name={this.props.name}
//         placeholder={this.props.placeholder}
//         type={this.props.type}
//         onChange={this.props.onChange}
//         </input>

//     </div>
// }
