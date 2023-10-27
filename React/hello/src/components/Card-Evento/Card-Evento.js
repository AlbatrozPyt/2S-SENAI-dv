import React from "react";
import "./Card-Evento.css"

const Card = ( {titulo, texto, disabled, textoLink} ) => {
    return (
        <div className="card">
            <h1 className="card__titulo">{titulo}</h1>

            <p className="card__texto">{texto}</p>

            <a className= 
                {
                disabled
                ? "card__connect card__connect--disabled" 
                : "card__connect"
                }  
            >{textoLink}</a>
        </div>
    )
}

export default Card;