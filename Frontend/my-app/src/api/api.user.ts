import { User } from "../models/user";
import request from "./api";
//import authService from "./auth/auth.service";

const apiUsers = {
    add: (data: User)=> request.post(`User/Post`,data),
    edit: (data: User) => request.put(`User/Put`, data), //Pa dsps
    delete: (id: number) => request.delete(`User/Delete?id=${id}`),
    profile: (id: string) => request.get<User>(`User/GetItemById?id=${id}`),
    login: (email: string) => request.get<User>(`User/GetItemByEmail?email=${email}`),
};

export default apiUsers;