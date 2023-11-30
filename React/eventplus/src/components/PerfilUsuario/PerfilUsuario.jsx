import React from "react";
import { useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import iconeLogout from "../../assets/images/icone-logout.svg";
import { UserContext } from "../../context/AuthContext";
import "./PerfilUsuario.css";

const PerfilUsuario = () => {
  const navigate = useNavigate();
  const { userData, setUserData } = useContext(UserContext);
  const logout = () => {
    localStorage.clear();
    setUserData({});
    navigate("/");
  };
  return (
    <div className="perfil-usuario">
      {userData.name ? (
        <>
          <span className="perfil-usuario__menuitem">{userData.name}</span>
          <img
            onClick={logout}
            title="Deslogar"
            className="perfil-usuario__icon"
            src={iconeLogout}
            alt="imagem ilustrativa de uma porta de saída do usuário "
          />
        </>
      ) : (
        <Link to="/login" className="navbar__item">Login</Link>
      )}

      {/* <Link to="/" className="perfil-usuario__menuitem"> */}
    </div>
  );
};

export default PerfilUsuario;
