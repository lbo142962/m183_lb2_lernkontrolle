import React from "react"
export interface IFilm {
    "name": string,
    "synopsis": string,
    "length": number,
    "rating": number,
    "releaseYear": number
}
export interface IActor {
    "FirstName": string,
    "LastName": string,
    "Age": number,
    "Credits": string,
    "Biography": string
}

export interface IDirector{
    "FirstName": string,
    "LastName": string,
    "Age": number,
    "Credits": string,
    "Biography": string
}

export interface IAPIAllRequest {

    films: IFilm[] | undefined,
    actors: IActor[] | undefined,
    directors: IDirector[] | undefined
}
export interface IPersonList {

    Vorname: string
    Nachname: string
    Synopsis: string
}
export interface IFilmlist{
    name: string,
    releaseYear: number,
    rating: number

}
export interface INavbarProps {
    searchInput: string
    filterSelection: string
    setSearchInput: React.Dispatch<React.SetStateAction<string>>,
    setFilterSelection: React.Dispatch<React.SetStateAction<string>>,

}