import React from "react";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';

export const ModifyMenu = () => {
    const history = useHistory();

    const GoToAdminHome = () => {
        history.push('/adminhome');
    }
    return (
        <div>
            <p>This is modify menu page</p>
            <Button onClick={GoToAdminHome} type="button" className="btn btn-primary marginbottom mr-4">Back</Button>
        </div>
    );
}

export default ModifyMenu;