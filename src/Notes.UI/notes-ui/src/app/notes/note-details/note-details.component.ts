import { Component, OnInit } from '@angular/core';
import { NotesApiService } from '../../services/notes-api/notes-api.service';
import { ActivatedRoute } from '@angular/router';
import { Note } from '../../services/notes-api/models/Note';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-note-details',
  templateUrl: './note-details.component.html',
  styleUrl: './note-details.component.scss'
})
export class NoteDetailsComponent implements OnInit{
  noteId?: number;
  note?: Note; 

  titleControl = new FormControl<string|null>(null, [Validators.required]);
  textControl = new FormControl<string|null>(null, [Validators.required]);
  noteFormGroup =  new FormGroup({
    title: this.titleControl,
    text: this.textControl
  });

  constructor(
    private route: ActivatedRoute, 
    private router: Router, 
    private apiService: NotesApiService) { }

  ngOnInit(): void {

    this.route.params
      .pipe(map(param => +param['{id}'] as number))
      .subscribe(id => {
        if (!isNaN(id)) {
          this.apiService.getNote(id)
            .subscribe(data => {
              this.titleControl.setValue(data.title);
              this.textControl.setValue(data.text);
              this.note = data;
            });
        }
      });
  }

  onSubmit() {
    if(this.noteFormGroup.invalid)
      return;
    
    const value = this.noteFormGroup.value;
    this.apiService.updateNote({
      id: this.note?.id!,
      text: value.text!,
      title: value.title!
    }).subscribe(_ => {
      this.router.navigate(['/']);
    });
  }

  onBack() {
    this.router.navigate(['/'])
  }
}
