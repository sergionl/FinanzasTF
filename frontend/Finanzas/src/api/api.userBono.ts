import { userBono } from "../models/user-bono";
import request from "./api";
//import authService from "./auth/auth.service";

const apiUserBonos = {
    add: (data: userBono)=> request.post(`UserBono/`,data),
    delete: (userId: number,bonoId: number) => request.delete(`UserBono/Delete?userId=${userId}&bonoId=${bonoId}`),
    detail: (id: string) => request.get<userBono>(`UserBono/GetItemById?id=${id}`),
    
};

export default apiUserBonos;
