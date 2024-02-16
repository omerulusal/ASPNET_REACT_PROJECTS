import { useState } from 'react'
import Sabitler from '../utils/Sabitler'

const PostCreate = ({ post, onPostUpdated }) => {
    const baslangicVerisi = Object.freeze({
        title: post.title,
        content: post.content
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

        const postGuncel = {
            postId: post.postId,
            title: formVeri.title,
            content: formVeri.content
        }
        const url = `${Sabitler.API_URL_UPDATE_POST}`
        
        fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postGuncel)
        })
            .then(response => response.json())
            .then(serverYaniti => {
                console.log(serverYaniti)
            })
            .catch(err => console.log(err));

        onPostUpdated(postGuncel)
    }

    return (
        <div>
            <form className="form-group">
                <h1>Update Post {formVeri.postId}</h1>

                <div className="form-group">
                    <label className="form-label">Post Title</label>
                    <input type="text" className="form-control " value={formVeri.title} name="title" onChange={handleChange} required />
                </div>

                <div className="form-group">
                    <label className="form-label">Post Content</label>
                    <input type="text" className="form-control" value={formVeri.content} name="content" onChange={handleChange} required />
                </div>

                <button className="btn btn-primary btn-sm mt-2  me-2 mb-2" onClick={handleSubmit}>Create</button>
                <button className="btn btn-dark btn-sm me-2 mt-2 mb-2" onClick={() => onPostUpdated(null)}>Cancel</button>

            </form>
        </div>
    )
}

export default PostCreate