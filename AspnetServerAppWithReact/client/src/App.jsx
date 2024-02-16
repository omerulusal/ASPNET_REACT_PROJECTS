import { useState, useEffect } from 'react'
import RenderTable from './components/renderTable'
import Sabitler from './utils/Sabitler'
import PostCreate from './components/PostCreate'
import PostUpdate from './components/PostUpdate'

function App() {
  const [post, setPosts] = useState([])
  const [yeniGoster, setYeniGoster] = useState(false)
  const [guncelGoster, setGuncelGoster] = useState(null)

  useEffect(() => {
    const fetchData = () => {
      const url = `${Sabitler.API_URL_GET_ALL_POSTS}`;
      fetch(url, {
        method: 'GET'
      })
        .then(response => response.json())
        .then(dataFromServer => {
          console.log(dataFromServer)
          setPosts(dataFromServer)
        })
        .catch(err => console.log(err));
    }
    console.log(fetchData())
  }, [])

  const postuSil = (postId) => {
    const url = `${Sabitler.API_URL_DELETE_POST}/${postId}`;
    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(silServer => {
        console.log('Sunucudan gelen yanıt:', silServer);
        onPostSil(postId);
      })
      .catch(err => console.log('Hata:', err));
  }
  

  return (
    <div className='container ms-5  mt-5 mb-5 p-5 bg-light rounded shadow d-flex flex-column align-items-center justify-content-center'>
      {(yeniGoster === false && guncelGoster === null) && (
        <div>
          <h2>BASIC ASP.NET CORE REACT CRUD APP</h2>
          <div>
            <button onClick={() => post} className='btn btn-primary btn-sm me-2 mb-2'>GET POSTS</button>
            <button onClick={() => setYeniGoster(true)} className='btn btn-primary btn-sm me-2 mb-2'>CREATE POST</button>
          </div>
        </div>
      )}
      {post.length > 0 && !yeniGoster && !guncelGoster && <RenderTable post={post} setPosts={setPosts} setGuncelGoster={setGuncelGoster} onPostSil={onPostSil} postuSil={postuSil} />}
      {yeniGoster && <PostCreate onPostCreated={onPostCreated} />}
      {post.length > 0 && guncelGoster && <PostUpdate post={guncelGoster} onPostUpdated={onPostUpdated} />}
    </div>
  )

  function onPostCreated(postCreate) {
    if (postCreate === null) {
      return;
    }
    alert("Post Olusturuldu")
    setPosts([...post, postCreate])
  }

  function onPostUpdated(guncelle) {
    if (guncelle === null) {
      return;
    }
    let postKopya = []
    const index = postKopya.findIndex(post => post.postId === guncelle.postId)
    postKopya[index] = guncelle
    if (index !== -1) {
      postKopya[index] = guncelle
    }
    setPosts([...post, guncelle])
    alert("Post Guncellendi")
  }

  function onPostSil(silPostID) {
    let postSilindi = [...post]
    const index = postSilindi.findIndex((postSil, silPostID) => {
      if (postSil.postId === silPostID) {
        return true
      }
    });

    if (index !== -1) {
      postSilindi.splice(index, 1)
    }
    setPosts(postSilindi)
    alert("Post Silindi")
  }

}

export default App
