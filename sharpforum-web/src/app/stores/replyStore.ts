import { makeAutoObservable } from "mobx";
import agent from '../api/agent';
import { Reply } from "../models/reply";

export default class ReplyStore {
    selectedTopicReplies: Reply[] = [];
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    loadSelectedTopicReplies = async (topicId: string) => {
        this.setLoading(true);
        try {
            const result = await agent.Replies.byTopicId(topicId);
            this.setSelectedTopicReplies(result.data.replies);
            this.setLoading(false);
        } catch (error) {
            console.log(error);
            this.setLoading(false);
        }
    }

    setSelectedTopicReplies = (replies: Reply[]) => {
        this.selectedTopicReplies = replies;
    }

    setLoading = (loading: boolean) => {
        this.loading = loading;
    }
}