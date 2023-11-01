import React, { useState } from "react";
import Input from "../../Components/Input/Input.jsx";
import Button from "../../Components/Button/Button.jsx";
import Header from "../../Components/Header/Header.jsx";

const TestePage = () => {
  const [total, setTotal] = useState();
  const [n1, setN1] = useState();
  const [n2, setN2] = useState();

  function handleCalcular(e) {  //! Chamar no submit
    e.preventDefault()
    setTotal(parseFloat(n1) + parseFloat(n2))
  }

  return (
    <>
      <h1>Calculator</h1>
      <form onSubmit={handleCalcular}>
        <Header />

        <Input
          type="number"
          id="numero1"
          nome="numero1"
          dicaCampo="1º número"
          valor={n1}
          fnAltera={setN1}
        />

        <Input
          type="number"
          id="numero2"
          nome="numero2"
          dicaCampo="2º número"
          valor={n2}
          fnAltera={setN2}
        />

        <Button 
          type="submit"
          textoButao="Somar"
        />

        <p>Resultado: <strong>{total}</strong></p>
      </form>
    </>
  );
};

export default TestePage;
