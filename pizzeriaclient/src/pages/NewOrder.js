import React, { useState, useEffect } from "react";
import authorisedClient from "../common/authorised-axios";
import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import { RotatingLines } from 'react-loader-spinner';

export const NewOrder = () => {
  const history = useHistory();

  const cancelOrder = () => {
    history.push('/');
  }
  const [isLoading, setIsLoading] = useState(true);
  const [locations, setLocations] = useState([]);
  const [noLocationsStored, setNoLocationsStored] = useState(false);
  const [currentLocationHasPizzas, setcurrentLocationHasPizzas] = useState(false);

  const [selectedLocation, setSelectedLocation] = useState(0);
  const [showPizzas, setShowItem] = useState(false);

  const [pizzasWithCount, setPizzasWithCount] = useState([]);

  const [totalCost, setTotalCost] = useState(0);

  //Fetch all locations from server when this page is loaded first time
  useEffect(() => {
    async function getAllLocations() {
      setIsLoading(true);
      let response = await authorisedClient.get(
        `Admin/location/all`
      );
      setIsLoading(false);

      if (response.data.length === 0) {
        setNoLocationsStored(true)
      }

      setLocations(response.data);
    }
    getAllLocations();
  }, []);

  const handleLocationChange = async (e) => {
    setSelectedLocation(e.target.value);

    if (e.target.value === "0") {
      setShowItem(false);
    }

    else {
      setShowItem(true);
      setIsLoading(true);
      //get all pizzas available at this location
      let response = await authorisedClient.get(
        `Pizza/pizzasforlocation/${e.target.value}`
      );

      setIsLoading(false);

      if (response.data.length > 0) {
        setcurrentLocationHasPizzas(true);
      }

      var pizzasWithCountTemp = response.data.map(pizza => ({
        ...pizza,
        count: 0
      }));

      setPizzasWithCount(pizzasWithCountTemp);
    }
  };

  //when plus button is clicked, increase count of that pizza and update total cost of order
  const handlePlus = (index) => {
    var newPizzaCount = [...pizzasWithCount];
    newPizzaCount[index].count++;
    setPizzasWithCount(newPizzaCount);
    calculateTotalCost();
  };

  //when minus button is clicked, decrease count of that pizza and update total cost of order
  const handleMinus = (index) => {
    if (pizzasWithCount[index].count > 0) {
      var newPizzaCount = [...pizzasWithCount];
      newPizzaCount[index].count--;
      setPizzasWithCount(newPizzaCount);
      calculateTotalCost();
    }
  };

  //this method calculates total cost of the order, depending on pizza prices and their counts
  const calculateTotalCost = () => {
    var cost = pizzasWithCount.reduce((acc, p) => acc + (p.price * p.count), 0);
    setTotalCost(cost);
  }

  return (
    <div className="pt-5">
      {noLocationsStored && (
        <>
          <div className="alert alert-danger" role="alert">
            <p>There are no branches of Pizzeria restaurant in any area. Please come back later.</p>
            <p>If the admin adds any new locations, you can come back and see the updated locations</p>
          </div>
          <Button className="mb-2" variant="primary" onClick={cancelOrder}>
            Back to home page
          </Button>
        </>
      )}

      {isLoading && (<RotatingLines
        visible={true}
        height="408"
        width="96"
        color="grey"
        strokeWidth="5"
        animationDuration="0.75"
        ariaLabel="rotating-lines-loading"
        wrapperStyle={{}}
        wrapperClass=""
      />)}

      {locations !== null && locations.length > 0 && (
        <div>
          <form>
            <p>Please select location from where you want to order your pizza</p>
            <fieldset>
              <label>
                Location:
                <select className="ml-2 stylish-dropdown" value={selectedLocation} name="location" id="location" onChange={handleLocationChange} required>
                  <option value={0}>Please select a location</option>
                  {locations.map(item => (
                    <option key={item.id} value={item.id}>{item.name}</option>
                  ))}
                </select>
              </label>

              {showPizzas && currentLocationHasPizzas && (
                <div>
                  <p className="mt-2">Following pizzas are available in your selected branch. Please select your pizzas</p>

                  <table className="table">
                    <thead>
                      <tr>
                        <th scope="col">Pizza Name</th>
                        <th className="text-left" scope="col">Pizza Description</th>
                        <th scope="col">$ Price each</th>
                        <th scope="col"></th>
                      </tr>
                    </thead>
                    <tbody>
                      {pizzasWithCount.map((pizza, index) => (
                        <tr key={pizza.id}>
                          <td>{pizza.name}</td>
                          <td className="text-left col-3"><i>{pizza.description}</i></td>
                          <td>${pizza.price}</td>
                          <td><Button className="ml-2 mr-2 pl-3 pr-3" onClick={() => handleMinus(index)}>-</Button>
                            <span>{pizza.count}</span>
                            <Button className="ml-2 mr-2 pl-3 pr-3" onClick={() => handlePlus(index)}>+</Button></td>
                        </tr>
                      ))}

                    </tbody>
                  </table>

                  <label>Total price of your order is:</label>
                  <span className="ml-2">${totalCost}</span>
                </div>
              )}

              {showPizzas && !currentLocationHasPizzas && !isLoading && (
                <>
                  <p className="alert alert-danger" role="alert">There are no pizzas available in your selected location.</p>
                </>)}
            </fieldset>
          </form>

          <div>
            <Button className="mb-2" variant="primary" onClick={cancelOrder}>
              Cancel Order
            </Button>
          </div>
        </div>)}
    </div>);
}

export default NewOrder;