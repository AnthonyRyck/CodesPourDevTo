import React, { Component, MouseEventHandler } from 'react';
import './FanComponent.css';

interface FanComponentProps {
  id: number;
  nom: string;
  nombreClick: number;
  // onClickCounter: MouseEventHandler;
  // onClickToFanPage: MouseEventHandler;
}

export default class FanComponent extends Component<FanComponentProps> {
  
  render() {
    const { id, nom, nombreClick,  } = this.props;
    
    return (
      <div id="openFanPage" className="fan grow">

			  <div>
			  	<div>ID : {id}</div>
			  	<div id="iam">Nom : {nom}</div>
			  	<div>Nombre de click : {nombreClick}</div>
			  </div>
      
			  <button >
			  	Click sur Moi
			  </button>
		</div>
    );
  }
}