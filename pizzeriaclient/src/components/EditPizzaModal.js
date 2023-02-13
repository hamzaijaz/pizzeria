import React, { useState, useEffect } from "react";
import Button from "react-bootstrap/Button";
import { Modal, Form, Input } from 'antd';

export const EditPizzaModal = ({
    show,
    handleClose,
    onEditPizza,
    id,
    name,
    description,
    price,
    currentLocationId
}) => {

    const [form] = Form.useForm();
    const [loading, setLoading] = useState(false);
    const [success, setSuccess] = useState(false);

    const [formValues, setValues] = useState({ id: id, name: name, description: description, price: price });

    useEffect(() => {
        form.setFieldsValue({
            pizzaName: name,
            pizzaDescription: description,
            pizzaPrice: price
        });
    }, [form, name, description]);

    const handleSubmit = async () => {
        try {
            setLoading(true);
            const values = await form.validateFields();
            await onEditPizza(formValues.id, values.pizzaName, values.pizzaDescription, values.pizzaPrice, currentLocationId);
            setSuccess(true);
            setTimeout(() => {
                // Code to be executed after 3 seconds
            }, 3000);
            setLoading(false);
        }
        catch (err) {
            console.error(err);
            setLoading(false);
        }
    };

    return (
        <>
            <Modal
                open={show}
                title="Edit Pizza"
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
                        name="pizzaName"
                        label="Name"
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
                        name="pizzaDescription"
                        label="Description"
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
                        name="pizzaPrice"
                        label="Price $"
                        rules={[
                            {
                                required: true,
                                message: 'Please enter pizza price',
                            },
                        ]}
                    >
                        <Input type="number" />
                    </Form.Item>
                </Form>
                {success && (
                    <p style={{ color: 'green' }}>Pizza updated successfully</p>
                )}
            </Modal>
        </>

    );
};
export default EditPizzaModal;
