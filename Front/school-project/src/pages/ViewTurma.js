import React from "react";
import '../styles/ViewTurma.css';

export default function ViewTurma() {
    const students = [
        "João Silva",
        "Maria Oliveira",
        "Carlos Souza",
        "Ana Costa",
        "Lucas Pereira",
        "João Silva",
        "Maria Oliveira",
        "Carlos Souza",
        "Ana Costa",
        "Lucas Pereira",
        "João Silva",
        "Maria Oliveira",
        "Carlos Souza",
        "Ana Costa",
        "Lucas Pereira"
      ];

  return (
    <div className="turma-container">
      <h2 className="turma-title">Lista de Alunos</h2>
      <table className="turma-table">
        <thead>
          <tr>
            <th>Nome do Aluno</th>
          </tr>
        </thead>
        <tbody>
          {students.map((student, index) => (
            <tr key={index}>
              <td>{student}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
