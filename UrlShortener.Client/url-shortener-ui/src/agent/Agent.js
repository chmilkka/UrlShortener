import axios from "axios";
import { toast } from "react-toastify";
import { redirect } from "react-router-dom";
import { store } from "../stores/StoresManager";



axios.defaults.baseURL = "https://localhost:7182/api";

axios.interceptors.request.use((config) => {
    const token = store.commonStore.token;

    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
});

axios.interceptors.response.use(async (response) => {
    checkStatusCode(response)
   return response
},
    (error) => {
       return Promise.reject(error)
    }
);

const responseBody = (response) => response.data;

const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body = {}) => axios.post(url, body).then(responseBody),
    delete: (url) => axios.delete(url).then(responseBody),
};

const Auth = {
    login: (body) => requests.post("/user/login", body),
    register: (body) => requests.post("/user/register", body),
}

const Urls = {
    createShortUrl: (body) => requests.post("/urls/createUrl", body)
}

export const agent = {
    Auth,
    Urls
};

function checkStatusCode (error) {
    const {status} = error;
    switch (status) {
        case 400:
            const {data} = error;
            if (data.errors) {
                const modalStateErrors = [];

                for (const key in data.errors) {
                    if (data.errors[key]) {
                        toast.error((data.errors[key])[0]);
                        modalStateErrors.push(data.errors[key]);
                    }
                }
                throw modalStateErrors.flat();
            } else {
                toast.error(data.errors);
            }
            break;
        case 401:
            if (error.headers['www-authenticate'].startsWith('Bearer error="invalid_token"')) {
                store.userStore.logout();
                toast.error('Session has expired - please login again');
            }
            break;
        case 404:
            redirect("/notFound");
            break;
        case 500:
            error.data.errors.map(e => toast.error(e.detail));                
            break;
    }

    return Promise.resolve(error);
    
}