import React from "react";

function Home() {
  return (
    <div className="container-fluid myheader">
      <div className="row">
        <div className="jumbotron col-10 offset-1 digitalcentre">
          <div className="custom-background">
            <h1>Welcome to Pizzeria</h1>
            <p>You can order your pizza here</p>
          </div>
        </div>
      </div>

      <div className="mydiv">
        <p>Click 'Start New Order' button to start ordering</p>
      </div>
    </div>
  );
}
export default Home;
