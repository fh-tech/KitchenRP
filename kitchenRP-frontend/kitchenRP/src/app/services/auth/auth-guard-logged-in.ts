import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {Observable} from "rxjs";
import {AuthService} from "./auth.service";
import {User} from "../../types/user";

@Injectable()
export class AuthGuardLoggedIn implements CanActivate {
    private isLoggedIn: Boolean;
    private isAnyUser: Boolean;
    private currentUser$: Observable<User>;

    constructor(private router: Router, private authService: AuthService) {
        this.isLoggedIn = this.authService.isLoggedIn();
        this.isAnyUser = this.authService.isAnyUser();
        this.currentUser$ = this.authService.currentUser$;
    }

    canActivate(route: ActivatedRouteSnapshot,
                state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        let permitted = false;
        if (this.isLoggedIn && this.isAnyUser) {
            this.router.navigate(['calendar']);
        } else {
            permitted = true;
        }
        return permitted;
    }
}
