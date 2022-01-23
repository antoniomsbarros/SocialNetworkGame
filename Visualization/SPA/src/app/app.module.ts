import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {
  GetListOfPendingConnectionRequestsComponent
} from './get-list-of-pending-connection-requests/get-list-of-pending-connection-requests.component';
import {HttpClient, HttpClientModule} from "@angular/common/http";

import {
  AcceptOrRejectTheIntroductionComponent
} from './accept-or-reject-the-introduction/accept-or-reject-the-introduction.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {FormsModule} from "@angular/forms";
import {MatExpansionModule} from '@angular/material/expansion';
import {MatNativeDateModule} from "@angular/material/core";
import {MatIconModule} from "@angular/material/icon";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";

import {NgMultiSelectDropDownModule} from 'ng-multiselect-dropdown';

import {ToastrModule} from "ngx-toastr";

import "@angular/compiler";
import {EditHumorStateComponent} from './edit-humor-state/edit-humor-state.component';

import {AppRoutingModule} from './app-routing.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {SignInComponent} from './sign-in/sign-in.component';
import {HeaderComponent} from './header/header.component';
import {ReactiveFormsModule} from "@angular/forms";
import {ShortestPathComponent} from './shortest-path/shortest-path.component';
import {MatSelectSearchModule} from 'mat-select-search';
import {LoginComponent} from './login/login.component';
import {
  ApproveDisapproveIntroductionRequestComponent
} from './approve-disapprove-introduction-request/approve-disapprove-introduction-request.component';
import {CreateIntroductionComponent} from './create-introduction/create-introduction.component';
import {MatSelectModule} from '@angular/material/select';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule} from "@angular/material/dialog";
import {
  EditRelationshipTagsConnectionForceComponent
} from './edit-relationship-tags-connection-force/edit-relationship-tags-connection-force.component';
import {CreateDirectRequestComponent} from './create-direct-request/create-direct-request.component';
import {DialogComponent} from './dialog-component/dialog.component';
import {NetworkComponent} from './network/network.component';
import {UpdateProfileComponent} from './update-profile/update-profile.component';
import {SafestPathComponent} from './safest-path/safest-path.component';
import {NetworkListingComponent} from './network-listing/network-listing.component';
import {TermsAndConditionsComponent} from './terms-and-conditions/terms-and-conditions.component';
import {PrivacyPolicyComponent} from './privacy-policy/privacy-policy.component';
import { SuggestConnectionComponent } from './suggest-connection/suggest-connection.component';
import { TagCloudModule } from 'angular-tag-cloud-module';
import { DialogFullNameComponent } from './update-profile/dialogComponentsUPdateProfile/dialog-full-name/dialog-full-name.component';
import { DialogShortNameComponent } from './update-profile/dialogComponentsUPdateProfile/dialog-short-name/dialog-short-name.component';
import { DialogPhoneNumberComponent } from './update-profile/dialogComponentsUPdateProfile/dialog-phone-number/dialog-phone-number.component';
import { DialogFacebookLinkComponent } from './update-profile/dialogComponentsUPdateProfile/dialog-facebook-link/dialog-facebook-link.component';
import { DialogLinkedinLinkComponent } from './update-profile/dialogComponentsUPdateProfile/dialog-linkedin-link/dialog-linkedin-link.component';
import {MatCardModule} from "@angular/material/card";
import { ProfileComponent } from './profile/profile.component';
import {ProfileHeaderComponent} from "./profile/profile-header/profile-header.component";
import {ProfileBodyComponent} from "./profile/profile-body/profile-body.component";
import {ProfileAbouteMeComponent} from "./profile/profile-aboute-me/profile-aboute-me.component";
import {ProfilePostsComponent} from "./profile/profile-posts/profile-posts.component";
import {ProfileFriendsComponent} from "./profile/profile-friends/profile-friends.component";
import {ProfileTagsComponent} from "./profile/profile-tags/profile-tags.component";
import { TagCloudRelationshipsComponent } from './tag-cloud-relationships/tag-cloud-relationships.component';
import { ConsultAllPlayersTagCloudComponent } from './consult-all-players-tag-cloud/consult-all-players-tag-cloud.component';
import { ConsultAllRelationshipsTagCloudComponent } from './consult-all-relationships-tag-cloud/consult-all-relationships-tag-cloud.component';
import { SearchProfileComponent } from './search-profile/search-profile.component';

@NgModule({
  declarations: [
    AppComponent,
    GetListOfPendingConnectionRequestsComponent,
    AcceptOrRejectTheIntroductionComponent,
    EditHumorStateComponent,
    HeaderComponent,
    SignInComponent,
    HeaderComponent,
    LoginComponent,
    ApproveDisapproveIntroductionRequestComponent,
    CreateIntroductionComponent,
    EditRelationshipTagsConnectionForceComponent,
    CreateDirectRequestComponent,
    DialogComponent,
    NetworkComponent,
    UpdateProfileComponent,
    ShortestPathComponent,
    SafestPathComponent,
    NetworkListingComponent,
    TermsAndConditionsComponent,
    PrivacyPolicyComponent,
    SuggestConnectionComponent,
    DialogFullNameComponent,
    DialogShortNameComponent,
    DialogPhoneNumberComponent,
    DialogFacebookLinkComponent,
    DialogLinkedinLinkComponent,
    ProfileComponent,
    ProfileHeaderComponent,
    ProfileBodyComponent,
    ProfileAbouteMeComponent,
    ProfilePostsComponent,
    ProfileFriendsComponent,
    ProfileTagsComponent,
    TagCloudRelationshipsComponent,
    ConsultAllPlayersTagCloudComponent,
    ConsultAllRelationshipsTagCloudComponent,
    SearchProfileComponent,

  ],
    imports: [
        TagCloudModule,
        MatFormFieldModule,
        MatSelectModule,
        BrowserModule,
        HttpClientModule,
        MatSelectSearchModule,
        BrowserAnimationsModule,
        FormsModule,
        MatExpansionModule,
        MatNativeDateModule,
        MatIconModule,
        MatFormFieldModule,
        MatInputModule,
        MatButtonModule,
        AppRoutingModule,
        NgbModule,
        MatSnackBarModule,
        NgMultiSelectDropDownModule.forRoot(),
        ReactiveFormsModule,
        MatDialogModule,
        ToastrModule.forRoot(),
        NgbModule,
        MatCardModule,
    ], entryComponents: [],
  providers: [HttpClient, {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}],
  bootstrap: [AppComponent]
})

export class AppModule {
}
