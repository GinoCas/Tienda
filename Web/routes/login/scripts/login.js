import { LoginUser } from "../../../global/usercontroller.js";

const form = document.getElementById('login-form');
const formError = document.getElementById('login-error');

form.addEventListener('submit', async (event) => {
    event.preventDefault();
    const response = await LoginUser(new FormData(form));
    if(response.ok){
        return window.location.href = '/routes/main/main.html';
    }
    const error_text = document.createElement('p');
    if(formError.hasChildNodes()){
        formError.removeChild(formError.firstChild);
    }
    formError.appendChild(error_text);
    formError.style = 'padding: 8px;'

    if(response.status == 401){
        return error_text.textContent = 'Usuario o contraseña incorrecta.';
    }
    return error_text.textContent = "Error al conectarse con el servidor.";
});