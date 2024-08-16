const productContainer = document.getElementById('products-container');

const productos = [
    {
        Id: 1,
        Name: 'Producto 1',
        Description: 'Placeholder',
        Price: 10.00,
        Stock: 1
    }
];

function CreateProduct(){
    const article = document.createElement('article');

    const details = document.createElement('details').className = "products-container";
    const product = document.createElement('summary');
    const description = document.createElement('p');
    const stock = document.createElement('p');
    const footer = document.createElement('footer');

    article.appendChild(details);
    details.appendChild(product);
    details.appendChild(footer);
    product.appendChild(description.appendChild(document.createTextNode("Hola")));
    product.appendChild(stock.appendChild(document.createTextNode("5")));
    productContainer.appendChild(article);
}