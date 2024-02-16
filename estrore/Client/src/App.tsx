import React from "react"
import Navbar from "./components/Navbar/Navbar"
import { Route, Routes } from "react-router-dom"
import Home from "./Pages/Home/Home"
import Products from "./Pages/Porducts/Products"
import AddProduct from "./Pages/AddProduct/AddProduct"
import EditProducts from "./Pages/EditProducts/EditProducts"
import DeleteProduct from "./Pages/DeleteProduct/DeleteProduct"

const App: React.FC = () => {
  return (
    <div>
      <Navbar />
      <div className="wrapper">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/products">
            <Route index element={<Products />} />
            <Route path="add" element={<AddProduct />} />
            <Route path="edit/:id" element={<EditProducts />} />
            <Route path="delete/:id" element={<DeleteProduct />} />
          </Route>
        </Routes>
      </div>
    </div>
  )
}

export default App
