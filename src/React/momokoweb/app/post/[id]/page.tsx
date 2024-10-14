import Image from 'next/image'
import Left from '@/components/Left';
import Link from 'next/link';
import dayjs from 'dayjs';
import { getPostById } from '@/lib/api';

export  default async function Post({ params }: { params: { id: string } }) {
	const post = await getPostById(params.id);
    return (
        <main id="main" className="site-main clearfix">
		<div className="container">
		<div id="primary" className="content-area clearfix" role="main">

		<article id="post-653" className="post-653 post type-post status-publish format-standard has-post-thumbnail hentry category-chrysanthemum tag-6">
			<div className="post-media clearfix">
                <Image width="1920" height="2560" src={`${post.picture}`} className="attachment-full size-full wp-post-image" alt=""   sizes="(max-width: 1920px) 100vw, 1920px" /></div> 
			<header className="entry-header clearfix">
				<h1 className="entry-title">{post.title}</h1>
			</header>
								
			<div className="entry-content clearfix">
				
		<p>{post.description}</p>
		<div className="cat-links taxonomy-wrap">
			<span className="taxonomy-wrap-title">Posted In: </span>
			<Link href={`/category/${post.classname}/${post.classid}`}  rel="category tag">{post.classname}</Link>
		  </div> 
	     <div className="tag-links taxonomy-wrap">
				<span className="taxonomy-wrap-title">Tagged In: </span>
				<Link href={`/tag/${post.tagname}`}  rel="tag">{post.tagname}</Link>
				</div> 
			</div> 
								
			<footer className="entry-footer clearfix">
				<div className="date-meta">{dayjs(post.addtime).format('YYYY-MM-DD hh:mm:ss')}</div>
			</footer>
			
		</article>
		</div>


		<Left />
	 </div>
	</main> 
    );
}