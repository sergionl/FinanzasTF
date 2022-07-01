import axios, { AxiosResponse } from "axios";


// axios.defaults.baseURL = "https://localhost:5001/api/";
axios.defaults.baseURL = "https://finance-bonera.herokuapp.com/api/";


const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const request = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  delete: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

export default request;
