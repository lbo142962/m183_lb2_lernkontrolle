import PersonList from "./SinglePage/PersonList";
import FilmList from "./SinglePage/FilmList";
import { useState } from 'react';
import React from 'react';
import { IAPIAllRequest } from "../../../Interfaces";

const SearchPage = (props: IAPIAllRequest) =>  {
    const selectOutput = (searchResultAPi: IAPIAllRequest) =>{
        if (searchResultAPi.actors !== undefined) {
            return(
                <>
                            <div className="filmList">
                <h1>Actor</h1>
            </div>
            searchResultAPi.actors.forEach((actor) => {
                <PersonList
            Vorname={actor.FirstName}
            Nachname={actor.LastName}
            Synopsis={actor.Biography} />  
            })  
                </>

            );
          
        }
        else if (searchResultAPi.directors !== undefined) {
            <div className="filmList">
                <h1>Actor</h1>
            </div>
        searchResultAPi.directors.forEach((directors) => {
            <PersonList
        Vorname={directors.FirstName}
        Nachname={directors.LastName}
        Synopsis={directors.Biography} />  
        })        
        }
        else if (searchResultAPi.films !== undefined) {
            <div className="filmList">
                <h1>Actor</h1>
            </div>
        searchResultAPi.films.forEach((film) => {
            return             <FilmList
            name = {film.name}
            releaseYear = {film.releaseYear}
            rating= {film.rating}

        />  
        })        
        }
        else {


        }
            
    }
    return (
        <>
        
        </>
    );
}
export default SearchPage;