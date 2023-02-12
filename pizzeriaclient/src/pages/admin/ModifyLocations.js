import React, { useState, useEffect } from "react";
import authorisedClient from "../../common/authorised-axios";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import Modal from "react-bootstrap/Modal";
import AddLocationModal from "../../components/AddLocationModal";
//import { Modal, Form, Input, Button } from 'antd';

export const ModifyLocations = () => {

    const [show, setShow] = useState(false);
    const handleClose = () => { setShow(false); };
    const handleShow = () => { setShow(true); }

    const [locations, setLocations] = useState([]);
    const [noLocationsStored, setNoLocationsStored] = useState(false)

    useEffect(() => {
        async function getAllLocations() {
            let response = await authorisedClient.get(
                `Admin/location/all`
            );
            setLocations(response.data);

            if (response.data.length === 0) {
                setNoLocationsStored(true)
            }
        }
        getAllLocations();
    }, []);
    return (
        <div>
            <p>This is Modify Locations page</p>

            {noLocationsStored && (<div>
                <p>Currently there are no active locations of Pizzeria. Please add new location to see any active locations</p>
            </div>)}

            {!noLocationsStored && (<div>
                <p>Following are the currently active locations of Pizzeria:</p>


                <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Location Name</th>
                            <th scope="col">Address</th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {locations.map((location, index) => (
                            <tr key={location.id}>
                                <td>{location.name}</td>
                                <td>{location.address}</td>
                                <td><button type="button" className="btn btn-primary">Edit</button></td>
                                <td><button type="button" className="btn btn-danger">Delete</button></td>
                            </tr>
                        ))}

                    </tbody>
                </table>

                <AddLocationModal
                    show={show}
                    handleClose={handleClose}
                />
                <Button onClick={handleShow} type="button" className="btn btn-primary">Add a new Location</Button>


            </div>)}

        </div>
    );
}

export default ModifyLocations;