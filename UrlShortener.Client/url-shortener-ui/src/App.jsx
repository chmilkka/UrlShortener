import { BrowserRouter } from "react-router-dom";
import { observer } from "mobx-react-lite";
import React from "react";
import Header from "./components/Header";
import AllRoutes from "./routes/AppRouter";
import BasicModal from "./components/modals/ViewDetailsModal";

function App() {
  
  return (
  
    <BrowserRouter>
      <React.StrictMode>
        <Header></Header>
        <AllRoutes/>
      </React.StrictMode>
    </BrowserRouter>
  );
}

export default observer (App);
