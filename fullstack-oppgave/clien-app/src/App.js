import logo from "./logo.svg";
import React, { useState, useEffect } from "react";
import "./App.css";

function App() {
  const baseUrl = "https://localhost:7201/api/User";

  const [searchResults, setSearchResults] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const handleInputChange = (event) => {
    setSearchTerm(event.target.value.toLowerCase()); // Lowercase for case-insensitive search
  };
  const handleSearchClick = (event) => {
    console.log(searchTerm); // Lowercase for case-insensitive search
    console.log(searchResults);
    // egt et api kall på get user/{userName}
  };

  function getByName(name) {
    fetch(baseUrl)
      .then((response) => response.json())
      .then((json) => setSearchResults(json))
      .catch((error) => {
        setSearchResults([userList[0]]);
        console.log("Error while fetching users from server", error);
        console.log(userList[0]);
      });
  }

  return (
    <div className="App">
      <main>
        <p>Søk etter bruker</p>
        <input
          type="text"
          value={searchTerm}
          onChange={handleInputChange}
        ></input>
        <button onClick={() => getByName(searchTerm)}>søk</button>
        <table className="r">
          <thead className="dark:bg-gray-700">
            <tr className="text-left">
              <th className="p-3">id</th>
              <th className="p-3">version</th>
              <th className="p-3">Name</th>
            </tr>
          </thead>
          <tbody>
            {searchResults?.map((item, idx) => {
              console.log(searchResults);
              return (
                <tr
                  className="border-b border-opacity-20 dark:border-gray-700 dark:bg-gray-900"
                  key={idx}
                >
                  <td className="p-3">{item.id}</td>
                  <td className="p-3">{item.version}</td>
                  <td className="p-3">{item.name}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </main>
    </div>
  );
}

const userList = [
  {
    id: 1,
    version: 1,
    name: "Alice",
  },
  {
    id: 1,
    version: 1,
    name: "Alice",
  },
  {
    id: 1,
    version: 1,
    name: "Alice",
  },
];

export default App;
