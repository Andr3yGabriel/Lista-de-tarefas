import Axios from 'axios';

const createAxios = Axios.create({
    baseURL: "http://localhost:5171"
});

export default createAxios;