import { GetHandler } from "../../../api/apicontroller.js";
import { ProductModel } from "../../../models/productmodel.js";

export async function GetProductList(){
    try{
        const data = await GetHandler('productos');
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
    }catch{
        return [];
    }
}