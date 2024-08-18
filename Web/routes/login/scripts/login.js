import { LoginUser, UserAuthSave } from "../../../global/usercontroller.js";

const form = document.getElementById('login-form');
const formError = document.getElementById('login-error');

localStorage.removeItem('user_data');

form.addEventListener('submit', async (event) => {
    event.preventDefault();
    localStorage.removeItem('user_data');
    const user = new FormData(form);
    let response = await LoginUser(user);
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

    if(response.status == 401){
        return error_text.textContent = 'Usuario o contraseña incorrecta.';
    }
    return error_text.textContent = "Error al conectarse con el servidor.";
});