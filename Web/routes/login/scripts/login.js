import { LoginUser } from "../../../global/usercontroller.js";

const form = document.getElementById('login-form');

form.addEventListener('submit', async (event) => {
    event.preventDefault();
    const response = await LoginUser(new FormData(form));
    console.log(response);
});