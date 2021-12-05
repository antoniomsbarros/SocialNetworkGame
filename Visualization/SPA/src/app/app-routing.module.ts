import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {SignInComponent} from "./sign-in/sign-in.component";
import {LoginComponent} from "./login/login.component";
import {
  GetListOfPendingConnectionRequestsComponent
} from "./get-list-of-pending-connection-requests/get-list-of-pending-connection-requests.component";
import {CreateIntroductionComponent} from "./create-introduction/create-introduction.component";
import {
  ApproveDisapproveIntroductionRequestComponent
} from "./approve-disapprove-introduction-request/approve-disapprove-introduction-request.component";
import {EditHumorStateComponent} from "./edit-humor-state/edit-humor-state.component";
import {
  EditRelationshipTagsConnectionForceComponent
} from "./edit-relationship-tags-connection-force/edit-relationship-tags-connection-force.component";

import {CreateDirectRequestComponent} from "./create-direct-request/create-direct-request.component";
import {NetworkComponent} from "./network/network.component";

const routes: Routes = [
<<<<<<< HEAD
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent},
  {path: 'signin', component: SignInComponent},
  {path: 'login', component: LoginComponent},
  {path: 'network', component: NetworkComponent},
  {path: "getlistPendig", component: GetListOfPendingConnectionRequestsComponent},
  {path: "createIntroduction", component: CreateIntroductionComponent},
  {path: "GetApprovolRequests", component: ApproveDisapproveIntroductionRequestComponent},
  {path: "createDirectRequest", component: CreateDirectRequestComponent},
];
=======
    {path: '', redirectTo: '/home', pathMatch: 'full'},
    {path: 'home', component: HomeComponent},
    {path: 'signin', component: SignInComponent},
    {path: 'login', component: LoginComponent},
    {path: "getlistPendig", component: GetListOfPendingConnectionRequestsComponent},
    {path: "createIntroduction", component: CreateIntroductionComponent},
    {path: "GetApprovolRequests", component: ApproveDisapproveIntroductionRequestComponent},
    {path: "changeHumor", component: EditHumorStateComponent},
    {path: "editRelationshipTagsAndConnectionStrength", component: EditRelationshipTagsConnectionForceComponent},
    {path: "createDirectRequest", component: CreateDirectRequestComponent},
  ]
;
>>>>>>> 1e57c9004662c62f217a6dc94ae7ae77e48e1e99

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
