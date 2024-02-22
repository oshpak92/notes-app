export interface Note {
    id: number;
    title: string;
    text: string;
    createdDate: string;
    modifiedDate: string;
}

export interface NotesResponse {
    notes: Note[];
    notesCount: number;
}

export interface CreaNote {
    title: string;
    text: string;
}

export interface CreateNoteResponse {
    id: number;
    title: string;
    text: string;
    createdDate: string;
    modifiedDate: string;
}