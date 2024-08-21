// src/components/Footer.js
import React from 'react';
import '../styles/Footer.css'; // 

export default function Footer (){
  return (
    <footer className="footer">
      <div className="footer-container">
        <p className="footer-text">© 2024 MyApp. All rights reserved.</p>
        <ul className="footer-links">
          <li><a href="/privacy" className="footer-link">Privacy Policy</a></li>
          <li><a href="/terms" className="footer-link">Terms of Service</a></li>
        </ul>
      </div>
    </footer>
  );
};

