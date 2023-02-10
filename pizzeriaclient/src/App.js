import logo from './logo.svg';
import './App.css';
import React from "react";
import "./bootstrap.min.css";
import { Switch, Route } from "react-router-dom";
import Home from "./pages/Home";
import NewOrder from './pages/NewOrder';
import NotFoundPage from "./pages/NotFound";

function App() {
  return (
    // <div className="App">
    //   <header className="App-header">
    //     <img src={logo} className="App-logo" alt="logo" />
    //     <p>
    //       Edit <code>src/App.js</code> and save to reload.
    //     </p>
    //     <a
    //       className="App-link"
    //       href="https://reactjs.org"
    //       target="_blank"
    //       rel="noopener noreferrer"
    //     >
    //       Learn React
    //     </a>
    //   </header>
    // </div>
    <div>
      <Switch>
      <Route exact path="/" component={Home} />
        <Route exact path="/neworder" component={NewOrder} />
        {/* <Route path="/contact" component={Contact} />
        <Route path="/addpatient" component={AddPatient} />
        <Route path="/viewpatients" component={ViewPatients} />
        <Route component={NotFoundPage} /> */}
        <Route component={NotFoundPage} />
      </Switch>
    </div>
  );
}

export default App;
