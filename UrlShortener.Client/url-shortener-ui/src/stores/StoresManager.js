import { createContext, useContext } from "react";
import CommonStore from "./CommonStore";
import UserStore from "./UserStore";
import UrlStore from "./UrlStore";

export class Store  {
    commonStore = new CommonStore();
    userStore = new UserStore(); 
    urlStore = new UrlStore(); 
}

export const store = new Store();

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}