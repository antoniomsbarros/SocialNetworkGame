import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
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
import {UpdateProfileComponent} from "./update-profile/update-profile.component";
import {ShortestPathComponent} from "./shortest-path/shortest-path.component";
import {SafestPathComponent} from "./safest-path/safest-path.component";
import {NetworkListingComponent} from "./network-listing/network-listing.component";
import {TermsAndConditionsComponent} from "./terms-and-conditions/terms-and-conditions.component";
import {PrivacyPolicyComponent} from "./privacy-policy/privacy-policy.component";
import {ProfileComponent} from "./profile/profile.component";
import {ProfileTagsComponent} from "./profile/profile-tags/profile-tags.component";
import {ProfilePostsComponent} from "./profile/profile-posts/profile-posts.component";
import {ProfileFriendsComponent} from "./profile/profile-friends/profile-friends.component";
import {ProfileBodyComponent} from "./profile/profile-body/profile-body.component";

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'signin', component: SignInComponent},
  {path: 'terms-conditions', component: TermsAndConditionsComponent},
  {path: 'privacy-policy', component: PrivacyPolicyComponent},
  {path: 'login', component: LoginComponent},
  {path: 'network', component: NetworkComponent},
  {path: "getlistPendig", component: GetListOfPendingConnectionRequestsComponent},
  {path: "createIntroduction", component: CreateIntroductionComponent},
  {path: "GetApprovolRequests", component: ApproveDisapproveIntroductionRequestComponent},
  {path: "changeHumor", component: EditHumorStateComponent},
  {path: "editRelationshipTagsAndConnectionStrength", component: EditRelationshipTagsConnectionForceComponent},
  {path: "createDirectRequest", component: CreateDirectRequestComponent},
  {path: "updateProfile", component: UpdateProfileComponent},
  {path: "shortestPath", component: ShortestPathComponent},
  {path: "safestPath", component: SafestPathComponent},
  {path: "networkListing", component: NetworkListingComponent},
  {path: "profile/:email", component: ProfileComponent,children:[
      {path:"", component:ProfileBodyComponent, children:[
          {path:"", redirectTo:"post", pathMatch:"full"},
          {path:"post", component:ProfilePostsComponent},
          {path:"tags", component:ProfileTagsComponent},
          {path:"friends", component:ProfileFriendsComponent}
        ]}
    ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes,  {
    paramsInheritanceStrategy: 'always'
  })],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
