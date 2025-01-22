import { createContext, useContext } from "react";
import CommonStore from "./CommonStore";
import UserStore from "./UserStore";

export class Store  {
    commonStore = new CommonStore();
    userStore = new UserStore();  
}

export const store = new Store();

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}