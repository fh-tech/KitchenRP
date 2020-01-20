import {Injectable} from "@angular/core";
import {LoginService} from "./login.service";
import {Observable, of, ReplaySubject, Subject} from "rxjs";
import {catchError, mapTo, tap} from "rxjs/operators";
import {Token} from "./user-auth";
import {User} from "../../types/user";
import {UserService} from "../user/user.service";


@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private readonly ACCESS_TOKEN_KEY = "ACCESS_TOKEN";
    private readonly REFRESH_TOKEN_KEY = "REFRESH_TOKEN";

    private loggedInUser: string;
    private currentUser: Subject<User> = new ReplaySubject(1);
    public currentUser$: Observable<User> = this.currentUser.asObservable();

    public constructor(private loginService: LoginService, private userService: UserService) {

    }

    public login(username: string, password: string): Observable<boolean> {
        return this.loginService.login({username, password})
            .pipe(
                tap(tokens => this.doLoginUser(username, tokens)),
                mapTo(true),
                catchError(err => {
                    console.log(err);
                    return of(false)
                })
            );
    }

    public logout() {
        return this.loginService.logout(this.getRefreshToken())
            .pipe(
                tap(() => this.doLogoutUser()),
                mapTo(true),
                catchError((err) => {
                    console.log(err);
                    return of(false);
                })
            );
    }

    public refreshToken() {
        return this.loginService.refresh(this.getRefreshToken())
            .pipe(
                tap(tokens => this.storeTokens(tokens)),
            );
    }

    private storeTokens(tokens: Token) {
        localStorage.setItem(this.ACCESS_TOKEN_KEY, tokens.accessToken);
        localStorage.setItem(this.REFRESH_TOKEN_KEY, tokens.refreshToken);
    }

    isLoggedIn() {
        return !!this.getAccessToken();
    }

    public isAnyUser(): boolean {
        let isAnyUser = false;
        /*
        this.currentUser$.subscribe((val) => {
            isAnyUser = val.role === 'user' || val.role === 'moderator' || val.role === 'admin';
            console.log("In currentUser$: ");
            console.log("isAnyUser: " + isAnyUser);
            console.log("val: " + val);
        });
        */
        return isAnyUser;
    }

    public isUser(): boolean {
        let isUser = false;
        /*
        this.currentUser$.subscribe((val) => {
            isUser = val.role === 'user';
        });
        */
        return isUser;
    }

    public isModerator() {
        return this.currentUser$.subscribe((val) => {
            return val.role === 'moderator';
        });
    }

    public isAdmin() {
        return this.currentUser$.subscribe((val) => {
            return val.role === 'admin';
        });
    }

    public getUsername() {
        return this.loggedInUser;
    }

    public getRefreshToken() {
        return localStorage.getItem(this.REFRESH_TOKEN_KEY);
    }

    public getAccessToken() {
        return localStorage.getItem(this.ACCESS_TOKEN_KEY);
    }

    private removeTokens() {
        localStorage.removeItem(this.ACCESS_TOKEN_KEY);
        localStorage.removeItem(this.REFRESH_TOKEN_KEY);
    }

    private doLogoutUser() {
        this.loggedInUser = null;
        this.removeTokens();
    }

    private doLoginUser(username: string, tokens: Token) {
        this.loggedInUser = username;
        this.userService.getByName(username).subscribe((user) => this.currentUser.next(user));
        this.storeTokens(tokens);
    }
}
