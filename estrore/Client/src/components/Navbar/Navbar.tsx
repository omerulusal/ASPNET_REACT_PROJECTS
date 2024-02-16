import React from 'react'
import "./navbar.scss"
import MenuIcon from '@mui/icons-material/Menu';
import { Link } from 'react-router-dom';

const Navbar: React.FC = () => {
    return (
        <div className='navbar'>
            <div className="brand">Store RTS.NET</div>
            <div className="hamburger"><MenuIcon /></div>
            <div className="menu">
                <ul>
                    <li>
                        <Link to="/">Home</Link>
                        <Link to="/products">Products</Link>
                        <Link to="/products/add">Add Product</Link>
                    </li>
                </ul>
            </div>
        </div>
    )
}

export default Navbar