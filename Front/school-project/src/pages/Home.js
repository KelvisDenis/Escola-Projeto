// src/pages/Home.js
import React from 'react';
import '../styles/Home.css'; // Importa o arquivo CSS
// import { Link } from 'react-router-dom';

export default function Home  (){
  return (
    <div className="home-container">
      <header className="home-header">
        <h1>Welcome to My React App</h1>
        <p>Your one-stop solution for all your needs.</p>
      </header>
      
      <section className="home-cards">
        <div className="card">
          <h3>Card 1</h3>
          <p>Details about card 1.</p>
        </div>
        <div className="card">
          <h3>Card 2</h3>
          <p>Details about card 2.</p>
        </div>
        <div className="card">
          <h3>Card 3</h3>
          <p>Details about card 3.</p>
        </div>
        <div className="card">
          <h3>Card 4</h3>
          <p>Details about card 4.</p>
        </div>
      </section>
    </div>
  );
}
