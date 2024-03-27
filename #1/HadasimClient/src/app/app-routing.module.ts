import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowMembersComponent } from './show-members/show-members.component';
import { DetailsComponent } from './details/details.component';
import { AddMemberComponent } from './add-member/add-member.component';

const routes: Routes = [
  // { path: '', component: ShowMembersComponent },
  { path: 'showMember', component: ShowMembersComponent },
  { path: 'details', component: DetailsComponent },
  { path: 'addMember', component: AddMemberComponent },

  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
