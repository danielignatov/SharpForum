import { makeAutoObservable } from "mobx";
import agent from '../api/agent';
import { TopicResult } from "../models/result";
import { AddTopicFormValues, Topic } from "../models/topic";
//import { store } from "./store";

export default class TopicStore {
    selectedTopic: Topic | undefined = undefined;
    topicsByCategory: Topic[] = [];
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    loadSelectedTopic = async (topicId: string) => {
        this.setLoading(true);
        try {
            const result = await agent.Topics.byId(topicId);
            this.setSelectedTopic(result.data.topics[0]);
            this.setLoading(false);
        } catch (error) {
            console.log(error);
            this.setLoading(false);
        }
    }

    loadTopicsByCategory = async (categoryId: string) => {
        this.setLoading(true);
        try {
            this.setTopicsByCategory([]);
            const result = await agent.Topics.byCategory(categoryId);
            this.setTopicsByCategory(result.data.topics);
            this.setLoading(false);
        } catch (error) {
            console.log(error);
            this.setLoading(false);
        }
    }

    setSelectedTopic = (topic: Topic) => {
        this.selectedTopic = topic;
    }

    setTopicsByCategory = (topics: Topic[]) => {
        this.topicsByCategory = topics;
    }

    setLoading = (loading: boolean) => {
        this.loading = loading;
    }

    add = async (v: AddTopicFormValues) => {
        try {
            const result = await agent.Topics.add(v.authorId, v.categoryId, v.subject, v.message, v.sticky, v.locked);
            if (result.data.addTopic) {
                debugger;
                return new TopicResult(true, result.data.addTopic.topic.id, []);
            } else {
                debugger;
                return new TopicResult(false, '', result.errors.map((x: any) => x.message));
            }
        } catch (error) {
            throw error;
        }
    }
}