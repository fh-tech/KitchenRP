import {Injectable} from "@angular/core";
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot} from "@angular/router";
import {Observable} from "rxjs";
import {AuthService} from "./auth.service";
import {User} from "../../types/user";

@Injectable()
export class AuthGuardUser implements CanActivate {
    private isLoggedIn: Boolean;
    private currentUser$: Observable<User>;

    constructor(private router: Router, private authService: AuthService) {
        this.isLoggedIn = this.authService.isLoggedIn();
        this.currentUser$ = this.authService.currentUser$;
    }

    canActivate(route: ActivatedRouteSnapshot,
                state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
        let permitted = true;
        if (!this.isLoggedIn) {
            this.router.navigate(['login']);
        } else {
            permitted = true;
        }
        /*this.currentUser$.subscribe((user) => {
            if (user.role == 'user') {
                permitted = true;
            } else {
                this.router.navigate(['login']);
            }
        });*/
        return permitted;
    }
}
