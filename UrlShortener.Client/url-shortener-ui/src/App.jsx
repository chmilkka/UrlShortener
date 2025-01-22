import { BrowserRouter } from "react-router-dom";
import { observer } from "mobx-react-lite";
import React from "react";
import Header from "./components/Header";
import AllRoutes from "./routes/AppRouter";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
  
  return (
  
    <BrowserRouter>
      <React.StrictMode>
        <Header></Header>
        <AllRoutes/>
        <ToastContainer 
            position={"bottom-right"} 
            limit={3} 
            autoClose={5000} 
            hideProgressBar={false}
          />
      </React.StrictMode>
    </BrowserRouter>
  );
}

export default observer (App);
