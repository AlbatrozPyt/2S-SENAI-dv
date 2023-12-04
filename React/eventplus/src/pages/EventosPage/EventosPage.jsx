import React, { useEffect, useState } from "react";
import "./EventosPage.css";
import eventImage from "../../assets/images/evento.svg";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Titulo/Title";
import Container from "../../Components/Container/Container";
import TableTp from "./TableTp/TableTp";
import {
  Button,
  Input,
  Select,
} from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";
import Notification from "../../Components/Notification/Notification";

const EventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [frmEditData, setFrmEditData] = useState({});

  const [evento, setEvento] = useState([]);
  const [tipoEvento, setTipoEvento] = useState([]);

  const [notifyUser, setNotifyUser] = useState({});

  const [idEvento, setIdEvento] = useState("");
  const [nome, setNome] = useState("");
  const [descricao, setDescricao] = useState("");
  const [tituloTipoEvento, setTituloTipoEvento] = useState("");
  const [dataEvento, setDataEvento] = useState("");
  const [idInstituicao, setIdInstituicao] = useState(
    "dceef91c-f3cc-490f-802d-a68722be9f4f"
  );
  const [idTipoEvento, setIdTipoEvento] = useState("");

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

    async function getTiposEvento() {
      try {
        const retornoGetTipos = await api.get("/TiposEvento"); // Chama a rota de cadastro

        setTipoEvento(retornoGetTipos.data); // Atualiza tipos de evento
      } catch (error) {
        alert("Deu ruim tipos de evento");
      }
    }

    async function getInstituicao() {
      try {
        const retornoGetInstituicao = await api.get("/Instituicao"); // Chama a rota de cadastro

        setIdInstituicao(retornoGetInstituicao.data.idInstituicao); // Atualiza tipos de evento
      } catch (error) {
        alert("Deu ruim tipos de evento");
      }
    }

    getListaEventos();
    getTiposEvento();
    getInstituicao();
  }, []);

  //* CADASTRAR
  async function handleSubmit(e) {
    e.preventDefault();

    // validar pelo menos 3 caracteres
    if (nome.trim().length < 3) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `O titulo deve ter pelo menos 3 caracteres`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }

    try {
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      const retornoPost = await api.post("/Evento", {
        nomeEvento: nome,
        dataEvento: dataEvento,
        descricao: descricao,
        idInstituicao: idInstituicao,
        idTipoEvento: idTipoEvento,
      }); // Cadastra evento
      const retornoGet = await api.get("/Evento"); // Atualiza a pagina
      setEvento(retornoGet.data); // Atualiza a pagina
      editActionAbort();
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Deu ruim na api`,
        imgIcon: "danger",
        imgAlt: "Imagem de Falha",
        showMessage: true,
      });
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

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
        imgAlt: "Imagem de erro.",
        showMessage: true,
      });
    }
  }

  //* ATUALIZAR
  async function handleUpdate(e) {
    e.preventDefault();

    try {
      const retornoPut = await api.put("/Evento", {
        nomeEvento: nome,
        dataEvento: dataEvento,
        descricao: descricao,
        idInstituicao: idInstituicao,
        idTipoEvento: idTipoEvento,
      }); // Atualizar evento

      // atualizar o state(api.get)
      const retornoGet = await api.get("/Evento");
      setEvento(retornoGet.data);

      editActionAbort();
    } catch (error) {
      setNotifyUser({
        titleNote: "Falha",
        textNote: `Problemas na api!`,
        imgIcon: "danger",
        imgAlt: "Imagem.",
        showMessage: true,
      });
    }
  }

  async function showUpdateForm(evento) {
    try {
      setFrmEditData(evento);
      setFrmEdit(true);

      //fazer o get by id
      const retornoGetById = await api.get(`/TiposEvento/${evento.idEvento}`);
      // preencher o titulo no state
      setNome(retornoGetById.data.nomeEvento);
      setDataEvento(retornoGetById.data.dataEvento);
      setIdInstituicao(retornoGetById.data.idInstituicao);
      setDescricao(retornoGetById.data.descricao);
      setIdTipoEvento(retornoGetById.data.idTipoEvento);
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `showUpdateForm nao foi!!!`,
        imgIcon: "danger",
        imgAlt: "Imagem de erro",
        showMessage: true,
      });
    }
  }

  function editActionAbort() {
    setFrmEdit(false);
    setNome("");
    setDataEvento("");
    setDescricao("");
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Eventos"} additionalClass="margem-acima" />

            <ImageIllustrator imageRender={eventImage} alterText="Imagem" />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                <>
                  <Input
                    type={"text"}
                    placeholder={"Nome"}
                    id={"nome"}
                    name={"nome"}
                    required={"required"}
                    value={nome}
                    manipulationFunction={(e) => {
                      setNome(e.target.value);
                    }}
                  />

                  <Input
                    type={"text"}
                    placeholder={"Descricao"}
                    id={"descricao"}
                    name={"descricao"}
                    required={"required"}
                    value={descricao}
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />

                  <Select
                    dados={tipoEvento}
                    value={idTipoEvento}
                    manipulationFunction={(e) => {
                      // setTituloTipoEvento(e.target.value);
                      setIdTipoEvento(e.target.value);
                    }}
                    required={"required"}
                  />

                  <Input
                    type={"date"}
                    id={"data"}
                    name={"data"}
                    required={"required"}
                    value={dataEvento}
                    manipulationFunction={(e) => {
                      setDataEvento(e.target.value);
                    }}
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
                    manipulationFunction={(e) => {
                      setNome(e.target.value);
                    }}
                  />

                  <Input
                    type={"text"}
                    placeholder={"Descricao"}
                    id={"descricao"}
                    name={"descricao"}
                    required={"required"}
                    value={descricao}
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />

                  <Select
                    dados={tipoEvento}
                    value={idTipoEvento}
                    manipulationFunction={(e) => {
                      // setTituloTipoEvento(e.target.value);
                      setIdTipoEvento(e.target.value);
                    }}
                    required={"required"}
                  />

                  <Input
                    type={"date"}
                    id={"data"}
                    name={"data"}
                    required={"required"}
                    value={dataEvento}
                    manipulationFunction={(e) => {
                      setDataEvento(e.target.value);
                    }}
                  />

                  <div className="buttons-editbox">
                    <Button
                      type={"submit"}
                      id={"updateEvento"}
                      name={"updateEvento"}
                      textButton={"Atualizar"}
                      additionalClass={
                        "btn-cadastrar button-component--middle button-component"
                      }
                    />

                    <Button
                      type={"submit"}
                      id={"cancelarEvento"}
                      name={"cancelarEvento"}
                      textButton={"Cancelar"}
                      additionalClass={
                        "btn-cadastrar button-component--middle button-component"
                      }
                      manipulationFunction={editActionAbort}
                    />
                  </div>
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
            fnUpdate={showUpdateForm}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
