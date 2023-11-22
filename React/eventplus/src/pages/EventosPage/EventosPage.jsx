import React, { useEffect, useState } from "react";
import "./EventosPage.css";
import eventImage from "../../assets/images/evento.svg";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Titulo/Title";
import Container from "../../Components/Container/Container";
import TableTp from "./TableTp/TableTp";
import { Button, Input } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";
import Notification from "../../Components/Notification/Notification";

const EventosPage = () => {

  const [frmEdit, setFrmEdit] = useState(false);

  const [evento, setEvento] = useState([
    // {idEvento:"1", nomeEvento:"Evento Senai 1", tipoEvento:"nenhum", data:"28/03/2025"},
    // {idEvento:"2", nomeEvento:"Evento Senai 2", tipoEvento:"nenhum", data:"28/03/2025"},
    // {idEvento:"3", nomeEvento:"Evento Senai 3", tipoEvento:"nenhum", data:"28/03/2025"},
    // {idEvento:"4", nomeEvento:"Evento Senai 4", tipoEvento:"nenhum", data:"28/03/2025"}
  ]);

  const [notifyUser, setNotifyUser] = useState({});

  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [tipoEvento, setTipoEvento] = useState({});
  const [dataEvento, setDataEvento] = useState("");


  //! Lista de eventos
  useEffect(() => {
    async function getListaEventos() {
      try {
        const retornoGet = await api.get("/Evento/");

        setEvento(retornoGet.data);
      } catch (error) {
        alert("Deu ruim na Lista de eventos");
      }
    }
    getListaEventos();
  }, []);

  //* DELETAR
  async function handleDelete(idEvento) {
    try {
      const retornoDelete = await api.delete(`/Evento/${idEvento}`);
      const retornoGet = await api.get("/Evento");
      setEvento(retornoGet.data);

      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Deletado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro!!!",
        textNote: `Erro na hora de deletar.`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de erro.",
        showMessage: true,
      });
    }
  }

  function handleUpdate() {
    alert("Hora de atualizar");
  }

 

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Eventos"} additionalClass="margem-acima" />

            <ImageIllustrator imageRender={eventImage} alterText="Imagem" />

            <form className="ftipo-evento">
              {!frmEdit ? (
                <>
                  <Input
                    type={"text"}
                    placeholder={"Nome"}
                    id={"nome"}
                    name={"nome"}
                    required={"required"}
                    value={nome}
                    manipulationFunction={""}
                  />

                  <Input
                    type={"text"}
                    placeholder={"Descricao"}
                    id={"descricao"}
                    name={"descricao"}
                    required={"required"}
                    value={descricao}
                    manipulationFunction={""}
                  />

                  <select name="" id=""></select>

                  <Input
                    type={"date"}
                    id={"data"}
                    name={"data"}
                    required={"required"}
                    value={dataEvento}
                  />

                  <Button
                    type={"submit"}
                    id={"submitEvento"}
                    name={"submitEvento"}
                    textButton={"Cadastrar"}
                    additionalClass={"btn-cadastrar"}
                  />
                </>
              ) : (
                <>
                  <Input
                    type={"text"}
                    placeholder={"Nome"}
                    id={"nome"}
                    name={"nome"}
                    required={"required"}
                    value={nome}
                    manipulationFunction={""}
                  />

                  <Input
                    type={"text"}
                    placeholder={"Descricao"}
                    id={"descricao"}
                    name={"descricao"}
                    required={"required"}
                    value={descricao}
                    manipulationFunction={""}
                  />

                  <select name="" id=""></select>

                  <Input
                    type={"date"}
                    id={"data"}
                    name={"data"}
                    required={"required"}
                    value={dataEvento}
                  />

                  <Button
                    type={"submit"}
                    id={"updateEvento"}
                    name={"updateEvento"}
                    textButton={"Atualizar"}
                    additionalClass={"btn-cadastrar"}
                  />

                  <Button
                    type={"submit"}
                    id={"cancelarEvento"}
                    name={"cancelarEvento"}
                    textButton={"Cancelar"}
                    additionalClass={"btn-cadastrar"}
                  />
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de eventos"} color={"white"} />

          <TableTp
            dados={evento}
            fnDelete={handleDelete}
            fnUpdate={handleUpdate}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;

// - Implementar a exclusão de eventos (com notificações)
