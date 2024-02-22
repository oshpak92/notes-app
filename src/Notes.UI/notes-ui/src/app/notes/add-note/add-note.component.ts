import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormControl, FormGroup } from '@angular/forms';
import { NotesApiService } from '../../services/notes-api/notes-api.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrl: './add-note.component.scss'
})
export class AddNoteComponent implements OnInit {
  addNoteFormGroup!: FormGroup;
  
  constructor(private router: Router,private apiService: NotesApiService, private location: Location){
  }

  ngOnInit(): void {
    this.addNoteFormGroup = new FormGroup({
      title: new FormControl(),
      text: new FormControl()
    });
  }

  onSubmit() {
    const value = this.addNoteFormGroup.value;
    this.apiService.createNote({
      title: value.title,
      text: value.text,
    }).subscribe(_ => {
      this.router.navigate(["/"]);
    });
  }
}
