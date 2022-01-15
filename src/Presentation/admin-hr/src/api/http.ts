import axios, { AxiosInstance } from "axios";
import { API_URL } from "../utils/constants";
import https from "https";

const http: AxiosInstance = axios.create({
  httpsAgent: new https.Agent({
    rejectUnauthorized: false,
  }),
  baseURL: API_URL,
  headers: {
    "Content-type": "application/json",
  },
});

export default http;
