import React, { useState, useEffect } from "react";
import authorisedClient from "../../common/authorised-axios";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import Modal from "react-bootstrap/Modal";
import AddLocationModal from "../../components/AddLocationModal";

export const ModifyLocations = () => {

    const history = useHistory();

    const GoToAdminHome = () => {
        history.push('/adminhome');
    }

    const [show, setShow] = useState(false);
    const handleClose = () => { setShow(false); };
    const handleShow = () => { setShow(true); }

    const [locations, setLocations] = useState([]);
    const [noLocationsStored, setNoLocationsStored] = useState(false)

    const onDeleteLocation = async (locationId) => {
        var resp = await authorisedClient.delete(`Admin/location/${locationId}`);
        if (resp.status === 200) {
            window.location.reload();
            alert("Location was successfully deleted");
        }
    };

    const onAddLocation = async (locationDetails) => {
        // Handle adding location to the server here
        // ...
        var resp = await authorisedClient.post(
            "Admin/location",
            {
                Name: locationDetails.name,
                Address: locationDetails.address
            }
        );

        if (resp.status === 200 || resp.status === 201) {
            window.location.reload();
            alert("Location was successfully added");
        };

        // Close the modal after successfully adding the location
        setShow(false);
    }

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
                                <td><button onClick={() => onDeleteLocation(location.id)} type="button" className="btn btn-danger">Delete</button></td>
                            </tr>
                        ))}

                    </tbody>
                </table>

                <AddLocationModal
                    show={show}
                    handleClose={handleClose}
                    onAddLocation={onAddLocation}
                />
                <Button onClick={GoToAdminHome} type="button" className="btn btn-primary marginbottom mr-4">Back</Button>
                <Button onClick={handleShow} type="button" className="btn btn-primary marginbottom">Add a new Location</Button>


            </div>)}

        </div>
    );
}

export default ModifyLocations;