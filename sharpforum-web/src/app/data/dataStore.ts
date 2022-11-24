import { createContext, useContext } from "react";
import CategoryDataStore from "./categoryDataStore";

interface DataStore {
    categoryDataStore: CategoryDataStore;
}

export const dataStore: DataStore = {
    categoryDataStore: new CategoryDataStore()
}

export const DataStoreContext = createContext(dataStore);

export function useStore() {
    return useContext(DataStoreContext);
}