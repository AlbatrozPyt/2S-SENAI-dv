import React, { useContext } from "react";
import { Link } from "react-router-dom";
import "./Nav.css";

import logoMobile from "../../assets/images/logo-white.svg";
import logoDesktop from "../../assets/images/logo-pink.svg";
import { UserContext } from "../../context/AuthContext";

const Nav = ({ setExibeNavbar, exibeNavbar }) => {
  const { userData } = useContext(UserContext);

  return (
    <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
      <span
        className="navbar__close"
        onClick={() => {
          setExibeNavbar(false);
        }}
      >
        x
      </span>

      <Link to="/">
        <img
          src={window.innerWidth >= 992 ? logoDesktop : logoMobile}
          alt="Event Plus logo"
          className="eventlogo__logo-image"
        />
      </Link>

      <div className="navbar__items-box">
        <Link to="/" className="navbar__item">
          Home
        </Link>

        {userData.role === "Administrador" ? (
          <>
            <Link to="/tipo-eventos" className="navbar__item">
              Tipo de eventos
            </Link>
            <Link to="/eventos" className="navbar__item">
              Eventos
            </Link>
          </>
        ) : userData.role === "Aluno" ? (
          <Link to="/eventos-aluno" className="navbar__item">
            Eventos Alunos
          </Link>
        ) : null}
      </div>
    </nav>
  );
};

export default Nav;
