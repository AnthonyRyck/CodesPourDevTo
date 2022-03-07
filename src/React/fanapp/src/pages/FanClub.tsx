import React, { useState, useEffect } from 'react';
import { useQuery } from "react-query";

import FanComponent from '../components/FanComponent';
import Navbar from '../components/Navbar/Navbar';
import '../css/fanapp.css';
import Fan from '../Models/Fan';
import AccessDataService from '../Services/AccessDataService';

const FanClub: React.FC = () => {
		
	let [allFans, setAllFans] = useState<Fan[]>([]);
	
	useEffect(() => {
		console.log("Je suis dans useEffect, et allFans contient :")
		console.log(allFans.length + " éléments");
	  }, [allFans]);

	useQuery<Fan[]>(
		"query-fans",
		async () => {
			console.log("Coucou, je suis ici : query-fans !");
			// Oui, je sais, mais rien ne vaut un "coucou je suis ici"
		  return await AccessDataService.GetAllFans();
		},
		{
		  enabled: true,
		  onSuccess: (res) => {
			  res.map((fan) => (console.log("Le nom est : " + fan.nom)));
			setAllFans(res);
		  },
		  onError: (err: any) => {
			  console.error("ERREUR 12 - " + err);
			setAllFans([]);
		  },
		}
	  );

	return (		
		<div className="page">
        	<div className="sidebar">
        	    <Navbar />
        	</div>

			<div className='row'>
        		<div>Coucou de la FanClub page</div>

				<div className="fanClub">
					{allFans.map((fan) => 
					(
						<div>
							<FanComponent key={fan.id}
								nom={fan.nom}				
								id={fan.id}
								nombreClick={fan.nombreDeClickRecu} />
						</div>
						))
					}
				</div>
			</div>
		</div>
	);

}

export default FanClub;