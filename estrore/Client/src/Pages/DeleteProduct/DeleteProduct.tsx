import React from 'react'
import "./deleteProduct.scss"
import { useNavigate, useParams } from 'react-router-dom';
import axios from 'axios';
import { baseUrl } from '../../constant/url.constant';
import { Button } from '@mui/material';



const DeleteProduct: React.FC = () => {

    const redirect = useNavigate();
    const { id } = useParams();

    const handleDelete = () => {
        axios
            .delete(`${baseUrl}/${id}`)
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
        <div>
            <h1>Delete Product</h1>
            <Button
                variant="contained"
                color="success"
                style={{ marginRight: "10px" }}
                onClick={handleDelete}
            >
                Yes Delete
            </Button>
            <Button
                variant="contained"
                color="warning"
                onClick={handleBackBtnClick}
            >
                Back
            </Button>
        </div>
    )
}

export default DeleteProduct