import axios from "axios";

const apiPort = "7118"
const localApi = `https://localhost:${apiPort}/api`;
const externaApi = null;

const api = axios.create({
    baseURL : localApi
})

export default api