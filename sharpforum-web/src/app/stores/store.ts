import { createContext, useContext } from "react";
import CategoryStore from "./categoryStore";
import TopicStore from "./topicStore";

interface Store {
    categoryStore: CategoryStore;
    topicStore: TopicStore;
}

export const store: Store = {
    categoryStore: new CategoryStore(),
    topicStore: new TopicStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}