import axios from 'axios';

export const apiClient = axios.create({
  baseURL: 'https://localhost:7109/api',
  headers: {
    'Content-Type': 'application/json',
  },
  timeout: 5000,
});

/*apiClient.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem("token");

        if(token && config.headers){
            config.headers.Authorization = `Bearer ${token}`
        }

        return config;
    },
    (error) => {
        return Promise.reject(error)
    }
)*/
