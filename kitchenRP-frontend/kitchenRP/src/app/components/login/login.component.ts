import { Component, OnInit } from '@angular/core';
import {AuthService} from "../../services/auth/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    private username: string = "";
    private password: string = "";

    constructor(private authService: AuthService, private router: Router){}

    public loginUser() {
        console.log(this.authService.isLoggedIn());

        let loginResult = this.authService.login(this.username, this.password);
        loginResult.subscribe((val) => {
            if (val === true) {
                this.router.navigate(['calendar']);
            } else {
                // show error
            }
        });
    }

    ngOnInit() {
    }

}
