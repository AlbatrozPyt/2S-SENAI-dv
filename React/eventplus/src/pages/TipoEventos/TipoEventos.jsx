import React, { useState } from "react";
import "./TipoEventos.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import TableTps from "./TableTp/TableTp";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import api from "../../Services/Services"
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import TableTp from "./TableTp/TableTp";

const TipoEventos = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  
  const [tipoEventos, setTipoEventos] = useState([
    {idTipoEvento: "123", titulo: "Evento ABC"},
    {idTipoEvento: "555", titulo: "Evento xpto"},
    {idTipoEvento: "444", titulo: "Evento de JavaScript"}
  ]); // arrsy mocado

  async function handleSubmit(e) {
    // parar submit do form
    e.preventDefault();

    // validar pelo menos 3 caracteres
    if(titulo.trim().length < 3) {
      alert("O titulo deve ter pelo menos 3 caracteres");
      return;
    }

    // chamar api
    try {
      const retorno = await api.post("/TiposEvento", {titulo: titulo})
      console.log("Cadastrado com sucesso!!!");
      console.log(retorno.data);
      setTitulo(""); // limpa a variavel
    } catch (error) {
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

  //* EDITAR CADASTRO

  function handleUpdate() {
    alert("Atualizar");
  }

  function showUpdateForm() {
    alert("Mostrando a tela de update")
  }

  function handleDelete() {
    alert("Bora lá apagar na api")
  }

  function editActionAbort() {
    alert("Cancelar a tela de edição de dados")
  }

  return (
    <MainContent>
      {/* Cadastro de tipos de eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Tipos de evento Page"} />
            <ImageIllustrator
              alterText={"imagem"}
              imageRender={eventTypeImage}
            />

            <form className="ftipo-evento" onSubmit={frmEdit ? handleUpdate : handleSubmit}>
              {!frmEdit ? (
                // Cadastrar
                <>
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Titulo"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={
                      (e) => {
                        setTitulo(e.target.value)
                      }
                    }
                  />
                  {/* <span>{titulo}</span> */}

                  <Button type={"submit"} name={"cadastar"} id={"cadastar"} textButton={"Cadastar"}/>
                </>
              ) : (
                <p>Tela de edição</p>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de tipos de eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Eventos"} color="white"/>

          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventos;
