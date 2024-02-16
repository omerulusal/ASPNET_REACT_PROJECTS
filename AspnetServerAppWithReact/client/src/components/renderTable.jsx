/* eslint-disable react/prop-types */
const RenderTable = ({ post, setPosts, setGuncelGoster, postuSil }) => {
    console.log(post, "verilerr")


    return (
        <div>
            <table className="table">
                <thead>
                    <tr>
                        <th scope="col">PostId(PK)</th>
                        <th scope="col">Title</th>
                        <th scope="col">Content</th>
                        <th scope="col">CRUD</th>
                    </tr>
                </thead>
                <tbody>
                    {post.map((post, index) => (
                        <tr key={index}>
                            <th scope="row">{post.postId}</th>
                            <td>{post.title}</td>
                            <td>{post.content}</td>
                            <td>
                                <button onClick={() => setGuncelGoster(post)} className="btn btn-primary btn-sm me-2 mb-2 ">Update</button>
                                <button onClick={() => postuSil(post.postId)} className="btn btn-primary btn-sm me-2 mb-2">Delete</button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
            <button onClick={() => setPosts([])} className="btn btn-primary btn-sm me-2 mb-2" >Empty React Posts Array</button>
        </div>
    )
}

export default RenderTable