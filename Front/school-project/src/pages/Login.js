// src/components/Login.js
import React, { useState } from 'react';
import '../styles/Login.css'; // Importa o arquivo CSS

export default function  Login () {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = (e) => {
    e.preventDefault();
    // Simula a lógica de autenticação
    if (email === '' || password === '') {
      setError('Email and Password are required');
    } else {
      setError('');
      // Lógica para autenticar o usuário (substituir com a lógica real)
      console.log('Logged in with:', email, password);
    }
  };

  return (
    <div className="login-container">
      <h2 className="login-title">Entrar</h2>
      <form className="login-form" onSubmit={handleSubmit}>
        <div className="login-input-group">
          <label htmlFor="email" className="login-label">Email:</label>
          <input
            type="email"
            id="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            className="login-input"
            placeholder="Enter your email"
          />
        </div>
        <div className="login-input-group">
          <label htmlFor="password" className="login-label">Password:</label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="login-input"
            placeholder="Enter your password"
          />
        </div>
        {error && <p className="login-error">{error}</p>}
        <button type="submit" className="login-button">Login</button>
      </form>
    </div>
  );
};

