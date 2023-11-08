import React from "react";
import "./HomePage.css";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import ContactSection from "../../Components/ContactSection/ContactSection";
import Container from "../../Components/Container/Container";
import NextEvent from "../../Components/NextEvent/NextEvent";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />

      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Proximos Eventos"}/>

          <div className="event-box">
            <NextEvent
              title={"C# na pratica"}
              description={"Evento da linguagem de programação C#."}
              eventDate={"12/12/2023"}
            />
          </div>

        </Container>
      </section>

      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;
