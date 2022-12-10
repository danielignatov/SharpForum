import { makeAutoObservable, runInAction } from "mobx";
import agent from '../api/agent';
import { AddReplyFormValues, Reply } from "../models/reply";
import { Result } from "../models/result";

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

    add = async (v: AddReplyFormValues) => {
        try {
            const result = await agent.Replies.add(
                v.authorId, v.topicId, v.message);

            if (result.data.addReply) {
                runInAction(() => this.selectedTopicReplies.push(result.data.addReply.reply));

                return new Result(true, []);
            } else {
                return new Result(false, result?.errors?.map((x: any) => x.message) ?? []);
            }
        } catch (error) {
            throw error;
        }
    }
}