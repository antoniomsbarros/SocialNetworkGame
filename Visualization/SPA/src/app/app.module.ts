import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { GetListOfPendingConnectionRequestsComponent } from './get-list-of-pending-connection-requests/get-list-of-pending-connection-requests.component';
import {HttpClientModule} from "@angular/common/http";
import { AcceptOrRejectTheIntroductionComponent } from './accept-or-reject-the-introduction/accept-or-reject-the-introduction.component';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    GetListOfPendingConnectionRequestsComponent,
    AcceptOrRejectTheIntroductionComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
