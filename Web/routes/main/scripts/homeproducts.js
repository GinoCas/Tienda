import { DeleteProductOfCar, GetCartItems, IsProductInCar } from "../../../global/cartitems.js";
import { GetProductList } from "../../../global/products.js";


const productContainer = document.getElementById('products-container');
let product_list = await GetProductList();

product_list.forEach(product =>{
    CreateProduct(product);
});

function CreateProduct(product){
    const article = document.createElement('article');
    const details = document.createElement('details');
    const summary = document.createElement('summary');
    const description = document.createElement('p');
    const footer = document.createElement('footer');
    const price = document.createElement('p')
    const stock_container = document.createElement('div');
    const stock = document.createElement('p');
    const cart_button = document.createElement('button'); 
    const cart_svg = document.createElement('svg');
    let fill_car = IsProductInCar(product) ? 'currentColor' : 'none';
    cart_svg.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="' +  fill_car + '" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-shopping-cart"><circle cx="8" cy="21" r="1"/><circle cx="19" cy="21" r="1"/><path d="M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12"/></svg>';

    article.appendChild(details);
    article.className = "product";

    details.appendChild(summary);
    details.appendChild(description);
    details.appendChild(footer);

    summary.appendChild(document.createTextNode(product.name));
    description.appendChild(document.createTextNode(product.description));
    price.appendChild(document.createTextNode('$' + product.price.toLocaleString('es-ES', {
        minimumFractionDigits: 4,
        maximumFractionDigits: 4
    })));
    price.className = "product-price"
    stock_container.appendChild(stock);
    stock_container.appendChild(cart_button);
    stock_container.className = "stock-container";
    footer.appendChild(price);
    footer.appendChild(stock_container);
    stock.appendChild(document.createTextNode(product.stock > 1 ? "En stock" : "Agotado"));
    cart_button.appendChild(cart_svg);
    
    productContainer.appendChild(article);

    cart_button.addEventListener('click', () => {
        fill_car = fill_car == 'none' ? 'currentColor' : 'none'
        cart_svg.querySelector('svg').setAttribute('fill', fill_car);
        let cart_items = GetCartItems();
        if (fill_car == 'none') {
            cart_items = DeleteProductOfCar(product);
        }else{
            cart_items.push(product);
        }
        localStorage.setItem("cart_items", JSON.stringify(cart_items));
    });
}