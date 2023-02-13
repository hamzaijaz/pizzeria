import React, { useState, useEffect } from "react";
import Button from "react-bootstrap/Button";
import { Modal, Form, Input } from 'antd';

export const EditLocationModal = ({
    show,
    handleClose,
    onEditLocation,
    id,
    name,
    address
}) => {

    const [form] = Form.useForm();
    const [loading, setLoading] = useState(false);
    const [success, setSuccess] = useState(false);

    const [formValues, setValues] = useState({ id: id, name: name, address: address });

    useEffect(() => {
        form.setFieldsValue({
            locationName: name,
            locationAddress: address,
        });
    }, [form, name, address]);

    const handleSubmit = async () => {
        try {
            setLoading(true);
            const values = await form.validateFields();
            await onEditLocation(formValues.id, values.locationName, values.locationAddress);
            setSuccess(true);
            setTimeout(() => {
                // Code to be executed after 3 seconds
            }, 3000);
            setLoading(false);
        } catch (err) {
            console.error(err);
            setLoading(false);
        }
    };

    return (
        <>
            <Modal
                open={show}
                title="Edit Location"
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
                        name="locationName"
                        label="Location Name"
                        rules={[
                            {
                                required: true,
                                message: 'Please enter location name',
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="locationAddress"
                        label="Location Address"
                        rules={[
                            {
                                required: true,
                                message: 'Please enter location address',
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                </Form>
                {success && (
                    <p style={{ color: 'green' }}>Location added successfully</p>
                )}
            </Modal>
        </>
    );
};
export default EditLocationModal;
