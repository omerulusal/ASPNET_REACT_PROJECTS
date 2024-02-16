/* eslint-disable react/prop-types */
import { useState } from 'react'
import Sabitler from '../utils/Sabitler'

const PostCreate = ({ onPostCreated }) => {
    const baslangicVerisi = Object.freeze({
        title: "Omer Ulusal",
        content: "C# ve react kullanarak yaptıgım basit bir CRUD projesi"
    });

    const [formVeri, setFormVeri] = useState(baslangicVerisi);
    const handleChange = (e) => {
        setFormVeri({
            ...formVeri,
            [e.target.name]: e.target.value
        })
    }

    const handleSubmit = (e) => {
        e.preventDefault()

        const postOlustur = {
            postId: 0,
            title: formVeri.title,
            content: formVeri.content
        }
        const url = `${Sabitler.API_URL_CREATE_POST}`
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postOlustur)
        })
            .then(response => response.json())
            .then(serverYaniti => {
                console.log(serverYaniti)
            })
            .catch(err => console.log(err));

        onPostCreated(postOlustur)
    }

    return (
        <div>
            <form className="form-group">
                <h1>Create New Post</h1>

                <div className="form-group">
                    <label className="form-label">Post Title</label>
                    <input type="text" className="form-control " value={formVeri.title} name="title" onChange={handleChange} required />
                </div>

                <div className="form-group">
                    <label className="form-label">Post Content</label>
                    <input type="text" className="form-control" value={formVeri.content} name="content" onChange={handleChange} required />
                </div>

                <button className="btn btn-primary btn-sm mt-2  me-2 mb-2" onClick={handleSubmit}>Create</button>
                <button className="btn btn-dark btn-sm me-2 mt-2 mb-2" onClick={() => onPostCreated(null)}>Cancel</button>

            </form>
        </div>
    )
}

export default PostCreate