import React from "react";
import { Link } from "react-router-dom";
import "./Nav.css";

import logoMobile from "../../assets/images/logo-white.svg";
import logoDesktop from "../../assets/images/logo-pink.svg";

const Nav = ({ setExibeNavbar, exibeNavbar }) => {
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
        <Link to="/">Home</Link>
        <Link to="/tipo-eventos">Tipo de eventos</Link>
        <Link to="/eventos">Eventos</Link>
        <Link to="/login">Login</Link>
      </div>
    </nav>
  );
};

export default Nav;
