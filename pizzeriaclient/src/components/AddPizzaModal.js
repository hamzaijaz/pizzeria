import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import { Modal, Form, Input, Checkbox, Col, Row } from 'antd';

export const AddPizzaModal = ({
    show,
    handleClose,
    onAddPizza,
    locations,
    selectedLocation
}) => {

    const [form] = Form.useForm();
    const [loading, setLoading] = useState(false);
    const [success, setSuccess] = useState(false);
    //an array to keep record of locations selected to add new pizza
    const [checkboxValues, setCheckboxValues] = useState([]);

    //When value of a checkbox changes, add or remove relevant location id from the array "checkboxValues"
    const handleCheckboxChange = (e) => {
        let checkedLocationId = Number(e.target.id);

        //if locationId is already in the array, remove it. Otherwise add it to the array
        if (checkboxValues.includes(checkedLocationId)) {
            removeIdFormCheckedValues(checkedLocationId);
        }

        //Add LocationID to array "checkboxValues"
        else {
            setCheckboxValues([...checkboxValues, checkedLocationId]);
        }
    };

    //remove LocationId from "checkboxValues" array
    const removeIdFormCheckedValues = value => {
        setCheckboxValues(checkboxValues.filter(val => val !== value));
    };

    const handleSubmit = async () => {
        try {
            setLoading(true);
            const values = await form.validateFields();

            //Atleast one location should be selected to add the pizza
            if (checkboxValues.length === 0) {
                alert("Please select atleeast one location in order to add pizza");
            }

            else {
                var details = { name: values.name, description: values.description, price: values.price, locationIds: checkboxValues };
                await onAddPizza(details);
                setSuccess(true);
                setTimeout(() => {
                    // Code to be executed after 3 seconds
                }, 3000);
                setLoading(false);
            }
        } catch (err) {
            console.error(err);
            setLoading(false);
        }
    };

    return (
        <>
            <Modal
                open={show}
                title="Add New Pizza"
                onCancel={handleClose}
                centered
                footer={[
                    <Button key="back" onClick={handleClose}>
                        Cancel
                    </Button>,
                    <Button
                        className="ml-4"
                        key="submit"
                        type="primary"
                        loading={loading}
                        onClick={handleSubmit}
                    >
                        Submit
                    </Button>,
                ]}
            >
                <Form form={form}>
                    <Form.Item
                        name="name"
                        label="Pizza Name"
                        rules={[
                            {
                                required: true,
                                message: 'Please enter pizza name',
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="description"
                        label="Pizza Description"
                        rules={[
                            {
                                required: true,
                                message: 'Please enter pizza description',
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="price"
                        label="Price"
                        rules={[
                            {
                                required: true,
                                message: 'Please enter pizza price',
                            },
                        ]}
                    >
                        <Input type="number" />
                    </Form.Item>

                    <div className="mb-3">Please select locations in which you want to make this pizza available:</div>

                        {locations.map((item, index) => (
                            <Form.Item
                            className="m-2"
                                name={item.id}
                                label={item.name}
                                valuePropName="checked"
                                rules={[
                                    {
                                        required: false,
                                        message: 'Please enter pizza price',
                                    },
                                ]}
                            >
                                    <Checkbox className="mr-3"
                                        key={item.id}
                                        // defaultChecked={item.id === selectedLocation}
                                        onChange={handleCheckboxChange}></Checkbox>
                            </Form.Item>
                        ))}
                </Form>
                {success && (
                    <p style={{ color: 'green' }}>Pizza added successfully</p>
                )}
            </Modal>
        </>
    );
};
export default AddPizzaModal;
