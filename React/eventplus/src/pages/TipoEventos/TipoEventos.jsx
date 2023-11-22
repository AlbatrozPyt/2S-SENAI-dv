import React, { useEffect, useState } from "react";
import "./TipoEventos.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import api from "../../Services/Services";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import TableTp from "./TableTp/TableTp";
import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";
import { wait } from "@testing-library/user-event/dist/utils";

const TipoEventos = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  const [idEvento, setIdEvento] = useState("");

  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSppiner] = useState(false);

  const [tipoEventos, setTipoEventos] = useState([]); // array mocado

  useEffect(() => {
    async function getTiposEvento() {
      setShowSppiner(true);
      try {
        const promise = await api.get("/TiposEvento"); // Chama a rota de cadastro

        setTipoEventos(promise.data); // Atualiza tipos de evento
      } catch (error) {
        alert("Deu ruim tipos de evento");
      }
      setShowSppiner(false);
    }
    getTiposEvento();
    console.log("Tipos de evento montada");
  }, []);

  //* FAZER CADASTRO

  async function handleSubmit(e) {
    // parar submit do form
    e.preventDefault();

    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
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

    // chamar api
    try {
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      const retorno = await api.post("/TiposEvento", { titulo: titulo }); // Cadastra tipo de evento
      const promiseGet = await api.get("/TiposEvento"); // Atualiza a pagina
      setTipoEventos(promiseGet.data); // Atualiza a pagina
      console.log(retorno.data); // Mostra o tipo cadastrado
      setTitulo(""); // limpa a variavel
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Deu ruim na api`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de Falha",
        showMessage: true,
      });
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

  //* -=-=-=-=-=-EDITAR CADASTRO-=-=-=-=-=-

  async function handleUpdate(e) {
    e.preventDefault();

    try {
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atulaizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });

      // salvar os dados
      const retornoPut = await api.put(`/TiposEvento/${idEvento}`, {
        titulo: titulo,
      });

      // atualizar o state(api.get)
      const retornoGet = await api.get(`/TiposEvento/`);
      setTipoEventos(retornoGet.data);

      // limpar titulo
      editActionAbort();
    } catch (error) {
      alert("Problemas no update");
    }
  }

  async function showUpdateForm(id) {
    try {
      setFrmEdit(true);

      //fazer o get by id
      const retorno = await api.get(`/TiposEvento/${id}`);
      // preencher o titulo no state
      setTitulo(retorno.data.titulo);
      setIdEvento(retorno.data.idTipoEvento);
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `showUpdateForm nao foi!!!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de erro",
        showMessage: true,
      });
    }
  }

  async function handleDelete(id) {
    try {
      const promise = await api.delete(`/TiposEvento/${id}`);
      const promiseGet = await api.get("/TiposEvento");
      setTipoEventos(promiseGet.data);
      console.log(promise.data);

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
        titleNote: "Erro",
        textNote: `Delete nao foi!!!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de erro",
        showMessage: true,
      });
    }
  }

  function editActionAbort() {
    setFrmEdit(false);
    setTitulo("");
    setIdEvento(null);
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />

      {showSpinner ? <Spinner /> : null}

      {/* Cadastro de tipos de eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Tipos de evento Page"} />
            <ImageIllustrator
              alterText={"imagem"}
              imageRender={eventTypeImage}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
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
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  {/* <span>{titulo}</span> */}

                  <Button
                    type={"submit"}
                    name={"cadastar"}
                    id={"cadastar"}
                    textButton={"Cadastar"}
                  />
                </>
              ) : (
                <>
                  <Input
                    id="titulo"
                    placeholder="Título"
                    name="titulo"
                    type="text"
                    required="required"
                    value={titulo}
                    manipulationFunction={(e) => setTitulo(e.target.value)}
                  />

                  <div className="buttons-editbox">
                    <Button
                      type={"submit"}
                      name={"atualizar"}
                      id={"atualizar"}
                      textButton={"Atualizar"}
                      additionalClass="button-component--middle"
                    />

                    <Button
                      type={"button"}
                      name={"cancelar"}
                      id={"cancelar"}
                      textButton={"Cancelar"}
                      manipulationFunction={editActionAbort}
                      additionalClass="button-component--middle"
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de tipos de eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Eventos"} color="white" />

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
