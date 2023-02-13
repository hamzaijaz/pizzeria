import React, { useState, useEffect } from "react";
import authorisedClient from "../../common/authorised-axios";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import AddLocationModal from "../../components/AddLocationModal";
import EditLocationModal from "../../components/EditLocationModal";
import EditLocationButton from "../../components/EditLocationButton";

export const ModifyLocations = () => {

    const history = useHistory();

    //navigate to admin home page when back button is clicked
    const GoToAdminHome = () => {
        history.push('/adminhome');
    }

    const [showAddLocationModal, setShowAddLocationModal] = useState(false);
    const handleCloseAddLocationModal = () => { setShowAddLocationModal(false); };
    const handleShowAddLocationModal = () => { setShowAddLocationModal(true); }


    const [initialValues, setInitialValues] = useState({ id: 0, name: "", address: "" });
    const [showEditLocationModal, setShowEditLocationModal] = useState(false);

    const handleCloseEditLocationModal = () => {
        setShowEditLocationModal(false);
    };

    const [locations, setLocations] = useState([]);
    const [noLocationsStored, setNoLocationsStored] = useState(false);

    const onEditLocation = async (locationId, newLocationName, newLocationAddress) => {
        //calling PUT Location API
        var resp = await authorisedClient.put(
            "Admin/location",
            {
                Id: locationId,
                Name: newLocationName,
                Address: newLocationAddress
            }
        );

        if (resp.status === 200 || resp.status === 201) {
            window.location.reload();
            setShowAddLocationModal(false);
            alert("Location was successfully updated");
        };

        // Close the modal after successfully adding the location
        setShowAddLocationModal(false);
    };

    const onDeleteLocation = async (locationId) => {
        //Calling DELETE Location API
        var resp = await authorisedClient.delete(`Admin/location/${locationId}`);
        if (resp.status === 200) {
            window.location.reload();
            alert("Location was successfully deleted");
        }
    };

    const onAddLocation = async (locationDetails) => {
        //Calling POST Location API
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

    //Fetch all locations from server when this page is loaded first time
    useEffect(() => {
        async function getAllLocations() {
            //Calling GET AllLocations API
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
            <p className="pt-3">This is Modify Locations page</p>

            {noLocationsStored && (<>
                <p className="alert alert-danger" role="alert">Currently there are no active locations of Pizzeria. Please add new location to see any active locations</p>
                <AddLocationModal
                    show={showAddLocationModal}
                    handleClose={handleCloseAddLocationModal}
                    onAddLocation={onAddLocation}
                />
                <Button onClick={GoToAdminHome} type="button" className="btn btn-primary marginbottom mr-4">Back</Button>
                <Button onClick={handleShowAddLocationModal} type="button" className="btn btn-primary marginbottom">Add a new Location</Button>
            </>)}

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
                                <td><EditLocationButton name={location.name} id={location.id} address={location.address} onEditLocation={onEditLocation} type="button" className="btn btn-primary">Edit</EditLocationButton></td>
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
                    id={initialValues.id}
                    name={initialValues.name}
                    address={initialValues.address}
                />
                <Button onClick={GoToAdminHome} type="button" className="btn btn-primary marginbottom mr-4">Back</Button>
                <Button onClick={handleShowAddLocationModal} type="button" className="btn btn-primary marginbottom">Add a new Location</Button>
            </div>)}
        </div>
    );
}

export default ModifyLocations;