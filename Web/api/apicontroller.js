const API_URL = 'http://localhost:5047';

export async function GetHandler(route){
    const response = await fetch(API_URL + route);
    return response.json();
}