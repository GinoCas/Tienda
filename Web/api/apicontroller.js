const API_URL = 'http://localhost:5047/';

export async function GetHandler(route){
    const response = await fetch(API_URL + route);
    return response.json();
}

export async function PostHandler(route, data){
    return await fetch(API_URL + route, {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data),
    });
}