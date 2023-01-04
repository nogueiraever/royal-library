import axios from 'axios'

const instance = axios.create({
    //This should come from environment variables
    baseURL: "https://localhost:7000",
    headers: {
        "Content-Type": "application/json",
    }
})
instance.interceptors.response.use(function (response) {
    return response.data;
}, function (error) {
    return Promise.reject(error);
});
export default instance