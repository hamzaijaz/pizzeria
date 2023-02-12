import React from "react";
import { Link } from "react-router-dom";

function NavBar() {
    return (
        <div className="navbar">
            <Link to="/">Home</Link>
            <Link to="./adminmodifylocations">Modify Locations</Link>
            <Link to="./adminmodifymenu">Modify Menu</Link>
        </div>
    );
}

export default NavBar;