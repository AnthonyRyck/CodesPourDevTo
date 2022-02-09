import React, { Component, MouseEventHandler } from 'react';
import './Fancomponent.css';

interface FanComponentProps {
  id: string;
  nom: string;
  nombreClick: string;
  onClickCounter: MouseEventHandler;
  onClickToFanPage: MouseEventHandler;
}

class FanComponent extends Component<FanComponentProps> {
  render() {
    const { id, nom, nombreClick, onClickCounter, onClickToFanPage } = this.props;
    return (
      <>
        <div id="openFanPage" className="fan grow" onClick={onClickToFanPage}>
			<div>
				<div>ID : {id}</div>
				<div id="iam">Nom : {nom}</div>
				<div>Nombre de click : {nombreClick}</div>
			</div>

			<button onClick={onClickCounter}>
				Click sur Moi
			</button>
		</div>
      </>
    );
  }
}

export default FanComponent;
