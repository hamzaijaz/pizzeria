import axios from "axios";

const AuthorisedClient = () => {
  const defaultOptions = {
    baseURL: "https://localhost:7213/api",
    method: 'get',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, PATCH, PUT, DELETE, OPTIONS',
      'Access-Control-Allow-Headers':
        'Origin, Content-Type, X-Auth-Token, X-Requested-With, Accept, Authorization'
    }
  };

  // Create instance
  let instance = axios.create(defaultOptions);

  return instance;
};

export default AuthorisedClient();
