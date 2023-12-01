import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "../Pages/HomePage/HomePage.jsx";
import TipoEventos from "../Pages/TipoEventos/TipoEventos.jsx";
import LoginPage from "../Pages/LoginPage/LoginPage.jsx";
import EventosPage from "../Pages/EventosPage/EventosPage.jsx";
import TestePage from "../Pages/TestePage/TestePage.jsx";
import Header from "../Components/Header/Header.jsx";
import Footer from "../Components/Footer/Footer.jsx";

import { PrivateRoute } from "../Routes/PrivateRoute";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route element={<LoginPage />} path="/login" />

        <Route
          path="/tipo-eventos"
          element={
            <PrivateRoute redirectTo="/">
              <TipoEventos />
            </PrivateRoute>
          }
        />

        <Route
          path="/eventos"
          element={
            <PrivateRoute redirectTo="/">
              <EventosPage />
            </PrivateRoute>
          }
        />

        <Route
          path="/eventos-aluno"
          element={
            <PrivateRoute redirectTo="/">
              <EventosPage />
            </PrivateRoute>
          }
        />

        <Route element={<TestePage />} path="/teste" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
