import React, { useEffect, useState } from "react";
import "./HomePage.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import ContactSection from "../../Components/ContactSection/ContactSection";
import Container from "../../Components/Container/Container";
import NextEvent from "../../Components/NextEvent/NextEvent";

const HomePage = () => {
  
  useEffect(() => {
    async function getProximosEventos(params) {
      
    }
  }, []);


  const [nextEvents, setNextEvents] = useState([
    {
      id: 1,
      title: "Evento X",
      descricao: "Evento SQL Server",
      data: "10/11/2023",
    },
    {
      id: 2,
      title: "Evento Y",
      descricao: "Bora codar JS",
      data: "11/11/2023",
    },
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
                  title={e.title}
                  description={e.descricao}
                  eventDate={e.data}
                  idEvento={e.id}
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
