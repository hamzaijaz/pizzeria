import React, { useState, useEffect } from "react";
import authorisedClient from "../../common/authorised-axios";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import Modal from "react-bootstrap/Modal";
import AddLocationModal from "../../components/AddLocationModal";
import EditLocationModal from "../../components/EditLocationModal";

export const ModifyLocations = () => {

    const history = useHistory();

    const GoToAdminHome = () => {
        history.push('/adminhome');
    }

    const [showAddLocationModal, setShowAddLocationModal] = useState(false);
    const handleCloseAddLocationModal = () => { setShowAddLocationModal(false); };
    const handleShowAddLocationModal = () => { setShowAddLocationModal(true); }

    const [locationIdToEdit, setLocationIdToEdit] = useState(0);
    const [locationNameToEdit, setLocationNameToEdit] = useState("");
    const [locationAddressToEdit, setLocationAddressToEdit] = useState("");
    const [showEditLocationModal, setShowEditLocationModal] = useState(false);
    
    const handleCloseEditLocationModal = () => { 
        setLocationIdToEdit(0);
        setLocationNameToEdit("");
        setLocationAddressToEdit("");
        setShowEditLocationModal(false); 
    };
    const handleShowEditLocationModal = (locationId, locationName, locationAddress) => { 
        setLocationIdToEdit(locationId);
        setLocationNameToEdit(locationName);
        setLocationAddressToEdit(locationAddress);
        setShowEditLocationModal(true); 
    }

    const [locations, setLocations] = useState([]);
    const [noLocationsStored, setNoLocationsStored] = useState(false);

    const onEditLocation = async (locationId) => {

    };

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
        setShowAddLocationModal(false);
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
                                <td><Button onClick={() => handleShowEditLocationModal(location.id, location.name, location.address)} type="button" className="btn btn-primary">Edit</Button></td>
                                <td><Button onClick={() => onDeleteLocation(location.id)} type="button" className="btn btn-danger">Delete</Button></td>
                            </tr>
                        ))}

                    </tbody>
                </table>

                <AddLocationModal
                    show={showAddLocationModal}
                    handleClose={handleCloseAddLocationModal}
                    onAddLocation={onAddLocation}
                />

                <EditLocationModal
                    show={showEditLocationModal}
                    handleClose={handleCloseEditLocationModal}
                    onEditLocation={onEditLocation}
                    locationId={locationIdToEdit}
                    locationName={locationNameToEdit}
                    locationAddress={locationAddressToEdit}
                />
                <Button onClick={GoToAdminHome} type="button" className="btn btn-primary marginbottom mr-4">Back</Button>
                <Button onClick={handleShowAddLocationModal} type="button" className="btn btn-primary marginbottom">Add a new Location</Button>


            </div>)}

        </div>
    );
}

export default ModifyLocations;