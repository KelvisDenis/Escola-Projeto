import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './pages/Login';
import NavBar from './components/NavBar';
import Footer from './components/Footer';
import Home from './pages/Home';

export default function MyRouter(){
    return(
        <Router>
            <NavBar/>
            <Routes>
                <Route path="/" element={<Login />} />
                <Route path="/home" element={<Home />} />
            </Routes>
            <Footer/>
        </Router>
    )
}