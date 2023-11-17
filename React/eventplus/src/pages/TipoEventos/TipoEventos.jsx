import React, { useEffect, useState } from "react";
import "./TipoEventos.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import Container from "../../Components/Container/Container";
import TableTps from "./TableTp/TableTp";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import api from "../../Services/Services";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import TableTp from "./TableTp/TableTp";
import Notification from "../../Components/Notification/Notification";

const TipoEventos = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");

  const [notifyUser, setNotifyUser] = useState({});

  const [tipoEventos, setTipoEventos] = useState([]); // array mocado

  useEffect(() => {
    async function getTiposEvento() {
      try {
        const promise = await api.get("/TiposEvento"); // Chama a rota de cadastro

        setTipoEventos(promise.data); // Atualiza tipos de evento
      } catch (error) {
        alert("Deu ruim tipos de evento");
      }
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
      alert("O titulo deve ter pelo menos 3 caracteres");
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
      console.log("Deu ruim na api");
      console.log(error);
    }
  }

  //* EDITAR CADASTRO

  async function handleUpdate(id) {
    try {
      const promiseUpdate = await api.put(`/TiposEvento/${id}`);

      setTipoEventos(promiseUpdate.data);
    } catch (error) {
      alert("Deu ruim " + error);
    }
  }

  function showUpdateForm() {
    alert("ola");
  }

  async function handleDelete(id) {
    try {
      const promise = await api.delete(`/TiposEvento/${id}`);
      const promiseGet = await api.get("/TiposEvento");
      setTipoEventos(promiseGet.data);
      console.log(promise.data);
    } catch (error) {
      alert("Deu ruim" + error);
    }
  }

  function editActionAbort() {
    alert("Cancelar a tela de edição de dados");
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
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
                <p>Tela de edição</p>
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
