import React from "react";
import '../styles/Frequencia.css';


export default function ViewFrequencia(){
    const frequencias = [
        { subject: "Mathematics", attended: 20, total: 25 },
        { subject: "Science", attended: 18, total: 25 },
        { subject: "History", attended: 22, total: 25 }
      ];
    return (
        <div className="frequencia-container">
          <h2 className="frequencia-title">Frequência do Aluno</h2>
          <table className="frequencia-table">
            <thead>
              <tr>
                <th>Matéria</th>
                <th>Aulas Assistidas</th>
                <th>Total de Aulas</th>
              </tr>
            </thead>
            <tbody>
              {frequencias.map((freq, index) => (
                <tr key={index}>
                  <td>{freq.subject}</td>
                  <td>{freq.attended}</td>
                  <td>{freq.total}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      );
}