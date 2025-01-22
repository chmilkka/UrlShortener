import { BrowserRouter } from "react-router-dom";
import { observer } from "mobx-react-lite";
import React from "react";




function App() {
  
  return (
  
    <BrowserRouter>
      <React.StrictMode>
      </React.StrictMode>
    </BrowserRouter>
  );
}

export default observer (App);
