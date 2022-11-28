import { makeAutoObservable } from "mobx";
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
        this.setLoading(true);
        try {
            const result = await agent.Categories.all();
            this.setCategories(result.data.categories);
            this.setLoading(false);
        } catch (error) {
            console.log(error);
            this.setLoading(false);
        }
    }

    setCategories = (categories: Category[]) => {
        this.categories = categories;
    }

    setLoading = (loading: boolean) => {
        this.loading = loading;
    }
}