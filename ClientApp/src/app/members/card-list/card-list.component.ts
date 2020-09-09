import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../../_services/auth.service';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { User } from '../../_models/user';
import { Photo } from '../../_models/photo';
import { PaginatedResult } from '../../_models/pagination';

@Component({
    selector: 'app-card-list',
    templateUrl: './card-list.component.html',
    styleUrls: ['./card-list.component.css']
})
export class CardListComponent implements OnInit {
    @Input() user: User;
    pagination: any;
    userParams: any;
    users: User[];


    constructor(private authService: AuthService,
        private userService: UserService,
        private alertify: AlertifyService) { }

    ngOnInit() {

    }


    sendLike(id: number) {
        this.userService.sendLike(this.authService.decodedToken.nameid, id).subscribe(data => {
            this.alertify.success('You have liked: ' + this.user.knownAs);
        }, error => {
            this.alertify.error(error);
        });
    }


}
