// src/components/NavBar.js
import React from 'react';
import '../styles/NavBar.css'; // 
import { Link } from 'react-router-dom';

export default function NavBar (){
  return (
    <nav className="navbar">
      <div className="navbar-container">
        <a href="/" className="navbar-logo">school</a>
        <ul className="navbar-menu">
          <li className="navbar-item"><Link to="/home" className="navbar-link">Home</Link></li>
          <li className="navbar-item"><Link to="/notas" className="navbar-link">Notas</Link></li>
          <li className="navbar-item"><Link to="/contact" className="navbar-link">Contact</Link></li>
        </ul>
      </div>
    </nav>
  );
};

