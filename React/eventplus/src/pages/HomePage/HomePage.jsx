import React from "react";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import ContactSection from "../../Components/ContactSection/ContactSection";
import NextEvent from "../../Components/NextEvent/NextEvent";

const HomePage = () => {
  return (
    <MainContent>
      <Banner/>

      <NextEvent
        title={"C# na pratica"}
        description={"Evento pratico para a linguagem de programação C#."}
        eventDate={"12/12/2023"}
      />

      <VisionSection/>
      <ContactSection/>

   
    </MainContent>
  );
};

export default HomePage;
