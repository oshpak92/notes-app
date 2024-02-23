import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreateNote, CreateNoteResponse, Note, NotesResponse, UpdateNote, UpdateNoteResponse } from './models/Note';
import { Observable } from 'rxjs';

const notesBaseUrl = 'https://localhost:7029';

@Injectable({
  providedIn: 'root'
})
export class NotesApiService {
  
  constructor(private httpClient: HttpClient) {}

  getNote(id: number): Observable<Note> {
    return this.httpClient.get<Note>(`${notesBaseUrl}/notes/${id}`);
  }

  getAllNotes(): Observable<Array<Note>> {
    return this.httpClient.get<Array<Note>>(`${notesBaseUrl}/notes`);
  }

  updateNote(note: UpdateNote): Observable<UpdateNoteResponse> {
    return this.httpClient.put<Note>(`${notesBaseUrl}/notes`, note);
  }

  createNote(note: CreateNote ): Observable<CreateNoteResponse> {
    return this.httpClient.post<CreateNoteResponse>(`${notesBaseUrl}/notes`, note);
  }

  deleteNote(id: number) : Observable<any> {
    return this.httpClient.delete(`${notesBaseUrl}/notes/${id}`);
  }
}
