import axios from "axios";
import { baseUrl } from "../constants/urlContanst";

const httpModule = axios.create({
    baseURL: baseUrl,
});

export default httpModule;