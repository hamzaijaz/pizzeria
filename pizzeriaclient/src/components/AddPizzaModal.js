import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import { Modal, Form, Input, Checkbox } from 'antd';

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
    const [checkboxValues, setCheckboxValues] = useState([]);

    const handleCheckboxChange = (e) => {
        let checkedLocationId = Number(e.target.id);
        if (checkboxValues.includes(checkedLocationId)) {
            removeIdFormCheckedValues(checkedLocationId);
        }

        else {
            setCheckboxValues([...checkboxValues, checkedLocationId]);
        }
    };

    const removeIdFormCheckedValues = value => {
        setCheckboxValues(checkboxValues.filter(val => val !== value));
    };

    const handleSubmit = async () => {
        try {
            setLoading(true);
            const values = await form.validateFields();
            //await onAddPizza(values);
            setSuccess(true);
            setTimeout(() => {
                // Code to be executed after 3 seconds
            }, 3000);
            setLoading(false);
            //onAddPizza(values);
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
                        <Input />
                    </Form.Item>

                    {locations.map((item, index) => (
                        <Form.Item
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
                            <Checkbox
                                key={item.id}
                                defaultChecked={item.id === selectedLocation}
                                onChange={handleCheckboxChange}></Checkbox>
                        </Form.Item>
                    ))}


                    {/* <Form.Item name="options" rules={[{ required: true, message: 'Please select at least one option' }]}>
                        <Checkbox.Group options={locations} />
                      </Form.Item> */}

                    {/* <Checkbox.Group options={locations.map((item) => item.name)} render={(option) => (
                            <React.Fragment>
                                <Checkbox value={option.value}>{option.value}</Checkbox>
                                <div style={{ marginLeft: 8 }}>{option.name}</div>
                            </React.Fragment>
                        )}/> */}



                </Form>
                {success && (
                    <p style={{ color: 'green' }}>Pizza added successfully</p>
                )}
            </Modal>
        </>

    );
};
export default AddPizzaModal;
