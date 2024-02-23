export interface IdItem {
    id: number;
}

export interface Note extends IdItem{
    title: string;
    text: string;
    createdDate: string;
    modifiedDate: string;
}

export interface NotesResponse {
    notes: Note[];
    notesCount: number;
}

export interface CreateNote {
    title: string;
    text: string;
}

export interface UpdateNote extends IdItem {
    title: string;
    text: string;
}

export interface CreateNoteResponse extends IdItem {}
export interface UpdateNoteResponse extends IdItem {}