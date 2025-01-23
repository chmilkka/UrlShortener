import { makeAutoObservable } from "mobx";
import { store } from "./StoresManager";
import { agent } from "../agent/Agent";
import { jwtDecode } from "jwt-decode";

export default class UserStore {
    userId = null;
    token = null;

    constructor() {
        makeAutoObservable(this);
    }

    get isLoggedIn() {
        return !!this.token;
    }

     getUserIdFromJwt(token) {
        const decoded = jwtDecode(token);
        console.log(decoded);
        this.userId = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        console.log(this.userId);
        return this.userId;
    }

    loadUserFromToken() {
        const token = window.localStorage.getItem("jwt");
        if (!token) {
            return;
        }
        try {
            this.token = token;
            this.userId = this.getUserIdFromJwt(token);
        } catch (error) {
            console.error("Error loading user from token:", error);
            this.logout();
        }
    }

    login = async (creds) => {
        const response = await agent.Auth.login(creds);
        console.log("login successful, token - " + response);
        store.commonStore.setToken(response);
        this.token = response;
        this.userId = this.getUserIdFromJwt(response);
        return response.isSuccessful;
    };

    logout = () => {
        store.commonStore.setToken(null);
        window.localStorage.removeItem("jwt");
        this.token = null;
        this.userId = null;
    };

    register = async (creds) => 
        await agent.Auth.register(creds);

}