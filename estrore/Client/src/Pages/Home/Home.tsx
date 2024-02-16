import React from 'react'
import "./home.scss"
import { Button } from '@mui/material'
import { useNavigate } from 'react-router-dom';
const Home: React.FC = () => {
    const redirect = useNavigate();
    return (
        <div>
            <h1>Welcome to Store</h1>
            <Button variant="outlined" color="primary" onClick={() => redirect("/products")}>
                Products List
            </Button>
        </div>
    )
}

export default Home