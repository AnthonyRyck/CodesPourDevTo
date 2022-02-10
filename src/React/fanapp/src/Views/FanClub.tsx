import React, { Component, MouseEventHandler } from 'react';
import FanComponent from '../components/FanComponent';
import '../css/fanapp.css';
import AccessData from '../data/FakeAccessData';

type FanClubState = {
	viewModel: AccessData
}

export default class FanClub extends React.Component<{}, FanClubState> {
	
	render() {
	return (
		<div className="fanClub">
			
			{ 
			(await this.state.viewModel.GetAllFans()).map((fan, index) =>
			{
				<FanComponent nom="{fan.nom}"
							  id="{fan.id}"
							  nombreClick="{fan.nombreClick}"
							   />
							//    onClickCounter={}
							//   onClickToFanPage={}
			}) 
			};
		</div>
	);
	}
}