import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {SignInComponent} from "./sign-in/sign-in.component";
import {LoginComponent} from "./login/login.component";
import {GetListOfPendingConnectionRequestsComponent} from "./get-list-of-pending-connection-requests/get-list-of-pending-connection-requests.component";
import {CreateIntroductionComponent} from "./create-introduction/create-introduction.component";
import {ApproveDisapproveIntroductionRequestComponent} from "./approve-disapprove-introduction-request/approve-disapprove-introduction-request.component";
import {EditHumorStateComponent} from "./edit-humor-state/edit-humor-state.component";
import {
  EditRelationshipTagsConnectionForceComponent
} from "./edit-relationship-tags-connection-force/edit-relationship-tags-connection-force.component";

const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'signin', component: SignInComponent},
  {path: 'login', component: LoginComponent},
  {path: "getlistPendig", component: GetListOfPendingConnectionRequestsComponent},
  {path: "createIntroduction", component: CreateIntroductionComponent},
  {path: "GetApprovolRequests", component: ApproveDisapproveIntroductionRequestComponent},
  {path: "changeHumor", component: EditHumorStateComponent},
  {path: "editRelationshipTagsAndConnectionStrength", component: EditRelationshipTagsConnectionForceComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
