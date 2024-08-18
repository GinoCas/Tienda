import { DeleteProductOfCar, GetCartItems } from "../../../global/cartitems.js";
import { GetProductList } from "../../../global/productcontroller.js";

const productContainer = document.getElementById('products-container');
const summaryProducts = document.getElementById('summary-products');
const totalContainer = document.getElementById('total-container');

let items_prices = [];
let product_list = await GetProductList();
let cart_items = [];

GetCartItems().forEach(cart_item => {
    product_list.forEach(product => {
        if(product.id == cart_item.id){
            CreateProduct(product);
            cart_items.push(product);
        }else{
            DeleteProductOfCar(product);
        }
    })
    localStorage.setItem("cart_items", JSON.stringify(cart_items));
});

UpdateTotalOnSummary();

function CreateProduct(product){
    const article = document.createElement('article');
    const name = document.createElement('p');
    const price_container = document.createElement('div');
    const price = document.createElement('p');
    const input_container = document.createElement('div');
    const stock_input = document.createElement('input')
    const cross_button = document.createElement('button');
    const cross_svg = document.createElement('svg');
    cross_svg.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="lucide lucide-x"><path d="M18 6 6 18"/><path d="m6 6 12 12"/></svg>';

    article.appendChild(name);
    article.appendChild(price_container);
    article.className = "product";

    name.textContent = product.name;
    name.className = 'product-name';

    price_container.appendChild(price);
    price_container.appendChild(input_container);
    price_container.className = 'price-container';

    price.textContent = '$' + product.price.toLocaleString('es-ES', {
        minimumFractionDigits: 4,
        maximumFractionDigits: 4
    });

    input_container.appendChild(stock_input);
    input_container.appendChild(cross_button);
    input_container.style = 'display: flex; align-items: center; gap:20px;';

    stock_input.type = 'number';
    stock_input.min = 1;
    stock_input.max = product.stock;
    stock_input.value = 1;
    items_prices.push([product.id, product.price]);
    CreateProductOnSummary(product, stock_input.value);

    cross_button.appendChild(cross_svg);

    productContainer.appendChild(article);

    stock_input.addEventListener('change', () => {
        stock_input.value = Math.max(stock_input.value, stock_input.min)
        stock_input.value = Math.min(stock_input.max, Math.floor(stock_input.value));
        UpdateProductOnSummary(product.id, stock_input.value);
        items_prices.forEach(item => {
            if(item[0] == product.id){
                item[1] = product.price * stock_input.value;
            } 
        });
        UpdateTotalOnSummary();
    });
    cross_button.addEventListener('click', () =>{
        localStorage.setItem("cart_items", JSON.stringify(DeleteProductOfCar(product)));
        productContainer.removeChild(article);
        summaryProducts.removeChild(document.getElementById('product-' + product.id));
        items_prices = DeleteFromTotal(product.id);
        UpdateTotalOnSummary();
    });
}

function CreateProductOnSummary(product, product_quantity){
    const article = document.createElement('article');
    const name = document.createElement('span');
    const quantity = document.createElement('span');

    article.appendChild(name);
    article.appendChild(quantity);
    article.className = 'flex-align-center font-semibold';
    article.style = 'justify-content: space-between;';
    article.id = 'product-' + product.id;

    name.textContent = product.name;
    quantity.textContent = 'x' + product_quantity

    summaryProducts.appendChild(article);
}

function UpdateProductOnSummary(product_id, product_quantity){
    const article = document.getElementById('product-' + product_id);
    article.querySelector('span:last-child').textContent = 'x' + product_quantity;
}

function DeleteFromTotal(product_id){
    return items_prices.reduce((current_array, item) => {
        if(item[0] != product_id){
            current_array.push(item);
        }
        return current_array;
    }, []);
}

function UpdateTotalOnSummary(){
    let total = 0;
    items_prices.forEach(item => {
        total += item[1];
    });
    totalContainer.querySelector('h3').textContent = 'Total: $' + total.toLocaleString('es-ES', {
        minimumFractionDigits: 4,
        maximumFractionDigits: 4
    });
}