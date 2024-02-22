import { Component, OnInit } from '@angular/core';
import { Note } from '../../services/notes-api/models/Note';
import { NotesApiService } from '../../services/notes-api/notes-api.service';

@Component({
  selector: 'app-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrl: './notes-list.component.scss'
})
export class NotesListComponent implements OnInit{
  constructor(private apiService: NotesApiService){}

  Notes?: Array<Note>;

  ngOnInit(): void {
    this.loadNotes();
  }

  deleteNote(id: number){
    this.apiService.deleteNote(id).subscribe(data=>{
      if(data){
        this.loadNotes();
      }
    });
  }

  private loadNotes(){
    this.apiService.getAllNotes().subscribe((data)=>{
      this.Notes = data;
    });
  }
}
