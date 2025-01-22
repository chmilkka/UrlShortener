import { makeAutoObservable } from "mobx";
import { store } from "./StoresManager";
import { agent } from "../agent/Agent";

export default class UserStore {
    user = null;
    token = null;

    constructor() {
        makeAutoObservable(this);
    }

    get isLoggedIn() {
        return !!this.token;
    }

    login = async (creds) => {
        const response = await agent.Auth.login(creds);
        console.log("login successful, token - " + response);
        store.commonStore.setToken(response);
        this.token = response;
        return response.isSuccessful;
    };

    logout = () => {
        store.commonStore.setToken(null);
        window.localStorage.removeItem("jwt");
        this.token = null;
    };

    register = async (creds) => 
        await agent.Auth.register(creds);

}