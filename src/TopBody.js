import React from 'react';
import Lidith from './Lidith.jpg'

class TopBody extends React.Component   {
    render(){
        return(
            <div>
                <div className ="videoBack">
                <video width="100%" height ="500px" loop autoPlay> <source type ="video/mp4"src ="https://lolstatic-a.akamaihd.net/frontpage/apps/prod/harbinger-l10-website/en-us/production/en-us/static/hero-0632cbf2872c5cc0dffa93d2ae8a29e8.webm" />
                    Video</video>
                </div>


                    <div className ="flexContainer">
                        <a href ="#" className ="inflexContainer">
                            <img src={Lidith} width="125" padding-left ="-5px" />
                                <div className ="dansInflexContainer">
                                    <p>lol</p>
                                    <p>lol</p>
                                    <p>lol</p>
                                </div>
                        </a>
                        <a href ="#" className ="inflexContainer">
                        <img src={Lidith} width="125" />
                                <div className ="dansInflexContainer">
                                    <p>lol</p>
                                    <p>lol</p>
                                    <p>lol</p>
                                </div>
                        </a>
                        <a href ="#" className ="inflexContainer">
                        <img src={Lidith} width="125" />
                                <div className ="dansInflexContainer">
                                    <p>lol</p>
                                    <p>lol</p>
                                    <p>lol</p>
                                </div>
                        </a>
                    </div>




            </div>
        )
    }
}

export default TopBody;