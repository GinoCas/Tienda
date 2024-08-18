import { RegisterUser, UserAuthSave } from "../../../global/usercontroller.js";

const form = document.getElementById('register-form');
const formError = document.getElementById('register-error');

localStorage.removeItem('user_data');

form.addEventListener('submit', async (event) => {
    event.preventDefault();
    const response = await RegisterUser(new FormData(form));
    if(response.ok){
        UserAuthSave((await response.json()).data);
        return window.location.href = '/routes/main/main.html';
    }
    const error_text = document.createElement('p');
    if(formError.hasChildNodes()){
        formError.removeChild(formError.firstChild);
    }
    formError.appendChild(error_text);
    formError.style = 'padding: 8px;'
    formError.classList.add('flash');
    setTimeout(() => {
        formError.classList.remove('flash');
    }, 100);

    if(response.status == 400){
        return error_text.textContent = 'El usuario ya existe.';
    }
    return error_text.textContent = "Error al conectarse con el servidor.";
});