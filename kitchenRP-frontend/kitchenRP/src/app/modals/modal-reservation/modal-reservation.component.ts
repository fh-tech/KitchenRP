import {Component, OnInit, Input} from '@angular/core';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {ReservationService} from "../../services/reservation/reservation.service";

@Component({
    selector: 'app-modal-reservation',
    templateUrl: './modal-reservation.component.html',
    styleUrls: ['./modal-reservation.component.css']
})
export class ModalReservationComponent implements OnInit {

    date = new Date();
    duration = {hour: 0, minute: 0};
    timeStart = {hour: 0, minute: 0};

    resourceId: number;
    userId: number;

    constructor(private activeModal: NgbActiveModal,
                private reservationService: ReservationService) {
    }

    saveReservation() {

        let startDate = new Date(this.date);
        startDate.setHours(this.timeStart.hour);
        startDate.setMinutes(this.timeStart.minute);

        let endDate = new Date(startDate.getTime()
            + (1000 * 60) * this.duration.minute
            + (1000 * 60 * 60) * this.duration.hour);

        this.reservationService.create({
            allowNotifications: true,
            startTime: startDate.toISOString(),
            endTime: endDate.toISOString(),
            resourceId: this.resourceId,
            userId: this.userId
        }).subscribe(
            _ => this.activeModal.close()
        )
    }

    ngOnInit() {
    }

}
