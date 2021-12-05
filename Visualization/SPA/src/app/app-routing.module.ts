import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home/home.component';
import {SignInComponent} from "./sign-in/sign-in.component";
import {LoginComponent} from "./login/login.component";
import {GetListOfPendingConnectionRequestsComponent} from "./get-list-of-pending-connection-requests/get-list-of-pending-connection-requests.component";
import {CreateIntroductionComponent} from "./create-introduction/create-introduction.component";
import {ApproveDisapproveIntroductionRequestComponent} from "./approve-disapprove-introduction-request/approve-disapprove-introduction-request.component";
import {CreateDirectRequestComponent} from "./create-direct-request/create-direct-request.component";
import {NetworkComponent} from "./network/network.component";

const routes: Routes = [
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

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
