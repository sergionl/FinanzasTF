import { Bono } from "../models/bono";
import request from "./api";


const apiBonos = {
    list: () => request.get<Bono[]>("Bono/GetAllByFilter"),
    add: (data: Bono)=> request.post(`Bono/Post`,data),
    edit: (data: Bono) => request.put(`Bono/${data.id}`, data), 
    delete: (id: number) => request.delete(`Bono/Delete?id=${id}`),
    detail: (id: string) => request.get<Bono>(`Bono/GetItemById?id=${id}`),
    
};

export default apiBonos;
