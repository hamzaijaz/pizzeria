import React, { useState, useEffect } from "react";
import authorisedClient from "../common/authorised-axios";

export const NewOrder = () => {
  const [locations, setLocations] = useState([]);
  const [noLocationsStored, setNoLocationsStored] = useState(false)

  const [selectedLocation, setSelectedLocation] = useState(0);
  const [showPizzas, setShowItem] = useState(false);

  const [pizzasForLocation, setPizzasForLocation] = useState([]);

  const handleLocationChange = async (e) => {
    setSelectedLocation(e.target.value);

    if(e.target.value === "0")
    {
      setShowItem(false);
    }

    else
    {
      setShowItem(true);
      let response = await authorisedClient.get(
        `Pizza/pizzasforlocation/${e.target.value}`
      );
      setPizzasForLocation(response);
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



  return (
    <div>
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
                <ul>
                  {pizzasForLocation.data.map(pizza => (
                    <li key={pizza.id}>{pizza.name}</li>
                  ))}
                </ul>
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