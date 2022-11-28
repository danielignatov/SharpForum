import { createContext, useContext } from "react";
import CategoryStore from "./categoryStore";
import TopicStore from "./topicStore";
import ReplyStore from "./replyStore";

interface Store {
    categoryStore: CategoryStore;
    topicStore: TopicStore;
    replyStore: ReplyStore;
}

export const store: Store = {
    categoryStore: new CategoryStore(),
    topicStore: new TopicStore(),
    replyStore: new ReplyStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}