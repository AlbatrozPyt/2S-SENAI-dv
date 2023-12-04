import React from "react";
import "./FormComponents.css";

export const Input = ({
  type,
  id,
  value,
  required,
  additionalClass,
  name,
  placeholder,
  manipulationFunction,
}) => {
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
  );
};

export const Button = ({
  id,
  name,
  type,
  additionalClass = "",
  manipulationFunction,
  textButton,
}) => {
  return (
    <button
      type={type}
      name={name}
      id={id}
      className={`button-component ${additionalClass}`}
      onClick={manipulationFunction}
    >
      {textButton}
    </button>
  );
};

export const Select = ({
  dados,
  id,
  name,
  required,
  additionalClass = "",
  manipulationFunction,
  defaultValue,
}) => {
  return (
    <select
      className={`input-component ${additionalClass}`}
      name={name}
      id={id}
      required={required}
      onChange={manipulationFunction}
      value={defaultValue}
    >
      <option value="">Selecionar</option>
      {dados.map((e) => {
        return <option value={e.value}> {` ${e.text} `}</option>;
      })}
    </select>
  );
};
