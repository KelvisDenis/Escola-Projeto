// src/pages/Home.js
import React from 'react';
import '../styles/Home.css'; // Importa o arquivo CSS
 import { Link } from 'react-router-dom';

export default function Home  (){
  
  return (
    <div className="home-container">
      <header className="home-header">
        <h1>Àrea do aluno</h1>
        <hr></hr>
      </header>
      
      <section className="home-cards">
        <div className="card">
          <h3>Ver notas</h3>
          <Link to='/notas' className='home-link'>vizualizar</Link>
        </div>
        <div className="card">
          <h3>Ver Frequencia</h3>
          <Link to={'/frequencia'} className='home-link'>vizualizar</Link>
        </div>
        <div className="card">
          <h3>Imprimir Boletim</h3>
          <Link to={'/boletim'} className='home-link'>imprimir</Link>
        </div>
        <div className="card">
          <h3>Ver Turma</h3>
          <Link to={'/turma'} className='home-link'>vizualizar</Link>
        </div>
      </section>
    </div>
  );
}
