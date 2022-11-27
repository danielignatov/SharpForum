import { createContext, useContext } from "react";
import CategoryStore from "./categoryStore";

interface Store {
    categoryStore: CategoryStore;
}

export const store: Store = {
    categoryStore: new CategoryStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}