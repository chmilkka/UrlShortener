import { BrowserRouter } from "react-router-dom";
import { observer } from "mobx-react-lite";
import React from "react";
import Header from "./components/Header";
import LoginPage from "./pages/LoginPage";

function App() {
  
  return (
  
    <BrowserRouter>
      <React.StrictMode>
        <Header></Header>
        <LoginPage></LoginPage>
      </React.StrictMode>
    </BrowserRouter>
  );
}

export default observer (App);
