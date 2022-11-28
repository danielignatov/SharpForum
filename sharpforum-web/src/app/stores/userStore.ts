import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { User, UserFormValues } from "../models/user";
import { store } from "./store";

export default class UserStore {
    user: User | null = null;
    token: string | null = window.localStorage.getItem('jwt');
    refreshTokenTimeout: any;

    constructor() {
        makeAutoObservable(this);

        reaction(
            () => this.token,
            token => {
                if (token) {
                    window.localStorage.setItem('jwt', token)
                } else {
                    window.localStorage.removeItem('jwt')
                }
            }
        )
    }

    setToken = (token: string | null) => {
        this.token = token;
    }

    get isLoggedIn() {
        return !!this.user;
    }

    login = async (creds: UserFormValues) => {
        try {
            const user = await agent.Users.login(creds.displayName, creds.password);
            this.setToken(user.token);
            this.startRefreshTokenTimer(user);
            runInAction(() => this.user = user);
        } catch (error) {
            throw error;
        }
    }

    logout = () => {
        this.setToken(null);
        window.localStorage.removeItem('jwt');
        runInAction(() => this.user = null);
    }

    //getUser = async () => {
    //    try {
    //        const user = await agent.Account.current();
    //        store.commonStore.setToken(user.token);
    //        runInAction(() => this.user = user);
    //        this.startRefreshTokenTimer(user);
    //    } catch (error) {
    //        console.log(error);
    //    }
    //}
    //
    //register = async (creds: UserFormValues) => {
    //    try {
    //        await agent.Account.register(creds);
    //        history.push(`/account/registerSuccess?email=${creds.email}`);
    //        store.modalStore.closeModal();
    //    } catch (error) {
    //        throw error;
    //    }
    //}
    //
    //setImage = (image: string) => {
    //    if (this.user) this.user.image = image;
    //}
    //
    //setDisplayName = (name: string) => {
    //    if (this.user) this.user.displayName = name;
    //}
    //
    //getFacebookLoginStatus = async () => {
    //    window.FB.getLoginStatus(response => {
    //        if (response.status === 'connected') {
    //            this.fbAccessToken = response.authResponse.accessToken;
    //        }
    //    })
    //}
    //
    //facebookLogin = () => {
    //    this.fbLoading = true;
    //    const apiLogin = (accessToken: string) => {
    //        agent.Account.fbLogin(accessToken).then(user => {
    //            store.commonStore.setToken(user.token);
    //            this.startRefreshTokenTimer(user);
    //            runInAction(() => {
    //                this.user = user;
    //                this.fbLoading = false;
    //            })
    //            history.push('/activities');
    //        }).catch(error => {
    //            console.log(error);
    //            runInAction(() => this.fbLoading = false);
    //        })
    //    }
    //    if (this.fbAccessToken) {
    //        apiLogin(this.fbAccessToken);
    //    } else {
    //        window.FB.login(response => {
    //            apiLogin(response.authResponse.accessToken);
    //        }, { scope: 'public_profile,email' })
    //    }
    //}
    //
    refreshToken = async () => {
        this.stopRefreshTokenTimer();
        //try {
        //    const user = await agent.Account.refreshToken();
        //    runInAction(() => this.user = user);
        //    this.setToken(user.token);
        //    this.startRefreshTokenTimer(user);
        //} catch (error) {
        //    console.log(error);
        //}
    }
    
    private startRefreshTokenTimer(user: User) {
        const jwtToken = JSON.parse(atob(user.token.split('.')[1]));
        const expires = new Date(jwtToken.exp * 1000);
        const timeout = expires.getTime() - Date.now() - (60 * 1000);
        this.refreshTokenTimeout = setTimeout(this.refreshToken, timeout);
    }
    
    private stopRefreshTokenTimer() {
        clearTimeout(this.refreshTokenTimeout);
    }
}

function reaction(arg0: () => string | null, arg1: (token: any) => void) {
    throw new Error("Function not implemented.");
}
