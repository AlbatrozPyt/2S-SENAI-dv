import React, { useState } from "react";
import "./Contador.css"


const Contador = () => {
    const [contador, setContador] = useState(0);

    function handleIncrementar() {
        setContador(contador +1);
    }

    function handleDecrementar() {
        contador > 0 ? setContador(contador -1) : setContador(0)
    }

    return (
        <>
            <p>{contador}</p>
            <button onClick = {() => {
                handleIncrementar();
            }}>Incrementar</button>

            <button onClick = {() => {
                handleDecrementar();
            }}>Decrementar</button>
        </>
    );
}

export default Contador;