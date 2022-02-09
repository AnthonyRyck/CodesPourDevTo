import React from 'react';
import logo from './logo.svg';
import './App.css';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import FanClubPage from './Views/FanClub';

 

function App() {
  return (
	  <Router>
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
		<Link to="/test">Pour tester</Link>
		{/* <a
          className="App-link"
          href="https://reactjs.org"
          rel="noopener noreferrer"
        >
          Pour tester
        </a> */}
      </header>
    </div>
		<Route path="/test" element={FanClubPage} />

	</Router>
  );
}

export default App;
