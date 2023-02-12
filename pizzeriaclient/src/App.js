import './App.css';
import React from "react";
import "./bootstrap.min.css";
import { Switch, Route } from "react-router-dom";
import Home from "./pages/Home";
import NewOrder from './pages/NewOrder';
import NotFoundPage from "./pages/NotFound";
import Footer from "./components/Footer";
import AdminHome from "./pages/admin/AdminHome";
import ModifyLocations from "./pages/admin/ModifyLocations";
import ModifyMenu from "./pages/admin/ModifyMenu";

function App() {
  return (
    <div className="button-container-div mt-4">
      <Switch>
        <Route exact path="/" component={Home} />
        <Route path="/neworder" component={NewOrder} />
        <Route path="/adminhome" component={AdminHome} />
        <Route path="/adminmodifylocations" component={ModifyLocations} />
        <Route path="/adminmodifymenu" component={ModifyMenu} />
        <Route component={NotFoundPage} />
      </Switch>
      <Footer />
    </div>
  );
}

export default App;
