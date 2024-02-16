import React from "react";
import "./addProduct.scss";
import { TextField, Button } from "@mui/material";
import { IProduct } from "../../types/global.typing";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { baseUrl } from "../../constant/url.constant";

const AddProduct: React.FC = () => {
    const [product, setProduct] = React.useState<Partial<IProduct>>({
        title: "",
        brand: "",
    });
    const redirect = useNavigate();

    const handleSaveBtnClick = () => {
        if (product.title === "" || product.brand === "") {
            alert("Lutfen Deger Giriniz");
            return;
        }

        const data: Partial<IProduct> = {
            brand: product.brand,
            title: product.title,
        };
        axios
            .post(baseUrl, data)
            .then((response) => {
                console.log(response.data);
                redirect("/products");
            })
            .catch((error) => {
                console.log(error);
            });
    };
    const handleBackBtnClick = () => {
        redirect("/products");
    };

    return (
        <div className="add-product">
            <h1>AddProduct</h1>
            <TextField
                autoComplete="off"
                value={product.brand}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                    setProduct({ ...product, brand: e.target.value })
                }
                label="Brand"
                variant="outlined"
            />
            <TextField
                autoComplete="off"
                value={product.title}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) =>
                    setProduct({ ...product, title: e.target.value })
                }
                label="Title"
                variant="outlined"
            />
            <div>
                <Button
                    variant="contained"
                    color="success"
                    style={{ marginRight: "10px" }}
                    onClick={handleSaveBtnClick}
                >
                    Save
                </Button>
                <Button
                    variant="contained"
                    color="warning"
                    onClick={handleBackBtnClick}
                >
                    Back
                </Button>
            </div>
        </div>
    );
};

export default AddProduct;
