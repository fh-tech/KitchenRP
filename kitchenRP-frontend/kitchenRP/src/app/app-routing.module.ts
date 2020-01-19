import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReservationsComponent } from "./components/reservations/reservations.component";
import {CalendarComponent} from "./components/calendar/calendar.component";
import {AllReservationsComponent} from "./components/all-reservations/all-reservations.component";
import {AdminComponent} from "./components/admin/admin.component";
import {AuthGuardUser} from "./services/auth/auth-guard-user.service";
import {AuthGuardAdmin} from "./services/auth/auth-guard-admin.service";
import {LoginComponent} from "./components/login/login.component";
import {AuthGuardModerator} from "./services/auth/auth-guard-moderator.service";


const routes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'calendar', canActivate: [AuthGuardUser], component: CalendarComponent},
    {path: 'reservations', canActivate: [AuthGuardUser], component: ReservationsComponent},
    {path: 'all-reservations', canActivate: [AuthGuardModerator], component: AllReservationsComponent},
    {path: 'admin', canActivate: [AuthGuardAdmin], component: AdminComponent},
    {path: '**', redirectTo: '/calendar'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
