import React from "react";
import "./TipoEventos.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";

const TipoEventos = () => {
  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <div className="cadastro-evento__box">
          <Title titleText={"Tipos de evento Page"} />
          <ImageIllustrator/>

          <form action="">
            <p>Componente de Formulario</p>
          </form>
        </div>
      </section>
    </MainContent>
  );
};

export default TipoEventos;
