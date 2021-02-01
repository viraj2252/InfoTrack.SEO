import React from "react";
import { Switch, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./App.css";

import CreateSearch from "./components/createSearch";

function App() {
  return (
    <div>
      <nav className="navbar navbar-expand navbar-dark bg-dark">        
        <div className="navbar-nav mr-auto">          
          <li className="nav-item">
            <Link to={"/search"} className="nav-link">
              Search
            </Link>
          </li>
        </div>
      </nav>

      <div className="container mt-3">
        <Switch>
          <Route exact path={["/", "/search"]} component={CreateSearch} />
        </Switch>
      </div>
    </div>
  );
}

export default App;
