import React, { Component, MouseEventHandler } from 'react';
import './FanComponent.css';

interface FanComponentProps  {
  id: number;
  nom: string;
  nombreClick: number;
}

export default class FanComponent extends Component<FanComponentProps> {
  
  render() {
    let { id, nom, nombreClick } = this.props;
    
    return (
      <div className="fan grow">
			  <div>
			  	<div>ID : {id}</div>
			  	<div>Nom : {nom}</div>
			  	<div>Nombre de click : {nombreClick}</div>
			  </div>
      
			  <button>
			  	Click sur Moi
			  </button>
		</div>
    );
  }
}