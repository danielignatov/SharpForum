import { createContext, useContext } from "react";
import CategoryStore from "./categoryStore";
import TopicStore from "./topicStore";
import ReplyStore from "./replyStore";
import UserStore from "./userStore";

interface Store {
    categoryStore: CategoryStore;
    topicStore: TopicStore;
    replyStore: ReplyStore;
    userStore: UserStore;
}

export const store: Store = {
    categoryStore: new CategoryStore(),
    topicStore: new TopicStore(),
    replyStore: new ReplyStore(),
    userStore: new UserStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}