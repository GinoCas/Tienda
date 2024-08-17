import { PostHandler } from "../api/apicontroller.js";
import { UserModel } from "../models/usermodel.js";


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