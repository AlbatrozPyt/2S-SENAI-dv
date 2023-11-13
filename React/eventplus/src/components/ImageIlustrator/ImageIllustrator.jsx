import React from 'react';
import "./ImageIllustrator.css"

import imageDefault from "../../assets/images/default-image.jpeg"

const ImageIllustrator = ({ alterText, imageRender=imageDefault, additionalClass="" }) => {
    return (
        <figure className='ilustrator-box'>
            <img 
                src={imageRender} 
                alt={alterText}
                className="illustrator-box__image" 
            />
        </figure>
    );
};

export default ImageIllustrator;