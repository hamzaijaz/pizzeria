import React from "react";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';

function Home() {

    const history = useHistory();

    //Navigate to new order page when start new order button is clicked
    const startNewOrder = () => {
        history.push('/neworder');
    }

  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col-10 offset-1 digitalcentre mt-5">
          <div>
            <h1>Welcome to Pizzeria</h1>
            <p>You can order your pizza here</p>
          </div>
        </div>
      </div>

      <div className="digitalcentre">
        <p>Click 'Start New Order' button to start ordering</p>

        <Button variant="primary" onClick={startNewOrder}>
        Start New Order
      </Button>
      </div>
    </div>
  );
}
export default Home;
