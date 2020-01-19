﻿import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {Observable} from "rxjs";
import {AuthService} from "./auth.service";
import {User} from "../../types/user";

@Injectable()
export class AuthGuardAdmin implements CanActivate {
    private isLoggedIn: Boolean;
    private currentUser$: Observable<User>;

    constructor(private router: Router, private authService: AuthService) {
        this.isLoggedIn = this.authService.isLoggedIn();
        this.currentUser$ = this.authService.currentUser$;
    }

    canActivate(route: ActivatedRouteSnapshot,
                state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        let permitted = false;
        if (!this.isLoggedIn) {
            this.router.navigate(['login']);
        } else {
            this.currentUser$.subscribe((user) => {
                if (user.role === 'admin') {
                    permitted = true;
                }
            });
        }
        return permitted;
    }
}
