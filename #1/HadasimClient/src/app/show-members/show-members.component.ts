import { ChangeDetectorRef, Component } from '@angular/core';
import { MemberService } from '../services/member.service';
import MemberModel from '../models/MemberModel';
import { Router } from '@angular/router';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-show-members',
  templateUrl: './show-members.component.html',
  styleUrls: ['./show-members.component.scss']
})
export class ShowMembersComponent {

  constructor(public memberSer: MemberService, public router: Router, public confirmationService: ConfirmationService, private cdRef: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.memberSer.getAll().subscribe(succ => {
      this.memberSer.members = succ
      console.log("members-NgOnInit", this.memberSer.members)
    },
      err => {
        alert("error occures")
      }
    )
  }

  showDetails(i: number) {
    let memberId = this.memberSer.members[i].idMember;
    this.router.navigate(["/details"], { queryParams: { id: memberId } });

  }

  edit(member: any, i: number) {
    this.router.navigate(['/addMember'], { queryParams: { isEdit: true, index: i } });

  }

  removeControl(event: Event, member: any, i: number) {
    this.confirmationService.confirm({
      target: event.target as EventTarget,
      message: 'האם אתה בטוח שברצונך למחוק?',
      icon: 'pi pi-exclamation-triangle',
      acceptIcon: "pi pi-check",
      acceptLabel: " ",
      rejectLabel: " ",
      rejectIcon: "pi pi-times",

      accept: () => {
        console.log("member in delete", member.idMember);

        this.memberSer.delete(member.idMember).subscribe(succ => {
          alert("נמחק בהצלחה!")
          this.memberSer.members.splice(i, 1)
        },
          err => {
            alert("התרחשה שגיאה")
          })

      }
    });

  }
}
