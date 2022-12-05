import { makeAutoObservable, runInAction, reaction } from "mobx";
//import { redirect } from "react-router-dom";
import agent from "../api/agent";
import { User, LoginUserFormValues, RegisterUserFormValues, RegisterUserResult } from "../models/user";
//import { store } from "./store";
//import { GetKitten } from ''

export default class UserStore {
    selectedUser: User | null = null;
    loadingSelectedUser: boolean = false;
    currentUser: User | null = null;
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

    loadSelectedUser = async (userId: string) => {
        this.setLoadingSelectedUser(true);
        try {
            const result = await agent.Users.byId(userId);
            this.setSelectedUser(result.data.users[0]);
            this.setLoadingSelectedUser(false);
        } catch (error) {
            console.log(error);
            this.setLoadingSelectedUser(false);
        }
    }

    setSelectedUser = (user: User) => {
        this.selectedUser = user;
    }

    setLoadingSelectedUser = (loading: boolean) => {
        this.loadingSelectedUser = loading;
    }

    setToken = (token: string | null) => {
        this.token = token;
    }

    get isLoggedIn() {
        return !!this.currentUser;
    }

    login = async (creds: LoginUserFormValues) => {
        try {
            const result = await agent.Users.login(creds.displayName, creds.password);
            this.setToken(result.data.loginUser.token);
            this.startRefreshTokenTimer(result.data.loginUser.token);
            runInAction(() => this.currentUser = result.data.loginUser.user);
        } catch (error) {
            throw error;
        }
    }

    logout = () => {
        this.setToken(null);
        window.localStorage.removeItem('jwt');
        runInAction(() => this.currentUser = null);
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
    register = async (creds: RegisterUserFormValues) => {
        try {
            const result = await agent.Users.register(creds.displayName, creds.password, creds.email);
            if (result.data.registerUser) {
                this.setToken(result.data.registerUser.token);
                this.startRefreshTokenTimer(result.data.registerUser.token);
                runInAction(() => this.currentUser = result.data.registerUser.user);
                return new RegisterUserResult(true, []);
            }
            else {
                return new RegisterUserResult(false, result.errors.map((x: any) => x.message));
            }
        } catch (error) {
            throw error;
        }
    }
    
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
    
    private startRefreshTokenTimer(token: string) {
        const jwtToken = JSON.parse(atob(token.split('.')[1]));
        const expires = new Date(jwtToken.exp * 1000);
        const timeout = expires.getTime() - Date.now() - (60 * 1000);
        this.refreshTokenTimeout = setTimeout(this.refreshToken, timeout);
    }
    
    private stopRefreshTokenTimer() {
        clearTimeout(this.refreshTokenTimeout);
    }
}