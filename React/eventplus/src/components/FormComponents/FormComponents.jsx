import React from 'react';
import "./FormComponents.css"

export const Input = ( {
    type,
    id,
    value,
    required,
    additionalClass,
    name,
    placeholder,
    manipulationFunction
} ) => {
    return (
        <input 
            type={type}
            id={id}
            value={value}
            name={name}
            required={required}
            className={`input-component ${additionalClass}`}
            placeholder={placeholder}
            onChange={manipulationFunction}
            autoComplete="off"
        />
    )
}