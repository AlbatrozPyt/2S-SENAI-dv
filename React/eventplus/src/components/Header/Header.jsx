import React, { useState } from "react";
import "./Header.css";
import Container from "../Container/Container.jsx";
import PerfilUsuario from "../PerfilUsuario/PerfilUsuario.jsx";
import Nav from "../Nav/Nav.jsx";

import menubar from "../../assets/images/menubar.png";

const Header = () => {
  const [exibeNavbar, setExibeNavbar] = useState(false);
  console.log(`Exibe Navbar: ${exibeNavbar}`);

  return (
    <header className="headerpage">
      <Container>
        <div className="header-flex">
          <img
            src={menubar}
            alt="Imagem menu de barras. Serve para exibir ou esconder o menu no smartphone."
            onClick={() => {setExibeNavbar(true)}}
            className="headerpage__menubar"
          />

          <Nav 
            exibeNavbar={exibeNavbar}
            setExibeNavbar={setExibeNavbar}
          />

          <PerfilUsuario />
        </div>
      </Container>
    </header>
  );
};

export default Header;
