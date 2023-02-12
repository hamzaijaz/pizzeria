import React, { useState, useEffect } from "react";
import Modal from "react-bootstrap/Modal";
import Button from "react-bootstrap/Button";

export const AddLocationModal = ({
    show,
    handleClose
}) => {

    const [isLocationAdded, setIsLocationAdded] = useState(false);
    const submit = async (values) => {
        setIsLocationAdded(true);
    };

    return (
        <>
            <form onSubmit={submit}>
                <Modal className="mt-5"
                    show={show}
                    onHide={handleClose}
                    dialogClassName="modal-50w"
                    style={{ width: "100%", height: "500px" }}
                >
                    <Modal.Header>
                        <div className="flex flex-justify flex-fill">
                            <p className=""><b>Location name:</b></p>
                            <p className=""><b>Address:</b></p>

                            <Button
                                className="mb-sm-0 mb-3 btn btn-secondary"
                                type="button"
                                variant="secondary"
                                onClick={handleClose}
                            >
                                Close
                            </Button>

                            <Button onClick={submit}
                                className="ml-4 mb-sm-0 mb-3 btn btn-secondary"
                                variant="secondary"
                                type="submit"
                            >
                                Submit
                            </Button>

                            {isLocationAdded && (
                <>
                <p>Location successfully added</p>
                </>)}
                        </div>
                    </Modal.Header>
                </Modal>
            </form>

            {isLocationAdded && (
                <>
                <p>Location successfully added</p>
                </>)}
        </>

    );
};
export default AddLocationModal;
