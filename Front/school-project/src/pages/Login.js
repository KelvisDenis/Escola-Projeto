// src/components/Login.js
import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import '../styles/Login.css'; // Importa o arquivo CSS

export default function  Login () {
  const [matricula, setMatricula] = useState('');
  const [password, setPassword] = useState('');
  const nav = useNavigate();
  const [error, setError] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    // Simula a lógica de autenticação
    if (matricula === '' || password === '') {
      setError('Email and Password are required');
    } else {
      setError('');
      // Lógica para autenticar o usuário (substituir com a lógica real)
      console.log('Logged in with:', matricula, password);
      localStorage.setItem('authToken', matricula);
      localStorage.setItem('authTokenTimestamp', Date.now());
      nav('/home');

    }

  };
  useEffect(() => {
    const authTokenTimestamp = localStorage.getItem('authTokenTimestamp');
    if (authTokenTimestamp) {
      const expiryTime = 1 * 60 * 1000; // 1 minuto em milissegundos
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
    <div className="login-container">
      <h2 className="login-title">Entrar</h2>
      <form className="login-form" onSubmit={handleSubmit}>
        <div className="login-input-group">
          <label htmlFor="email" className="login-label">Matricula</label>
          <input
            type="email"
            id="email"
            value={matricula}
            onChange={(e) => setMatricula(e.target.value)}
            className="login-input"
            placeholder="Insira sua Matricula"
          />
        </div>
        <div className="login-input-group">
          <label htmlFor="password" className="login-label">Senha</label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="login-input"
            placeholder="Insira sua senha"
          />
        </div>
        <Link to="/home" className="login-link ">Entrar como professor?</Link>
        {error && <p className="login-error">{error}</p>}
        <button type="submit" className="login-button">Entrar</button>
      </form>
    </div>
  );
};

