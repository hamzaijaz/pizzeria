import React, { useState } from "react";
import Button from "react-bootstrap/Button";
import { Modal, Form, Input } from 'antd';

export const AddLocationModal = ({
    show,
    handleClose,
    onAddLocation
}) => {

    const [form] = Form.useForm();
    const [loading, setLoading] = useState(false);
    const [success, setSuccess] = useState(false);

    const handleSubmit = async () => {
        try {
            setLoading(true);
            const values = await form.validateFields();
            await onAddLocation(values);
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
                title="Add New Location"
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
                        name="address"
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
export default AddLocationModal;
