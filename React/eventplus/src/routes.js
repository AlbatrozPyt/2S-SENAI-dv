import React from 'react';
import {BrowserRouter, Routes, Route} from "react-router-dom";

import HomePage from "./Pages/HomePage/HomePage.jsx"
import TipoEventos from "./Pages/TipoEventos/TipoEventos.jsx"
import LoginPage from "./Pages/LoginPage/LoginPage.jsx"
import EventosPage from "./Pages/EventosPage/EventosPage.jsx"
import TestePage from "./Pages/TestePage/TestePage.jsx"
import Header from './Components/Header/Header.jsx';
import Footer from './Components/Footer/Footer.jsx';


const Rotas = () => {
    return (    
        <BrowserRouter>
            <Header/>
            <Routes>
                <Route element={<HomePage/>} path="/" exact />
                <Route element={<TipoEventos/>} path="/tipo-eventos" />
                <Route element={<LoginPage/>} path="/login" />
                <Route element={<EventosPage/>} path="/eventos" />
                <Route element={<TestePage/>} path="/teste" />
            </Routes>
            <Footer/>
        </BrowserRouter>
    );
};

export default Rotas;