import { BrowserRouter } from "react-router-dom";
import { observer } from "mobx-react-lite";
import React from "react";
import Header from "./components/Header";

function App() {
  
  return (
  
    <BrowserRouter>
      <React.StrictMode>
        <Header></Header>
      </React.StrictMode>
    </BrowserRouter>
  );
}

export default observer (App);
