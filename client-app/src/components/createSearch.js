import React, { useState } from "react";
import SearchDataService from "../services/searchService";

const CreateSearch = () => {
  const initialSearchState = {
    keywords: null,
    occurrences: [],
    url: "",
    searchEngine: "Google",
    published: false
  };
  const [search, setSearch] = useState(initialSearchState);
  const [submitted, setSubmitted] = useState(false);

  const handleInputChange = event => {
    const { name, value } = event.target;
    setSearch({ ...search, [name]: value });
  };

  const saveSearch = () => {
    var data = {
      keywords: search.keywords,
      url: search.url,
      searchEngine: search.searchEngine
    };

    SearchDataService.createSearch(data)
      .then(response => {
        setSearch({
          occurrences: response.data.occurrences,
          url: response.data.url,
          searchEngine: response.data.searchEngine
        });
        setSubmitted(true);
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  };

  const newTutorial = () => {
    setSearch(initialSearchState);
    setSubmitted(false);
  };

  return (
    <div className="submit-form">
      {submitted ? (
        <div>
          <h4>Occurrences of your search</h4>
          <div>{search.occurrences}</div>
          <button className="btn btn-success" onClick={newTutorial}>
            Search Again
          </button>
        </div>
      ) : (
        <div>
          <div className="form-group">
            <label htmlFor="keywords">Keywords</label>
            <input
              type="text"
              className="form-control"
              id="keywords"
              required
              value={search.keywords}
              onChange={handleInputChange}
              name="keywords"
            />
          </div>

          <div className="form-group">
            <label htmlFor="url">URL</label>
            <input
              type="text"
              className="form-control"
              id="url"
              required
              value={search.url}
              onChange={handleInputChange}
              name="url"
            />
          </div>

          <div className="form-group">
            <label htmlFor="searchEngine">Search Engine</label>
            <input
              type="text"
              className="form-control"
              id="searchEngine"
              required
              value={search.searchEngine}
              onChange={handleInputChange}
              name="searchEngine"
            />
          </div>

          <button onClick={saveSearch} className="btn btn-success">
            Submit
          </button>
        </div>
      )}
    </div>
  );
};

export default CreateSearch;