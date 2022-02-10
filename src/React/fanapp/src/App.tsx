import React from 'react';
import './App.css';

import { Routes, Route } from "react-router-dom";
import Home from './components/Home/Home';
import FanClub from './Views/FanClub';
import Navbar from './components/Navbar/Navbar';

export default class App extends React.Component<{}, {}> {
  render()
  {
    return(
      <div>
        <Navbar />
          <Routes>
            <Route path='/' element={<Home />} />
            <Route path='/fanclub' element={<FanClub />} />
          </Routes>
      </div>
    );
  }
}