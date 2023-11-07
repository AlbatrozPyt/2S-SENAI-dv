import React from "react";
import Title from "../Titulo/Title";
import "./VisionSection.css";

const VisionSection = () => {
  return (
    <section className="vision">
      <div className="vision__box">
        <Title
          titleText={"Visão"}
          color="white"
          additionalClass="vision__title"
        />

        <p>
          Lorem ipsum dolor sit amet consectetur adipisicing elit. Tempora
          totam, dolorem incidunt ad nesciunt dolores recusandae iusto voluptas
          quod perspiciatis vel atque eaque maiores nisi natus eveniet nulla sit
          ex. Commodi voluptatem rerum cupiditate laboriosam vel in
          reprehenderit, recusandae eius neque adipisci minus officia nostrum
          laudantium suscipit ratione reiciendis? Eum commodi eligendi ducimus
          incidunt porro nobis nemo optio neque consequuntur.
        </p>
      </div>
    </section>
  );
};

export default VisionSection;
