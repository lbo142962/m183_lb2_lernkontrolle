import { IUser } from "./IUser";

export interface INote {
    id: number;
    userId: number;
    value: string;
    description: string;
    user?: IUser;
}