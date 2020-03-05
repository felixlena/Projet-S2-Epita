import React from 'react';
import druide from './druide.jpeg'
import Sorciere from './diablo-4-sorciere.jpg';
import Lidith from './Lidith.jpg';
import epilovers from './epilovers.png';
import logo from './logo_d2.png';
import nom from './nom_logo.png';

class Body extends React.Component{
    constructor(props){
        super(props)
        this.state ={
            liste: this.props.liste,
            pos:1,
            image: Sorciere,
        }

    }

    horloge()    {
        this.horloge = setInterval(
            console.log("la?"),
            ()=> this.varImage(),3000
        );
    }
    varImage()  {
        this.setState({
            pos:this.state.pos+1,
            image:this.state.liste[this.state.pos+1],
        })
        
    }

    changeSorciere ()  {
        this.setState({
            pos:1,
            image: Sorciere,
        })
    }

    changeLidith()   {
        this.setState({
            pos:2,
            image:Lidith,
        })
    }

    changeDruide()  {
        this.setState({
            pos:3,
            image:druide,
        })
    }

    changeimage4()  {
        this.setState({
            pos:4,
            image: epilovers,
        })
    }

    changeImage5()  {
        this.setState({
            pos:5,
            image:logo,
        })
    }
    changeImage6()  {
        this.setState({
            pos:6,
            image:nom,
        })
    }


    render(){
        return (
            <div className ="bodyContainer">
                <h1 className="title"> Genèse du jeu</h1>
                <div className="margeTexte"> Hack'n love nacquit de l'idée un peu folle de 4 jeunes passionnés,
                qui voyaient dans le genre hack'n slash une ode a l'amour et la bienveillance.
                Ces quatre petits mousquetaires improvisés pour l'occasion se promirent alors
                de développer le meilleur jeu auquel ils n’auraient jamais jouer.</div>
                <button id="download" className=" btn btn-dark">TELECHARGER LE JEU</button>
                <div className ="containerGallerie">
                    <div className="buttonContainer">
                        <button onClick={() => this.changeSorciere()}  type="button"  className="btn mdb-color lighten-2 reg"></button>
                        <button onClick ={() => this.changeLidith()}  type="button" className="btn mdb-color lighten-2 reg"></button>
                        <button onClick ={()=> this.changeDruide()}  type="button" className="btn mdb-color lighten-2 reg"></button>
                        <button onClick = {()=>this.changeimage4()}type="button" id ="reg"className="btn mdb-color lighten-2 reg"></button>
                        <button onClick ={()=>this.changeImage5()}type="button" className="btn mdb-color lighten-2 reg"></button>
                        <button onClick={()=>this.changeImage6()}type="button" className="btn mdb-color lighten-2 reg"></button>

                    </div>
                    <img src ={this.state.image} className ="imgBody" ></img>

                </div>
            
            </div>
        )
    }
}

export default Body;