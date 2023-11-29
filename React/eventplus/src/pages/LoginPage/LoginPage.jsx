import React, { useContext, useState } from "react";
import ImageIllustrator from "../../Components/ImageIlustrator/ImageIllustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../Components/FormComponents/FormComponents";

import loginImage from "../../assets/images/login.svg";

import api from "../../Services/Services";

import "./LoginPage.css";
import { UserContext, userDecodeToken } from "../../context/AuthContext";

const LoginPage = () => {
  const [user, setUser] = useState({
    email: "admin@admin.com",
    senha: "minhoca",
  });

  const {userData, setUserData} = useContext(UserContext);

  async function handleSubmit(e) {
    e.preventDefault();
    console.log(user);

    if (user.email.length >= 3 && user.senha.length >= 3) {
      // chamar api
      try {
        const retornoPost = await api.post("/Login", {
          email: user.email,
          senha: user.senha,
        });

        console.log(retornoPost.data.token);

        const userFullToken = userDecodeToken(retornoPost.data.token);

        localStorage.setItem("token", JSON.stringify(userFullToken))

        setUserData(userFullToken); // guarda os dados decodificados(payload)
      } catch (error) {
        // BadRequest(401)
        alert("Usuario ou Senha incorretos. Verifique a conexão da internet");
      }
    } else {
      alert(" A senha precisar ter mais que 3 caracteres");
    }
  }

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={loginImage}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                setUser({ ...user, email: e.target.value.trim() });
              }}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              sz
              manipulationFunction={(e) => {
                setUser({ ...user, senha: e.target.value.trim() });
              }}
              placeholder="****"
            />

            <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
