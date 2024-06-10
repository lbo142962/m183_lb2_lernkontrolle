import { INote } from "./INote";

export interface IUser {
    id: number;
    upn: string;
    notenListe?: INote[];
}