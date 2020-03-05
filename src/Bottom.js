import React from 'react'
import epiloveers from './epilovers.png'
import logo from './logo_d2_unamed.png'

class Bottom extends React.Component {
    render(){
        return (
            <div className="bottomContainer"> 
                <div className ="firstbottomContainer">
                    <div><a href ="#">INFORMATIONS</a></div>
                    <div><a href ="#">LE PROJET</a></div>
                    <div><a href ="#">GALLERIE</a></div>
                </div>

                <div className="mediaBottomContainer"> 
                    <button type="button" className="btn mdb-color lighten-2 reg"></button>
                    <button type="button" className="btn mdb-color lighten-2 reg"></button>
                    <button type="button" className="btn mdb-color lighten-2 reg"></button>
                </div>
                
                <div className="logoContainer">
                    <img src ={epiloveers} alt ="logo team" width ="300px" margin ="auto"></img>
                    <img src ={logo} alt ="logo jeu" width ="350px" margin ="auto"></img>
                </div>

                <div className="ecritureBottom">© 2020 Epilovers. Tous droits réservés. Hack'n Love et Epilovers ne peuvent en aucun cas être utilisés à des fins commerciaux </div> 

            </div>
        )
    }
}

export default Bottom;