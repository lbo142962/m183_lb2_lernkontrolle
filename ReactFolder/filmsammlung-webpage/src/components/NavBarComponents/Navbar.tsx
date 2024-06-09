import { useState } from 'react';
import React from 'react';
import './Navbar.css';
import { INavbarProps } from '../INavbarProps';

const Navbar = (props: INavbarProps) => {

    return ( 
        <nav className="navbar">
            <form>
                <select
                value={props.filterSelection}
                onChange={(e) => props.setFilterSelection(e.target.value)}
                >
                    <option value="All">All</option>
                    <option value="Film">Film</option>
                    <option value="Actors">Actors</option>
                    <option value="Directors">Directors</option>
                </select>
                <input 
                name='serachfieldInput' 
                type="text" placeholder='Search...' 
                value={props.searchInput} 
                onChange={e => props.setSearchInput(e.target.value)} />
                <button type='submit'>Search</button>
            </form>
            <div className="links">
                <div className='searchbar'>   
                <p>Create a new Film</p>
                <button className='plus'></button>
                <button style={{borderRadius: 15}}>Sign In</button>
                <button>Profile</button>
                </div>
            </div>
        </nav>
     );
}
export default Navbar;