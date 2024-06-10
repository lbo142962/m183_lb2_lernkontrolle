import axios from 'axios';
import { INote } from '../interfaces/INote';
import { IUser } from '../interfaces/IUser';

const apiUrl = "https://localhost:5001/api/";

export const getNoten = async (): Promise<INote[]> => {
    try {
        const url = apiUrl + "Note";
        const response = await axios.get(url);

        const noten = response.data as INote[];
        return noten;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error('Error fetching data:', error.message);
            return [];
        } else {
            console.error('Unexpected error:', error);
            return [];
        }
    }
}

export const postNote = async (note: INote): Promise<INote | undefined> => {
    try {
        const url = apiUrl + "Note";
        const response = await axios.post(url, note);

        const noteResult = response.data as INote;
        return noteResult;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error('Error fetching data:', error.message);
            return undefined;
        } else {
            console.error('Unexpected error:', error);
            return undefined;
        }
    }
}

export const putNote = async (noteId: number, note: INote): Promise<INote | undefined> => {
    try {
        const url = apiUrl + "Note/" + noteId;
        const response = await axios.put(url, note);

        const noteResult = response.data as INote;
        return noteResult;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error('Error fetching data:', error.message);
            return undefined;
        } else {
            console.error('Unexpected error:', error);
            return undefined;
        }
    }
}

export const deleteNote = async (noteId: number): Promise<string> => {
    try {
        const url = apiUrl + "Note/" + noteId;
        const response = await axios.delete(url);

        const successStatus = response.data as string;
        return successStatus;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error('Error fetching data:', error.message);
            return "false";
        } else {
            console.error('Unexpected error:', error);
            return "false";
        }
    }
}

export const getUsers = async (): Promise<IUser[]> => {
    try {
        const url = apiUrl + "User";
        const response = await axios.get(url);

        const users = response.data as IUser[];
        return users;
    } catch (error) {
        if (axios.isAxiosError(error)) {
            console.error('Error fetching data:', error.message);
            return [];
        } else {
            console.error('Unexpected error:', error);
            return [];
        }
    }
}
