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

import {HomeComponent} from './home/home.component';
import {AppRoutingModule} from './app-routing.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {SignInComponent} from './sign-in/sign-in.component';
import {HeaderComponent} from './header/header.component';
import {ReactiveFormsModule} from "@angular/forms";
import { ShortestPathComponent } from './shortest-path/shortest-path.component';
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
import { UpdateProfileComponent } from './update-profile/update-profile.component';
import { SafestPathComponent } from './safest-path/safest-path.component';
import { NetworkListingComponent } from './network-listing/network-listing.component';

@NgModule({
  declarations: [
    AppComponent,
    GetListOfPendingConnectionRequestsComponent,
    AcceptOrRejectTheIntroductionComponent,
    HomeComponent,
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
    NetworkListingComponent
  ],
  imports: [
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
  ], entryComponents: [],
  providers: [HttpClient, {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}],
  bootstrap: [AppComponent]
})

export class AppModule {
}
