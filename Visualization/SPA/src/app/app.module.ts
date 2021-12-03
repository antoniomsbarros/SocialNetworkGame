import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {AppComponent} from './app.component';
import {GetListOfPendingConnectionRequestsComponent} from './get-list-of-pending-connection-requests/get-list-of-pending-connection-requests.component';
import {HttpClient, HttpClientModule} from "@angular/common/http";

import {AcceptOrRejectTheIntroductionComponent} from './accept-or-reject-the-introduction/accept-or-reject-the-introduction.component';
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {FormsModule} from "@angular/forms";
import {MatExpansionModule} from '@angular/material/expansion';
import {MatNativeDateModule} from "@angular/material/core";
import {MatIconModule} from "@angular/material/icon";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatButtonModule} from "@angular/material/button";

import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

import {ToastrModule} from "ngx-toastr";


import {HomeComponent} from './home/home.component';
import {AppRoutingModule} from './app-routing.module';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {SignInComponent} from './sign-in/sign-in.component';
import {HeaderComponent} from './header/header.component';
import {ReactiveFormsModule} from "@angular/forms";

import { MatSelectSearchModule } from 'mat-select-search';


import { LoginComponent } from './login/login.component';


import {MatSelectModule} from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import {MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule} from "@angular/material/dialog";
@NgModule({
  declarations: [
    AppComponent,
    GetListOfPendingConnectionRequestsComponent,
    AcceptOrRejectTheIntroductionComponent,
    HomeComponent,

    HeaderComponent,
    SignInComponent,
    HeaderComponent,
    LoginComponent,

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


  ],
  providers: [HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule {
}
