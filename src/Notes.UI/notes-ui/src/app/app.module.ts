import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotesListComponent } from './notes/notes-list/notes-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { NotesApiService } from './services/notes-api/notes-api.service';
import { HttpClientModule } from '@angular/common/http';
import { AddNoteComponent } from './notes/add-note/add-note.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NoteDetailsComponent } from './notes/note-details/note-details.component';

const appRoutes: Routes = [
  { path: '', component: NotesListComponent },
  { path: 'create-note', component: AddNoteComponent },
  { path: 'note-details/:{id}', component: NoteDetailsComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    NotesListComponent,
    NavBarComponent,
    AddNoteComponent,
    NoteDetailsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [NotesApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
