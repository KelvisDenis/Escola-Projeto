import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './pages/Login';
import NavBar from './components/NavBar';
import Footer from './components/Footer';
import Home from './pages/Home';
import ViewNotas from './pages/ViewNotas';
import ProtectedRoute from './ProtectRoutes';
import ViewFrequencia from './pages/ViewFrequencia';
import ViewBoletim from './pages/ViewBoletim';
import ViewTurma from './pages/ViewTurma';



export default function MyRouter(){
    return(
        <Router>
            <NavBar/>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/home" element={<ProtectedRoute element={<Home />}/>} />
                <Route path="/notas" element={<ProtectedRoute element={<ViewNotas />}/>} />
                <Route path="/frequencia" element={<ProtectedRoute element={<ViewFrequencia />}/>} />
                <Route path="/boletim" element={<ProtectedRoute element={<ViewBoletim />}/>} />
                <Route path="/turma" element={<ProtectedRoute element={<ViewTurma />}/>} />
            </Routes>
            <Footer/>
        </Router>
    )
}