import React from "react";
import Title from "../../Components/Titulo/Title";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";

const HomePage = () => {
  return (
    <MainContent>
      <Banner/>

      <VisionSection/>
    </MainContent>
  );
};

export default HomePage;
