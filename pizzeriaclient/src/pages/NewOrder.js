import React, { useState, useEffect } from "react";
import authorisedClient from "../common/authorised-axios";
import Button from "react-bootstrap/Button";

export const NewOrder = () => {
  const [locations, setLocations] = useState([]);
  const [noLocationsStored, setNoLocationsStored] = useState(false)

  const [selectedLocation, setSelectedLocation] = useState(0);
  const [showPizzas, setShowItem] = useState(false);

  const [pizzasForLocation, setPizzasForLocation] = useState([]);
  const [pizzasWithCount, setPizzasWithCount] = useState([]);

  const handleLocationChange = async (e) => {
    setSelectedLocation(e.target.value);

    if (e.target.value === "0") {
      setShowItem(false);
    }

    else {
      setShowItem(true);
      let response = await authorisedClient.get(
        `Pizza/pizzasforlocation/${e.target.value}`
      );

      var pizzasWithCountTemp = response.data.map(pizza => ({
        ...pizza,
        count: 0
      }));

      setPizzasWithCount(pizzasWithCountTemp);
      setPizzasForLocation(response.data);
    }
  };

  useEffect(() => {
    async function getAllLocations() {
      let response = await authorisedClient.get(
        `Admin/location/all`
      );
      setLocations(response);

      if (response.data.length === 0) {
        setNoLocationsStored(true)
      }
    }
    getAllLocations();
  }, []);

  const handlePlus = (index) => {
    var newPizzaCount = [...pizzasWithCount];
    newPizzaCount[index].count++;
    setPizzasWithCount(newPizzaCount);
  };

  const handleMinus = (index) => {
    if (pizzasWithCount[index].count > 0) {
      var newPizzaCount = [...pizzasWithCount];
      newPizzaCount[index].count--;
      setPizzasWithCount(newPizzaCount);
    }
  };



  return (
    <div>
      {noLocationsStored && (
        <div className="alert alert-danger" role="alert">
          There are no branches of Pizzeria restaurant in any area. Please come back later.
        </div>
      )}
      {locations.data && (
        <div>
          <form>
            <fieldset>
              <label>
                Location:
                <select value={selectedLocation} name="location" id="location" onChange={handleLocationChange} required>
                  <option value={0}>Please select a location</option>
                  {locations.data.map(item => (
                    <option key={item.id} value={item.id}>{item.name}</option>
                  ))}
                </select>
              </label>

              {showPizzas && (
                <div>
                  <p>Following pizzas are available in your selected branch. Please select your pizzas</p>
                  <ul>
                    {pizzasWithCount.map((pizza, index) => (
                      <li className="mt-4" key={pizza.id}>{pizza.name} : ${pizza.price}
                        <Button className="ml-2 mr-2" onClick={() => handleMinus(index)}>-</Button>
                        <span>{pizza.count}</span>
                        <Button className="ml-2 mr-2" onClick={() => handlePlus(index)}>+</Button></li>
                    ))}
                  </ul>
                </div>
              )}


            </fieldset>
          </form>


          {/* <select>
            <option >Please select a location</option>
            {locations.data.map(item => (
              <option value={item.name}>{item.name}</option>
            ))}
          </select>

          {locations.data[0].name}
          {locations.data[0].address}
          {locations.data[0].id} */}
        </div>)}
    </div>);
}

export default NewOrder;