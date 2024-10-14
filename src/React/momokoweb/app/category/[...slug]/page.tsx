import Left from '@/components/Left';
import { getPostsByClassId } from '@/lib/api';
import PostList from '@/components/PostList';

export default async function Category({ params }) {
  const posts = await getPostsByClassId(params.slug[1]);
    return (
        <main id="main" className="site-main clearfix">
		<div className="container">
			<div id="primary" className="content-area clearfix" role="main">
            <header className="page-header clearfix"><h1 className="page-title">分类：{decodeURI(params.slug[0])}</h1></header>
			<div className="post-container">
      <PostList posts={posts} />
			</div>
			<nav className="navigation pagination" role="navigation" aria-label="文章">
					<h2 className="screen-reader-text">文章导航</h2>
							<div className="nav-links"><span aria-current="page" className="page-numbers current">1</span>
					<a className="page-numbers" href="https://momoko.chouxiangpai.com/page/2/">2</a>
					<span className="page-numbers dots">&hellip;</span>
					<a className="page-numbers" href="https://momoko.chouxiangpai.com/page/22/">22</a>
					<a className="next page-numbers" href="https://momoko.chouxiangpai.com/page/2/">下一个</a></div>
			</nav>
		</div>
    <Left/>
	</div>
  </main>
  );
}