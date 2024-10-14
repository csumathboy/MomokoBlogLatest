import { getPostsByClassId } from '@/lib/api';
import PostList from '@/components/PostList';
 

export  default async  function Home() {
  const posts = await getPostsByClassId();
  return (
<main id="main" className="site-main clearfix">
		<div className="container">
			<div id="primary"  className="clearfix" role="main" >
        <div className="hidden"> </div>
			<div className="post-container">
        <PostList posts={posts} />
          
			</div>
			 
		</div>
    
	</div>
</main>
  );
}
