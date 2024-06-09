import { useState,useEffect } from 'react';
import React from 'react';
import PersonList from './SinglePage/PersonList';
import axios, {AxiosResponse} from 'axios';
import { IAPIAllRequest, IFilm } from './../../../Interfaces';
import Navbar from "./../Navbar/Navbar";
import SearchPage from './searchPage';

const Page = () => {
    const [searchInput, setSearchInput] = useState('');
    const [filterSelection, setFilterSelection] = useState('');
    const [APIData, setAPIData] = useState<IAPIAllRequest>();

    useEffect(() => {
        axios
        .get<IAPIAllRequest>('https://localhost:5001/api/Films/FilmsearchByLength/269/271')
        .then((response: AxiosResponse) => {
            setAPIData(response.data)
        } );
      }, []);

      function filterSelectionFunction(): React.ReactNode{
        if (filterSelection === 'ALL') {
            return         <PersonList
            Vorname='Test'
            Nachname='Test'
            Synopsis='Bla Bla' />            
        }
        return <h1>Hallo</h1>
      }
    return ( 
        <>
        <div>
        <Navbar 
    searchInput={searchInput}
    filterSelection ={filterSelection}
    setSearchInput = {setSearchInput}
    setFilterSelection = {setFilterSelection}
    />    
    </div>
    <div>
        <h1>{searchInput}</h1>
        <SearchPage
        films={APIData?.films}
        actors={APIData?.actors}
        directors={APIData?.actors}
        />
    </div>
        </>
     );
}

export default Page;