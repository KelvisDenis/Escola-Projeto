import React, { useRef } from "react";
import '../styles/ViewBoletim.css';

export default function ViewBoletim({ studentName='teste', gradess }) {
    const grades = [
        { subject: "Mathematics", sem1: ['4', '10', '8', '10', '8'], sem2: ['4', '10', '8', '10', '8'].sort() },
        { subject: "Science", sem1:  ['4', '10', '8', '10', '8'], sem2: ['4', '10', '8', '10', '8'].sort() },
        { subject: "History", sem1:  ['4', '10', '8', '10', '8'], sem2: ['4', '10', '8', '10', '8'].sort() }
      ];
  const printRef = useRef();

  const handlePrint = () => {
    window.print();
  };

  return (
    <div className="boletim-container" ref={printRef}>
      <h1 className="boletim-title">Boletim Escolar</h1>
      <h2 className="student-name">Aluno: {studentName}</h2>
      <table className="boletim-table">
        <thead>
          <tr>
            <th>Matéria</th>
            <th>Nota 1º Semestre</th>
            <th>Nota 2º Semestre</th>
            <th>Média Final</th>
          </tr>
        </thead>
        <tbody>
          {grades.map((grade, index) => (
            <tr key={index}>
              <td>{grade.subject}</td>
              <td>{grade.sem1.map((val, idx) =>
                 <span 
                 key={idx}>
                  {val}
               </span>
            )}</td>
              <td>{grade.sem2.map((val, idx) =>
                 <span 
                 key={idx}>
                  {val}
               </span>
            )}</td>
              <td>{((parseFloat(grade.sem1) + parseFloat(grade.sem2)) / 2).toFixed(2)}</td>
            </tr>
          ))}
        </tbody>
      </table>
      <button className="print-button" onClick={handlePrint}>Imprimir Boletim</button>
    </div>
  );
}
