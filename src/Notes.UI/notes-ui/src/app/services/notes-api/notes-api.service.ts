import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CreaNote, CreateNoteResponse, Note, NotesResponse } from './models/Note';
import { Observable } from 'rxjs';

const notesBaseUrl = 'https://localhost:7029';

@Injectable({
  providedIn: 'root'
})
export class NotesApiService {
  
  constructor(private httpClient: HttpClient) {}

  getAllNotes(): Observable<Array<Note>> {
    return this.httpClient.get<Array<Note>>(`${notesBaseUrl}/notes`);
  }

  createNote(note: CreaNote ): Observable<CreateNoteResponse> {
    return this.httpClient.post<CreateNoteResponse>(`${notesBaseUrl}/notes`, note);
  }

  deleteNote(id: number) {
    return this.httpClient.delete(`${notesBaseUrl}/notes/${id}`);
  }
}
