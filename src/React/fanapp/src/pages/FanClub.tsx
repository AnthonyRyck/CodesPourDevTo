import React, { Component, useState, useEffect } from 'react';
import { useQuery } from "react-query";

import FanComponent from '../components/FanComponent';
import Navbar from '../components/Navbar/Navbar';
import '../css/fanapp.css';
import Fan from '../Models/Fan';
import AccessDataService from '../Services/AccessDataService';

const FanClub: React.FC = () => {
		
	const [allFans, setAllFans] = useState<Fan[]>([]);
	
	useEffect(() => {
		console.log("Je suis dans useEffect, et allFans contient :")
		console.log(allFans.length + " éléments");
	  }, [allFans]);

	const { refetch: getAllData } = useQuery<Fan[]>(
		"query-fans",
		async () => {
			console.log("Coucou, je suis ici : query-fans !");
			// Oui, je sais, mais rien ne vaut un "coucou je suis ici"
		  let tempResult = await AccessDataService.GetAllFans();
		
		  // J'ai bien l'information !
		  console.log(tempResult[0]);
		  return tempResult;
		},
		{
		  enabled: true,
		  onSuccess: (res) => {
			setAllFans(res);
		  },
		  onError: (err: any) => {
			  console.error("ERREUR 12 - " + err);
			setAllFans([]);
		  },
		}
	  );

	  function getFans() {
		try {
			getAllData();
		} catch (err) {
			console.error("ERREUR 13 - " + err);
		  setAllFans([]);
		}
	  }


	return (		
		<div className="page">
        	<div className="sidebar">
        	    <Navbar />
        	</div>
        	<div>Coucou de la FanClub page</div>
			{/* <button className="btn btn-sm btn-primary" onClick={getFans}>
              Get All
            </button> */}

			<div className="fanClub">
				{allFans.map((fan) => 
				(
					<FanComponent nom={fan.Nom}
								id={fan.Id}
								nombreClick={fan.NombreDeClickRecu} />
				))
				}
			</div>
		</div>
	);

}

export default FanClub;