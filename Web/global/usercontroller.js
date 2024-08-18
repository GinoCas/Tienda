import { GetHandler, PostHandler } from "../api/apicontroller.js";
import { UserModel } from "../models/usermodel.js";


export function GetUser(){
    return JSON.parse(localStorage.getItem('user_data')) || null;
}

export async function RegisterUser(formData){
    try{
        const data = Object.fromEntries(formData.entries());
        return await PostHandler('usuarios/register', data);
    }catch{
        return 0;
    }
}

export async function LoginUser(formData){
    try{
        const data = Object.fromEntries(formData.entries());
        return await PostHandler('usuarios/login', data);
    }catch{
        return 0;
    }
}

export function UserAuthenticated(){
    return localStorage.getItem('user_data') !== null;
}

export function UserAuthSave(data){
    try{
        const user = data.map(
            user => new UserModel(
                user.id,
                user.name,
                user.surname,
                user.email,
            )
        )[0];
        localStorage.setItem('user_data', JSON.stringify(user));
        return user;
    }catch{
        return null;
    }
}