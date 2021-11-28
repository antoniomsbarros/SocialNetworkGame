import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { GetListOfPendingConnectionRequestsComponent } from './get-list-of-pending-connection-requests/get-list-of-pending-connection-requests.component';
import {HttpClientModule} from "@angular/common/http";
import { AcceptOrRejectTheIntroductionComponent } from './accept-or-reject-the-introduction/accept-or-reject-the-introduction.component';

@NgModule({
  declarations: [
    AppComponent,
    GetListOfPendingConnectionRequestsComponent,
    AcceptOrRejectTheIntroductionComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
