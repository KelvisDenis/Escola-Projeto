import React from "react";
import '../styles/ViewNotas.css'; // 


export default function ViewNotas({ StudentName, Grades }){
    const studentName = "John Doe";
    const grades = [
      { subject: "Mathematics", score: ['4', '10', '8', '10', '8'], semestre: ['4', '10', '8', '10', '8'], situation: 'Reprovado' },
      { subject: "Science",score: ['4', '10', '8', '10', '8'] ,  semestre: ['4', '10', '8', '10', '8'].sort(), situation: 'Aprovado' },
      { subject: "History", score: ['4', '10', '8', '10', '8'] , semestre: ['4', '10', '8', '10', '8'], situation: 'Reprovado' },
      { subject: "English", score: ['4', '10', '8', '10', '8'],  semestre: ['4', '10', '8', '10', '8'].sort(), situation: 'Aprovado' }
    ];
    return (
        <div className="grades-container">
          <h2 className="student-name">{studentName}'s Grades</h2>
          <table className="grades-table">
            <thead>
              <tr>
                <th>Materias</th>
                <th>1 Semestre</th>
                <th>2 Semestre</th>
                <th>Situação</th>
              </tr>
            </thead>
            <tbody>
              {grades.map((grade, index) => (
                <tr key={index}>
                  <td>{grade.subject}</td>
                  <td>
                    {grade.score.map((note, idx) => (
                      <span 
                        key={idx} 
                        className={parseFloat(note) >= 7 ? 'score-pass' : 'score-fail'}>
                         { note} <span className="score-barra">|</span>
                      </span>
                    ))}
                  </td>
                  <td>
                    {grade.semestre.map((se, idx) => (
                      <span 
                        key={idx} 
                        className={parseFloat(se) >= 7 ? 'score-pass' : 'score-fail'}>
                        {se} <span className="score-barra">|</span>
                      </span>
                     
                    ))}
                  </td>
                  <td>{grade.situation}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      );
}