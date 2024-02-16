import React, { useState, useEffect } from "react";
import "./products.scss";
import { IProduct } from "../../types/global.typing";
import axios from "axios";
import { baseUrl } from "../../constant/url.constant";
import { Button } from "@mui/material";
import { Edit, Delete } from "@mui/icons-material";
import moment from "moment";
import { useNavigate } from "react-router-dom";
const Products: React.FC = () => {
    const [products, setProducts] = useState<IProduct[]>([]);
    // IProduct[] ile Urunlerin bir dizisini tutacagını belirttim

    const fetchPrdouctList = async () => {
        try {
            const response = await axios.get<IProduct[]>(`${baseUrl}`);
            setProducts(response.data);
        } catch (error) {
            console.log(error);
        }
    };
    const redirect = useNavigate()

    useEffect(() => {
        fetchPrdouctList();
    }, []);

    console.log(products);

    return (
        <div>
            <h1>Products List</h1>
            {products.length === 0 ? (
                <h1>No Products</h1>
            ) : (
                <div>
                    <table>
                        <thead>
                            <tr>
                                <th>Product Brand</th>
                                <th>Product Title</th>
                                <th>Creation Time</th>
                                <th>Update Time</th>
                                <th>Operations</th>
                            </tr>
                        </thead>
                        <tbody>
                            {products.map((urun) => (
                                <tr key={urun.id}>
                                    <td>{urun.brand}</td>
                                    <td>{urun.title}</td>
                                    <td>{moment(urun.createdAt).fromNow()}</td>
                                    <td>{moment(urun.updatedAt).fromNow()}</td>
                                    <td>
                                        <Button
                                            variant="outlined"
                                            color="warning"
                                            sx={{ mx: 2 }}
                                            onClick={() => redirect(`/products/edit/${urun.id}`)}
                                        >
                                            <Edit />
                                        </Button>
                                        <Button
                                            variant="outlined"
                                            color="error"
                                            onClick={() => redirect(`/products/delete/${urun.id}`)}
                                        >
                                            <Delete />
                                        </Button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
        </div>
    );
};

export default Products;
