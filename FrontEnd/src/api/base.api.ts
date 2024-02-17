import axios from "axios";

const baseURL = "https://localhost:7102"

export const baseAPI = axios.create({baseURL})

