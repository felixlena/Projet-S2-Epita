import React from'react'
import epilovers from './epilovers.png'
import name from './nom_logo.png'

class Top extends React.Component   {
    constructor()   {
        super()
        this.state=({
            changed: true,
            responsif: "menuResponsif fermerMenuResponsif",
        })
    }
    changeVariable()    {
        if (this.state.changed ===false) {
            this.setState({
                responsif : "menuResponsif fermerMenuResponsif"
            })
        }
        if (this.state.changed===true) {
            this.setState({
                responsif: "menuResponsif ouvertMenuResponsif"
            })
        }
        
        this.setState ({
            changed: !this.state.changed,
        });
    }


    render(){
        return(
            <div>
                <div className ="toolsBar">
                    <div className ="topContainer">
                        <img src ={epilovers} width ="10%" float="right"></img>
                        <div className="mainMenu">
                            <a href ="#">ACTUALITES</a>
                            <a href ="#">GUIDE</a>
                            <img src={name} width="30%"className="mainTitle"></img>
                            <a href ="#">TELECHARGEMENT</a>
                            <a href ="#">INFORMATIONS</a>
                            <a href ="#">A PROPOS</a>
                        </div>
                        <button className =" navbar-toggler toggler-example black voir " onClick ={() =>this.changeVariable()}><span><i className="fas fa-bars fa-1x"></i></span></button>
                    </div>
                </div>
                <div className={this.state.responsif}>
                        <a href ="#">ACTUALITES</a>
                        <a href ="#">GUIDE</a>
                        <a href ="#">TELECHARGEMENT</a>
                        <a href ="#">INFORMATIONS</a>
                        <a href ="#">A PROPOS</a>
                </div>    
            </div>        
                    
            
        )
    }
}
export default Top;