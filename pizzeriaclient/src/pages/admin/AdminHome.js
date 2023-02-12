import React from "react";
import NavBar from "../../components/NavBar";

function AdminHome() {
    return (
        <div>
            <NavBar/>
            <p>This page is for admins</p>
            <p>They can add new locations, and make changes to the menu from admin portal</p>

            {/* <div className="navbar">
                <Link to="/">Home</Link>
                <Link to="./ModifyLocations">Modify Locations</Link>
                <Link to="./ModifyMenu">Modify Menu</Link>
            </div> */}
        </div>
    );
}

export default AdminHome;