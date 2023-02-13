import Button from "react-bootstrap/Button";
import { useHistory } from 'react-router-dom';
import React, { useState, useEffect } from "react";
import AddPizzaModal from "../../components/AddPizzaModal";
import authorisedClient from "../../common/authorised-axios";
import EditPizzaModal from "../../components/EditPizzaModal";
import EditPizzaButton from "../../components/EditPizzaButton";

export const ModifyMenu = () => {
    const [locations, setLocations] = useState([]);
    const [noLocationsStored, setNoLocationsStored] = useState(false);
    const history = useHistory();
    const GoToAdminHome = () => {
        history.push('/adminhome');
    };

    const [showAddPizzaModal, setShowAddPizzaModal] = useState(false);
    const handleCloseAddPizzaModal = () => { setShowAddPizzaModal(false); };
    const handleShowAddPizzaModal = () => { setShowAddPizzaModal(true); }

    const [selectedLocation, setSelectedLocation] = useState(0);
    const [showPizzas, setShowItem] = useState(false);
    const [pizzas, setPizzas] = useState([]);
    const [currentLocationHasPizzas, setcurrentLocationHasPizzas] = useState(false);

    const onAddPizza = async (pizzaDetails) => {
        // Handle adding pizza to the server here
        // ...
        var resp = await authorisedClient.post(
            "Admin/pizza",
            {
                Name: pizzaDetails.name,
                Description: pizzaDetails.description,
                Price: pizzaDetails.price,
                locationIds: pizzaDetails.locationIds
            }
        );

        if (resp.status === 200 || resp.status === 201) {
            window.location.reload();
            alert("Pizza was successfully added");
        };

        // Close the modal after successfully adding the pizza
        setShowAddPizzaModal(false);
    };

    const onDeletePizza = async (pizzaId) => {
        let selectedLocationId = Number(selectedLocation);
        var resp = await authorisedClient.delete(`Admin/pizza/${pizzaId}/location/${selectedLocationId}`);

        if (resp.status === 200) {
            window.location.reload();
            alert("Pizza was successfully deleted");
        }
    };

    const onEditPizza = async (pizzaId, newPizzaName, newPizzaDescription, newPizzaPrice, locationId) => {
        // Handle adding location to the server here
        // ...
        var resp = await authorisedClient.put(
            "Admin/pizza",
            {
                Id: pizzaId,
                Name: newPizzaName,
                Description: newPizzaDescription,
                Price: newPizzaPrice,
                LocationId: locationId
            }
        );

        if (resp.status === 200 || resp.status === 201) {
            window.location.reload();
            setShowAddPizzaModal(false);
            alert("Pizza was successfully updated");
        };

        // Close the modal after successfully adding the location
        setShowAddPizzaModal(false);
    };

    useEffect(() => {
        async function getAllLocations() {
            let response = await authorisedClient.get(
                `Admin/location/all`
            );

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
            let response = await authorisedClient.get(
                `Pizza/pizzasforlocation/${e.target.value}`
            );

            if (response.data.length > 0) {
                setcurrentLocationHasPizzas(true);
            }

            setPizzas(response.data);
        }
    };

    return (
        <div>
            <p>This is modify menu page</p>
            <p>You can add new pizzas here</p>

            {noLocationsStored && (<>
                <p className="alert alert-danger" role="alert">Currently there are no active locations of Pizzeria. Please add a new location before adding a new pizza</p>
            </>)}

            {!noLocationsStored && (<>
            <form>
                <fieldset>
                    <label>
                        Location:
                        <select className="ml-2 stylish-dropdown" value={selectedLocation} name="location" id="location" onChange={handleLocationChange} required>
                            <option value={0}>Please select a location</option>
                            {locations.map(item => (
                                <option key={item.id} value={item.id}>Id: {item.id}. Name: {item.name}</option>
                            ))}
                        </select>
                    </label>

                    {/* {showPizzas && currentLocationHasPizzas && (
                <div>
                  <p className="mt-2">Following pizzas are available in your selected branch. Please select your pizzas</p>
                  <ul className="nobullets">
                    {pizzasWithCount.map((pizza, index) => (
                      <li className="mt-4" key={pizza.id}>{pizza.name} : ${pizza.price} each
                        <Button className="ml-2 mr-2" onClick={() => handleMinus(index)}>-</Button>
                        <span>{pizza.count}</span>
                        <Button className="ml-2 mr-2" onClick={() => handlePlus(index)}>+</Button></li>
                    ))}
                  </ul>

                  <label>Total price of your order is:</label>
                  <span className="ml-2">{totalCost}</span>
                </div>
              )} */}

                    {/* {showPizzas && !currentLocationHasPizzas && (
                <>
                  <p className="alert alert-danger" role="alert">There are no pizzas available in your selected location.</p>
                </>)} */}
                </fieldset>
            </form>

            <table className="table">
                    <thead>
                        <tr>
                            <th scope="col">Pizza Name</th>
                            <th className="text-left" scope="col">Pizza Description</th>
                            <th scope="col">Price</th>
                            <th scope="col"></th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        {pizzas.map((pizza, index) => (
                            <tr key={pizza.id}>
                                <td>{pizza.name}</td>
                                <td className="text-left col-3">{pizza.description}</td>
                                <td>${pizza.price}</td>
                                <td><EditPizzaButton name={pizza.name} id={pizza.id} description={pizza.description} onEditPizza={onEditPizza} price={pizza.price} currentLocationId={Number(selectedLocation)} type="button" className="btn btn-primary">Edit</EditPizzaButton></td>
                                <td><Button onClick={() => onDeletePizza(pizza.id)} type="button" className="btn btn-danger">Delete</Button></td>
                                {/* <td><EditLocationButton name={location.name} id={location.id} address={location.address} onEditLocation={onEditLocation} type="button" className="btn btn-primary">Edit</EditLocationButton></td>
                                <td><Button onClick={() => onDeleteLocation(location.id)} type="button" className="btn btn-danger">Delete</Button></td> */}
                            </tr>
                        ))}

                    </tbody>
                </table>

            <AddPizzaModal
                show={showAddPizzaModal}
                handleClose={handleCloseAddPizzaModal}
                onAddPizza={onAddPizza}
                locations={locations}
                selectedLocation={Number(selectedLocation)}
            />
            </>)}
            <Button onClick={GoToAdminHome} type="button" className="btn btn-primary marginbottom mr-4">Back</Button>
            {!noLocationsStored && (
            <Button onClick={handleShowAddPizzaModal} type="button" className="btn btn-primary marginbottom">Add a new Pizza</Button>
            )}
        </div>
    );
}

export default ModifyMenu;