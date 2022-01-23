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
import {TagCloudRelationshipsComponent} from "./tag-cloud-relationships/tag-cloud-relationships.component";
import {
  ConsultAllPlayersTagCloudComponent
} from "./consult-all-players-tag-cloud/consult-all-players-tag-cloud.component";
import {
  ConsultAllRelationshipsTagCloudComponent
} from "./consult-all-relationships-tag-cloud/consult-all-relationships-tag-cloud.component";
import {GetPendingDirectRequestsComponent} from "./get-pending-direct-requests/get-pending-direct-requests.component";
import {SearchProfileComponent} from "./search-profile/search-profile.component";
import {DeleteAccountComponent} from "./delete-account/delete-account.component";

const routes: Routes = [
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'signin', component: SignInComponent},
  {path: 'terms-conditions', component: TermsAndConditionsComponent},
  {path: 'privacy-policy', component: PrivacyPolicyComponent},
  {path: 'login', component: LoginComponent},

  {path: 'network', component: NetworkComponent},//esta
  {path: "getlistPendig", component: GetListOfPendingConnectionRequestsComponent},//esta
  {path: "pendingDirectRequests", component: GetPendingDirectRequestsComponent},
  {path: "createIntroduction", component: CreateIntroductionComponent},//esta
  {path: "GetApprovolRequests", component: ApproveDisapproveIntroductionRequestComponent},//esta
  {path: "changeHumor", component: EditHumorStateComponent},//esta
  {path: "editRelationshipTagsAndConnectionStrength", component: EditRelationshipTagsConnectionForceComponent},//esta
  {path: "createDirectRequest", component: CreateDirectRequestComponent},//esta
  {path: "updateProfile", component: UpdateProfileComponent},//esta
  {path: "deleteAccount", component: DeleteAccountComponent},//esta
  {path: "shortestPath", component: ShortestPathComponent},//esta
  {path: "safestPath", component: SafestPathComponent},//esta
  {path: "networkListing", component: NetworkListingComponent},//esta
  {path: "tagsrelationships", component: TagCloudRelationshipsComponent},//esta
  {path: "searcheprofile", component: SearchProfileComponent},//esta

  {path: "profile/:email", component: ProfileComponent,children:[
      {path:"", component:ProfileBodyComponent, children:[
          {path:"", redirectTo:"post", pathMatch:"full"},
          {path:"post", component:ProfilePostsComponent},
          {path:"tags", component:ProfileTagsComponent},
          {path:"friends", component:ProfileFriendsComponent}
        ]}
    ]},
  {path: "consultPlayersTagCloud", component: ConsultAllPlayersTagCloudComponent},//esta
  {path: "consultRelationshipsTagCloud", component: ConsultAllRelationshipsTagCloudComponent},//esta
];

@NgModule({
  imports: [RouterModule.forRoot(routes,  {
    paramsInheritanceStrategy: 'always'
  })],
  exports: [RouterModule]
})

export class AppRoutingModule {
}
