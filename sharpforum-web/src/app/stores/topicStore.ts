import { makeAutoObservable } from "mobx";
import agent from '../api/agent';
import { Topic } from "../models/topic";
//import { store } from "./store";

export default class TopicStore {
    topics: Topic[] = [];
    topicsByCategory: Topic[] = [];
    selectedTopic: Topic | undefined = undefined;
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    loadTopics = async () => {
        this.loading = true;
        try {
            const result = await agent.Topics.all();
            this.topics = result.data.topics;
            this.loading = false;
        } catch (error) {
            console.log(error);
            this.loading = false;
        }
    }

    loadTopicsByCategory = async (categoryId: string) => {
        this.loading = true;
        try {
            this.topicsByCategory = [];
            const result = await agent.Topics.byCategory(categoryId);
            this.topicsByCategory = result.data.topics;
            this.loading = false;
        } catch (error) {
            console.log(error);
            this.loading = false;
        }
    }
}