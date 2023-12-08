import React, { useContext, useEffect, useState } from "react";
import Header from "../../Components/Header/Header";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Titulo/Title";
import Table from "./TableEva/TableEva";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Services";

import "./EventoAluno.css";
import { UserContext } from "../../context/AuthContext";

const EventosAluno = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [comentarios, setComentarios] = useState([]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {
    loadEventsType();
  }, [tipoEvento, userData.userId]);

  async function loadEventsType() {
    setShowSpinner(true);
    try {
      if (tipoEvento === "1") {
        const promiseGet = await api.get("/Evento");
        const promiseGetMy = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );

        const dadosMarcados = verificaPresenca(
          promiseGet.data,
          promiseGetMy.data
        );

        console.clear();
        console.log("DADOS MARCADOS");
        console.log(dadosMarcados);

        setEventos(promiseGet.data);
      } else {
        let arrEventos = [];
        const promiseGetMy = await api.get(
          `PresencasEvento/ListarMinhas/${userData.userId}`
        );

        promiseGetMy.data.forEach((element) => {
          arrEventos.push({
            ...element.evento,
            situacao: element.situacao,
            idPresencaEvento: element.idPresencaEvento,
          });
        });

        setEventos(arrEventos);
      }
    } catch (error) {
      console.log("Deu erro no GetEventos " + error);
    }

    setShowSpinner(false);
  }

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      for (let i = 0; i < eventsUser.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
          break;
        }
      }
    }
    return arrAllEvents;
  };

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  // ler um comentario - get
  async function loadMyComentary(idComentary) {
   
  }

  // cadastrar um comentario - post
  async function postMyComentary(descricao, idEvento) 
  {
    try {
      
    } catch (error) {
      
    }
  }

  const commentaryRemove = () => {
    
  };

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  async function handleConnect(
    idEvent,
    whatTheFunction,
    idPresencaEvento = null
  ) {
    // connect
    if (whatTheFunction === "connect") {
      try {
        const promiseConnect = await api.post("/PresencasEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
        });

        if (promiseConnect.status === 201) {
          loadEventsType();
          alert("Presenca confirmada, parabens");
        }
      } catch (error) {
        console.log("Erro ao conectar");
        console.log(error);
      }
      return;
    }

    console.log(idPresencaEvento);

    //unconnect
    try {
      const promiseDelete = await api.delete(
        `/PresencasEvento/DeletarPresenca/${idPresencaEvento}`
      );
      loadEventsType();

      alert(`Desconectar do evento ${idEvent}`);
    } catch (error) {
      alert(error);
    }
  }
  return (
    <>
      {/* <Header exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} /> */}

      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnGet={loadEventsType}
          fnPost={postMyComentary}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAluno;
