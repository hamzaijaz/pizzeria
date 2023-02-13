import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import EditPizzaModal from "./EditPizzaModal";

export const EditPizzaButton = ({
    id,
    name,
    description,
    price,
    currentLocationId,
    onEditPizza
}) => {
    const [show, setShow] = useState(false);
    const handleClose = () => { setShow(false); };
    const handleShow = (locId, locName, locAddress) => { setShow(true); }

    return (
        <>
            <EditPizzaModal
                show={show}
                handleClose={handleClose}
                onEditPizza={onEditPizza}
                id={id}
                name={name}
                description={description}
                price={price}
                currentLocationId={currentLocationId}
            />

            <Button onClick={() => handleShow(id, name, description)} type="button" className="btn btn-primary">Edit</Button>
        </>
    );
};
export default EditPizzaButton;
