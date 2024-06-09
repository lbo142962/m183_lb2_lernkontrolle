import { React, useState } from "react";
import Navbar from "./components/NavBarComponents/Navbar.tsx";
import Home from "./Home";
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom';

function App(){
  const [searchInput, setSearchInput] = useState('');
  const [filterSelection, setFilterSelection] = useState('');
  return (
    <Router>
    <div className="App">
      <Navbar 
      searchInput={searchInput}
      filterSelection ={filterSelection}
      setSearchInput = {setSearchInput}
      setFilterSelection = {setFilterSelection}
      />
      <h1 style={{textAlign: "center"}}>Search {searchInput}</h1>
      <div className="content">
        <Switch>
          <Route path ="/">
            <Home/>
          </Route>
        </Switch>
      </div>
    </div>
    </Router>
  );
}
export default App;