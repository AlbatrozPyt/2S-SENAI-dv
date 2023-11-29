import logo from "./logo.svg";
import "./App.css";
import Rotas from "./routes.js";
import { UserContext } from "./context/AuthContext";
import { useState } from "react";

function App() {
  const [userData, setUserData] = useState({});

  return (
    <UserContext.Provider value={{userData, setUserData}}>
      <Rotas />
    </UserContext.Provider>
  );
}

export default App;
