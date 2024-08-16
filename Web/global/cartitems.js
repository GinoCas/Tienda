import { ProductModel } from "../../../models/productmodel.js";

export function GetCartItems(){
    const data = JSON.parse(localStorage.getItem("cart_items")) || [];
    return data.map(
        product => new ProductModel(
            product.id,
            product.name,
            product.code,
            product.description,
            product.price,
            product.stock
        )
    );
}

export function IsProductInCar(product){
    return GetCartItems().some((item) => item.id == product.id)
}

export function DeleteProductOfCar(product){
    return GetCartItems().reduce((current_array, item) => {
        if(item.id != product.id){
            current_array.push(item);
        }
        return current_array;
    }, []);
}