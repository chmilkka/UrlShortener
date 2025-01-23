import { makeAutoObservable } from "mobx";
import { agent } from "../agent/Agent";

export default class UrlStore {
    url = null
    client = agent.Urls

    constructor() {
        makeAutoObservable(this);
    }

    createShortUrl = async (url) =>
                await agent.Urls.createShortUrl(url);


    getProductsByType = async (type) => {
        const response = await this.client.getProductsByType(type);
        return response;
    }

    removeProduct = async (id, type) => {
        await this.client.removeProduct(id);
        await this.client.getProductsByType(type); 
    }

    addProductToCart = async (product) => {
        this.cartProducts.push(product);
    }

    removeProductFromCart = async (name) => {
        this.cartProducts = this.cartProducts.filter(x => x.name !== name)
    }

}