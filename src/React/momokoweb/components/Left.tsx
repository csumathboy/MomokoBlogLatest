import Link from 'next/link'
import { getPostsByClassId } from '@/lib/api';
import { Suspense } from 'react'

async function Postlists() {
	// 等待 playlists 数据
	const latestPosts = await getPostsByClassId("","creationTime");
	const arrays = Object.entries(latestPosts);

	return (
		<ul>				
		 {arrays.map(([id, post]) => {
          const { postid,title} = JSON.parse(post);
          return <li  key={id}>
				<Link href={`/post/${postid}`}  rel="bookmark">{title}</Link>

			</li>
		  })}		 
	   </ul>
	)
  }

export default async function Left() {
  const hotPosts = await getPostsByClassId("","Sort");
  const arrays = Object.entries(hotPosts);
  return (
    <div id="secondary" className="widget-area clearfix" role="complementary">
			<aside id="search-2" className="widget clearfix widget_search"><form role="search" method="get" className="search-form" action="https://momoko.chouxiangpai.com/">
						<label>
							<span className="screen-reader-text">搜索：</span>
							<input type="search" className="search-field" placeholder="搜索&hellip;" value="" name="s" />
						</label>
						<input type="submit" className="search-submit" value="搜索" />
					</form></aside>		<aside id="recent-posts-2" className="widget clearfix widget_recent_entries">		<h4 className="widget-title"><span>近期文章</span></h4>		
					<Suspense fallback={<div>Loading...</div>}>
						<Postlists />
					</Suspense>
				</aside>
				
					<aside id="recent-comments-2" className="widget clearfix widget_recent_comments">
					<h4 className="widget-title"><span>热门文章</span></h4>
					<ul id="recentcomments">				
						{arrays.map(([id, post]) => {
						const { postid,title} = JSON.parse(post);
						return <li  key={id}>
								<Link href={`/post/${postid}`}  rel="bookmark">{title}</Link>

							</li>
						})}		 
					</ul>
					</aside>
				</div>
  );
}
