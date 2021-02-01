import axios from "axios";

export default axios.create({
  baseURL: "https://localhost:44369/api",
  headers: {
    "Content-type": "application/json"
  }
});