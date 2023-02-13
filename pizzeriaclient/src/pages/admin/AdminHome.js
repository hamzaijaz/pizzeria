import React from "react";
import NavBar from "../../components/NavBar";

function AdminHome() {
    return (
        <div>
            <NavBar/>
            <p className="pt-4">This page is for admins</p>
            <p>They can add new locations, and make changes to the menu from admin portal</p>
        </div>
    );
}

export default AdminHome;