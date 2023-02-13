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
import image from "./images/PizzaPhoto.jpg";

function App() {
  return (
    <div style={{ backgroundImage: `url(${image})`, width: '100vw', height:'100vw'}} className="button-container-div">
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
