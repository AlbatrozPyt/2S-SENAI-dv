import React, { useState } from "react";

const Input = (props) => {
  const [meuValor, setMeuValor] = useState();

  return (
    <div>
      <input
        type={props.type}
        id={props.id}
        name={props.nome}
        placeholder={props.dicaCampo}
        value={props.valor}
        onChange={(e) => {
          //setMeuValor(e.target.value) //! Valor atual do componente
          props.fnAltera(e.target.value)
        }}
      />

      <span>{meuValor}</span>
    </div>
  );
};

export default Input;
