import {Component, OnInit} from "@angular/core";
import {AuthService} from "../../../../services/auth/auth.service";
import {Observable} from "rxjs";
import {User} from "../../../../types/user";
import {Router} from "@angular/router";

@Component({
    selector: 'app-account',
    templateUrl: './account.component.html',
    styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {

    currentUser: Observable<User>;
    constructor(private authService: AuthService, private router: Router,) {
        this.currentUser = this.authService.currentUser$;

        console.log("account component:");
        console.log(this.authService.getUsername());
        console.log(this.authService.isAnyUser());
    }

    ngOnInit() {
    }

    private logoutUser() {
        this.authService.logout().subscribe((result) => {
            if (result == true) {
                this.router.navigate(['/login']);
            }
        });
    }

}
