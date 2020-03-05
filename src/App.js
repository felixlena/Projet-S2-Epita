import React from 'react';
import './App.css';
import TopBody from './TopBody.js'
import Top from'./Top';
import Body from './Body';
import SkillGallerie from './SkillGallerie';
import Bottom from './Bottom';
import druide from './druide.jpeg'
import Sorciere from './diablo-4-sorciere.jpg';
import Lidith from './Lidith.jpg';
import epilovers from './epilovers.png';
import logo from './logo_d2.png';
import nom from './nom_logo.png';
import SwitchPageTest from './SwitchPageTest';
import {BrowserRouter as Routeur, Switch,Route} from 'react-router-dom';


function App() {
  const liste= [{Sorciere},{Lidith},{druide},{epilovers},{logo},{nom}]
  return (
    <div>
      <Routeur>
      <Top />
      <Route path ="/pagetest" component={SwitchPageTest} />
      <Route path ="/gallerie" component={SkillGallerie}></Route>
      <TopBody liste/>
      <Body />
      <Bottom />
      </Routeur>
    </div>

  );
}

export default App;
