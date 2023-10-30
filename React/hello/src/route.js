import React from 'react';
// import dos componentes de rota
import { BrowserRouter, Routes, Route } from 'react-router-dom';

// import da paginas
import HomePage from "./pages/HomePage/HomePage.jsx"
import LoginPage from "./pages/LoginPage/LoginPage.jsx"
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage.jsx"

const Rotas = () => {
    return (
        // Criar estruturas das rotas
        <div>
            <BrowserRouter>
                <Routes>
                    <Route element={<HomePage/>} path="/" exact />
                    <Route element={<LoginPage/>} path="/login" />
                    <Route element={<ProdutoPage/>} path="/produtos" />
                </Routes>
            </BrowserRouter>
        </div>
    );
};

export default Rotas;