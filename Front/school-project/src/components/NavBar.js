// src/components/NavBar.js
import React from 'react';
import '../styles/NavBar.css'; // 
import { Link } from 'react-router-dom';

export default function NavBar (){
  return (
    <nav className="navbar">
      <div className="navbar-container">
        <Link to="/home" className="navbar-logo">school</Link>
        <ul className="navbar-menu">
          <li className="navbar-item"><Link to="/home" className="navbar-link">Home</Link></li>
        
        </ul>
      </div>
    </nav>
  );
};

