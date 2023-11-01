import React from "react";
import { Link } from "react-router-dom";
import "./Nav.css";

import logoMobile from  "../../assets/images/logo-white.svg"
import logoDesktop from  "../../assets/images/logo-pink.svg"

const Nav = () => {
  return (
    <nav className="navbar">
      <span className="navbar__close">x</span>

      <Link to="/">
        <img src={window.innerWidth >= 992 ? logoDesktop : logoMobile} alt="Event Plus logo" />
      </Link>

      <div className="navbar__item-box">
        <Link to="/">Home</Link>
        <Link to="/tipo-eventos">Tipo de eventos</Link>
        <Link to="/eventos">Eventos</Link>
        <Link to="/login">Login</Link>
      </div>
    </nav>
  );
};

export default Nav;
