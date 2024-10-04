import Image from 'next/image'
export default function Post({ params }: { params: { slug: string } }) {
    return (
        <main id="main" className="site-main clearfix">
		<div className="container">
		<div id="primary" className="content-area clearfix" role="main">

		<article id="post-653" className="post-653 post type-post status-publish format-standard has-post-thumbnail hentry category-chrysanthemum tag-6">
			<div className="post-media clearfix">
                <Image width="1920" height="2560" src="https://momoko.chouxiangpai.com/wp-content/uploads/2020/07/258芳溪秋雨-3-scaled.jpg" className="attachment-full size-full wp-post-image" alt=""   sizes="(max-width: 1920px) 100vw, 1920px" /></div> 
			<header className="entry-header clearfix">
				<h1 className="entry-title">芳溪秋雨{params.slug}</h1>
			</header>
								
			<div className="entry-content clearfix">
				
		<p>花型：贯珠型</p>
		<p>瓣型：钩管　环管</p>
		<div className="cat-links taxonomy-wrap"><span className="taxonomy-wrap-title">Posted In: </span><a href="https://momoko.chouxiangpai.com/category/chrysanthemum/" rel="category tag">头状花序</a></div> <div className="tag-links taxonomy-wrap"><span className="taxonomy-wrap-title">Tagged In: </span><a href="https://momoko.chouxiangpai.com/tag/%e7%ae%a1%e7%93%a3/" rel="tag">管瓣</a></div> 
			</div> 
								
			<footer className="entry-footer clearfix">
				<div className="date-meta">4年 ago</div>
			</footer>
			
		</article>
		</div>


		<div id="secondary" className="widget-area clearfix" role="complementary">
			<aside id="search-2" className="widget clearfix widget_search"><form role="search" method="get" className="search-form" action="https://momoko.chouxiangpai.com/">
						<label>
							<span className="screen-reader-text">搜索：</span>
							<input type="search" className="search-field" placeholder="搜索&hellip;" value="" name="s" />
						</label>
						<input type="submit" className="search-submit" value="搜索" />
					</form></aside>		<aside id="recent-posts-2" className="widget clearfix widget_recent_entries">		<h4 className="widget-title"><span>近期文章</span></h4>		<ul>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e9%b8%b3%e9%b8%af%e8%8d%b7/">鸳鸯荷</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e8%8b%8d%e9%be%99%e7%88%aa/">苍龙爪</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e9%87%91%e8%83%8c%e5%a4%a7%e7%ba%a2-2/">金背大红</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e6%b4%b9%e6%b0%b4%e9%87%91%e6%a1%82/">洹水金桂</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e9%87%91%e4%b8%9d%e8%8d%b7/">金丝荷</a>
											</li>
							</ul>
				</aside>
				
					<aside id="recent-comments-2" className="widget clearfix widget_recent_comments">
					<h4 className="widget-title"><span>热门文章</span></h4>
					<ul id="recentcomments">

          <li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e9%b8%b3%e9%b8%af%e8%8d%b7/">鸳鸯荷</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e8%8b%8d%e9%be%99%e7%88%aa/">苍龙爪</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e9%87%91%e8%83%8c%e5%a4%a7%e7%ba%a2-2/">金背大红</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e6%b4%b9%e6%b0%b4%e9%87%91%e6%a1%82/">洹水金桂</a>
											</li>
													<li>
							<a href="https://momoko.chouxiangpai.com/2020/07/13/%e9%87%91%e4%b8%9d%e8%8d%b7/">金丝荷</a>
											</li>
          </ul>
					</aside>
				</div>
				
				</div>
	</main>
    );
}