import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MemberService } from '../services/member.service';
import MemberModel from '../models/MemberModel';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent {
  id: number;
  member: MemberModel
  constructor(public route: ActivatedRoute, public memberSer: MemberService) {
    this.route.queryParams.subscribe(params => {
      console.log("param", params);
      this.id = params['id'];
    });

  }

  ngOnInit(): void {
      this.memberSer.getById(this.id).subscribe(succ => {
        this.member = succ
        console.log("members-NgOnInit", this.member)
      },
        err => {
          alert("error occures")
        }
      )

  }
}

