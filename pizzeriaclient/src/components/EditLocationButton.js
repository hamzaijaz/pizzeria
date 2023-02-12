import React, { useState } from "react";
import EditLocationModal from "./EditLocationModal";
import Button from "react-bootstrap/Button";

export const EditLocationButton = ({
    id,
    name,
    address,
    onEditLocation
}) => {
    const [show, setShow] = useState(false);
    const handleClose = () => { setShow(false); };
    const handleShow = (locId, locName, locAddress) => { setShow(true); }

    return (
        <>
            <EditLocationModal
                show={show}
                handleClose={handleClose}
                onEditLocation={onEditLocation}
                id={id}
                name={name}
                address={address}
            />

            <Button onClick={() => handleShow(id, name, address)} type="button" className="btn btn-primary">Edit</Button>
        </>
    );
};
export default EditLocationButton;
