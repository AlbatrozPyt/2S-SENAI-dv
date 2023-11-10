import React, { Profiler, useEffect, useState } from "react";
import "./HomePage.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import ContactSection from "../../Components/ContactSection/ContactSection";
import Container from "../../Components/Container/Container";
import NextEvent from "../../Components/NextEvent/NextEvent";
import axios from "axios";
import api from "../../Services/Services"

const HomePage = () => {
  useEffect(() => {
    //! chamar api
    async function getProximosEventos() {
      try {
        const promisse = await api.get(
          "/Evento/ListarProximos"
        );

        console.log(promisse.data);
        setNextEvents(promisse.data);
      } catch (error) {
        alert("Deu ruim na api!!!");
      }
    }
    getProximosEventos();
    console.log("A HOME FOI MONTADA");
  }, []);

  //* fake mock - api mocada
  const [nextEvents, setNextEvents] = useState([
  
  ]);

  return (
    <MainContent>
      <Banner />

      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Proximos Eventos"} />

          <div className="events-box">
            {
              nextEvents.map((e) => {
              return (
                <NextEvent
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={e.dataEvento}
                  idEvento={e.idEvento}
                />
              );
            })}
          </div>
        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
