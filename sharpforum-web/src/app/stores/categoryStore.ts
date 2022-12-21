import { makeAutoObservable, runInAction } from "mobx";
import agent from '../api/agent';
import { AddCategoryFormValues, Category } from "../models/category";
import { Result } from "../models/result";
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
            const category = this.categories.find(x => x.id === categoryId) || new Category();
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

    add = async (v: AddCategoryFormValues) => {
        try {
            const result = await agent.Categories.add(
                v.name, v.description, v.displayOrder, v.isPlaceholder);

            if (result.data.addCategory) {
                runInAction(() => this.categories.push(result.data.addCategory.category));

                return new Result(true, []);
            } else {
                return new Result(false, result?.errors?.map((x: any) => x.message) ?? []);
            }
        } catch (error) {
            throw error;
        }
    }

    remove = async (categoryId: string) => {
        try {
            const result = await agent.Categories.remove(categoryId);

            if (result?.errors) {
                return new Result(false, result?.errors?.map((x: any) => x.message) ?? []);
            } else {
                runInAction(() => this.loadCategories());

                return new Result(true, []);
            }
        } catch (error) {
            throw error;
        }
    }
}