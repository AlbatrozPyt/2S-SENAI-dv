import React from "react";
import "./TipoEventos.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import { Input } from "../../Components/FormComponents/FormComponents";

const TipoEventos = () => {
  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Tipos de evento Page"} />
            <ImageIllustrator
              alterText={"imagem"}
              imageRender={eventTypeImage}
            />

            <form onSubmit={frmEdit ? handleUpdate : handleSubmit}>
              <p>Componente de Formulario</p>
              <Input 
                type={"number"}
                required={"required"}
              />
            </form>
          </div>
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventos;
