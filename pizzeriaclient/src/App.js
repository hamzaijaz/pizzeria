import './App.css';
import React from "react";
import "./bootstrap.min.css";
import { Switch, Route } from "react-router-dom";
import Home from "./pages/Home";
import NewOrder from './pages/NewOrder';
import NotFoundPage from "./pages/NotFound";
import Footer from "./components/Footer";

function App() {
  return (
    <div className="button-container-div mt-4">
      <Switch>
      <Route exact path="/" component={Home} />
        <Route exact path="/neworder" component={NewOrder} />
        <Route component={NotFoundPage} />
      </Switch>
      <Footer />
    </div>
  );
}

export default App;
