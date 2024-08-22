// src/components/NavBar.js
import { useEffect } from 'react';
import React from 'react';
import '../styles/NavBar.css'; // 
import { Link, useNavigate } from 'react-router-dom';

export default function NavBar (){
  const isAuth = localStorage.getItem('authToken');
  const nav = useNavigate();

  useEffect(() => {
    console.log(localStorage.getItem('authToken'))
    const authTokenTimestamp = localStorage.getItem('authTokenTimestamp');
    console.log(authTokenTimestamp);
    if (authTokenTimestamp) {
      const expiryTime = 1 * 60 * 10000; // 1 minuto em milissegundos
      const currentTime = Date.now();

      if (currentTime - authTokenTimestamp > expiryTime) {
        // O tempo já passou, então remova o token
        localStorage.removeItem('authToken');
        localStorage.removeItem('authTokenTimestamp');
        alert('Sua sessão expirou.');
        nav('/'); // Redireciona para a página de login
      }
    }
  }, [nav]);

  return (
    <nav className="navbar">
      <div className="navbar-container">
        {isAuth ?(
          <>
          <Link to="/home" className="navbar-logo">school</Link>
          <ul className="navbar-menu">
          <li className="navbar-item"><Link to="/home" className="navbar-link">Home</Link></li>
        </ul>
        </>
        ) : (
          // Se precisar de um bloco condicional para usuários não autenticados, você pode adicionar aqui
          <>
          <Link to="/" className="navbar-logo">school</Link>
          </>
        )}
        
      </div>
    </nav>
  );
};

