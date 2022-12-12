import { makeAutoObservable } from "mobx";
import agent from '../api/agent';
import { Category } from "../models/category";
//import { store } from "./store";

export default class CategoryStore {
    categories: Category[] = [];
    category: Category | undefined = undefined;
    loadingCategory = false;
    loading = false;

    constructor() {
        makeAutoObservable(this);

        this.loadCategories();
    }

    loadCategory = async (categoryId: string) => {
        this.setLoadingCategory(true);
        try {
            const category = this.categories.find(x => x.id === categoryId) || new Category;
            this.setCategory(category);
            this.setLoadingCategory(false);
        } catch (error) {
            console.log(error);
            this.setLoadingCategory(false);
        }
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

    setCategory = (category: Category) => {
        this.category = category;
    }

    setLoading = (loading: boolean) => {
        this.loading = loading;
    }

    setLoadingCategory = (loading: boolean) => {
        this.loadingCategory = loading;
    }
}