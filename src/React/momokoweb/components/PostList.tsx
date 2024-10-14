import Image from 'next/image'
import Link from 'next/link';
import dayjs from 'dayjs';
 
export default async function PostList({posts}) {
  const arr = Object.entries(posts);

  if (arr.length == 0) {
    return <div className="notes-empty">
      {'No notes created yet!'}
    </div>
  }

  return <ul>
    {arr.map(([id, post]) => {
    const { postid,title, description,picture,addtime } = JSON.parse(post);
    return <li  key={id}>
    <article    className="grid-item   post type-post status-publish format-standard has-post-thumbnail hentry category-chrysanthemum tag-4">
     <div className="post-media clearfix">
      <Link href={`/post/${id}`}  className="thumb-link">
       <Image width="470" height="353" src={`${picture}`} className="attachment-post-thumbnail size-post-thumbnail wp-post-image" alt=""   sizes="(max-width: 470px) 100vw, 470px" /></Link></div> 
     <header className="entry-header clearfix">
       <h3 className="entry-title">
       <Link href={`/post/${postid}`}  rel="bookmark">{title}</Link></h3>
     </header>
     
     <div className="entry-summary clearfix">
       <p>{description}</p>
     </div> 
     
     <footer className="entry-footer clearfix">
       <div className="date-meta">{dayjs(addtime).format('YYYY-MM-DD hh:mm:ss')}</div>
     </footer> 
     
   </article>
    </li>
     
  })}
  </ul>

        
}