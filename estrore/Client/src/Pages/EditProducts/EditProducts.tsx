import React from "react";
import "./editProducts.scss";
import { Button, TextField } from "@mui/material";
import { IProduct } from "../../types/global.typing";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
import { baseUrl } from "../../constant/url.constant";
const EditProducts: React.FC = () => {
    const [product, setProduct] = React.useState<Partial<IProduct>>({
        title: "",
        brand: "",
    });
    const redirect = useNavigate();

    const { id } = useParams();

    const handleSaveBtnClick = () => {
        if (product.title === "" || product.brand === "") {
            alert("Lutfen Deger Giriniz");
            return;
        }
        const data: Partial<IProduct> = {
            brand: product.brand,
            title: product.title,
        }; //hali hazırda bulunan verileri yeni veriler ile degistiriyorum
        axios
            .put(`${baseUrl}/${id}`, data)
            .then((response) => {
                console.log(response.data);
                redirect("/products");
            })
            .catch((error) => {
                console.log(error);
            });
        // Inputlardaki dataları baseurl(api) e yolluyorum
    };

    const handleBackBtnClick = () => {
        redirect("/products");
    };

    React.useEffect(() => {
        axios
            .get<IProduct>(`${baseUrl}/${id}`)
            .then((response) =>
                setProduct({
                    title: response.data.title,
                    brand: response.data.brand,
                })
            )
            .catch((error) => console.log(error));
    }, []);

    return (
        <div className="edit-product">
            <h1>Edit Product</h1>

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

export default EditProducts;
