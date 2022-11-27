import { makeAutoObservable, reaction, runInAction } from "mobx";
import agent from '../api/agent';
import { Category } from "../models/category";
//import { store } from "./store";

export default class CategoryStore {
    categories: Category[] = [];
    selectedCategory: Category | undefined = undefined;
    loading = false;

    constructor() {
        makeAutoObservable(this);

        this.loadCategories();
    }

    loadCategories = async () => {
        this.loading = true;
        try {
            const result = await agent.Categories.all();
            this.categories = result.data.categories;
            this.loading = false;
        } catch (error) {
            console.log(error);
            this.loading = false;
        }
    }
}