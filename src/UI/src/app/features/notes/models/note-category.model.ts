import { Note } from "./note.model";

export interface NoteCategory {
    id?: number;
    name: string;
    noteCategoryId?: number;
    notes?: Note[];
    categories?: NoteCategory[];
}
