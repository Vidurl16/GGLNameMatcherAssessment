import React, { useState } from "react";
import axios from "axios";
import { FileDrop } from "react-file-drop";

function MatchName() {
  const [name1, setName1] = useState("");
  const [name2, setName2] = useState("");
  const [result, setResult] = useState("");

  const handleSubmit = async (event) => {
    event.preventDefault();
    const response = await axios.post(
      `https://localhost:7162/MatchName?name1=${name1}&name2=${name2}`
    );
    setResult(response.data);
  };

  return (
    <div style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
      <form onSubmit={handleSubmit} style={{ display: "flex", flexDirection: "column", alignItems: "center" }}>
        <div style={{ margin: "10px 0" }}>
          <label style={{ fontWeight: "bold", marginRight: "10px" }}>Name 1:</label>
          <input type="text" value={name1} onChange={(e) => setName1(e.target.value)} style={{ padding: "5px", borderRadius: "5px", border: "none", boxShadow: "0 0 5px rgba(0, 0, 0, 0.3)" }} />
        </div>
        <div style={{ margin: "10px 0" }}>
          <label style={{ fontWeight: "bold", marginRight: "10px" }}>Name 2:</label>
          <input type="text" value={name2} onChange={(e) => setName2(e.target.value)} style={{ padding: "5px", borderRadius: "5px", border: "none", boxShadow: "0 0 5px rgba(0, 0, 0, 0.3)" }} />
        </div>
        <button type="submit" style={{ padding: "10px", borderRadius: "5px", border: "none", backgroundColor: "#3498db", color: "#fff", fontWeight: "bold", cursor: "pointer", transition: "background-color 0.3s ease" }}>Submit</button>
      </form>
      <div className="result" style={{ marginTop: "20px", fontSize: "20px", fontWeight: "bold" }}>{result}</div>
    </div>
  );
}

export default MatchName;