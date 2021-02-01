import http from "../http-common";


const createSearch = data => {
  return http.post("/Search", data);
};

export default {
    createSearch
};