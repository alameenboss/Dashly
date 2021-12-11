import { NoteCategory } from "./note-category.model";

export interface Note {
    id?: number;
    title: string;
    notes: string;
    noteCategoryId: number;
    category?: NoteCategory;
}