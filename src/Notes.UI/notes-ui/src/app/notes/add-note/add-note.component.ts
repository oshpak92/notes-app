import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotesApiService } from '../../services/notes-api/notes-api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrl: './add-note.component.scss'
})
export class AddNoteComponent implements OnInit {
  titleControl = new FormControl<string|null>(null, [Validators.required]);
  textControl = new FormControl<string|null>(null, [Validators.required]);
  addNoteFormGroup =  new FormGroup({
    title: this.titleControl,
    text: this.textControl
  });
  
  constructor(private router: Router, private apiService: NotesApiService){
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if(this.addNoteFormGroup.invalid)
      return;

    const value = this.addNoteFormGroup.value;
    this.apiService.createNote({
      title: value.title!,
      text: value.text!,
    }).subscribe(_ => {
      this.router.navigate(["/"]);
    });
  }
}
