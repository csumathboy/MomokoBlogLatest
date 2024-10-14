import Link from 'next/link'

export default function Header() {
  return (
    <header id="masthead" className="site-header clearfix" role="banner">
            <div className="overlay">
                <div className="title-area clearfix">
                                    <h1 className="site-title"><Link href="/" rel="home">水田芥末</Link></h1>
                    <h2 className="site-description">人闲桂花落，夜静春山空</h2>
                </div>
              
                <nav id="navigation" className="site-navigation clearfix" role="navigation">
                    <ul id="menu-main" className="menu"><li id="menu-item-50" className="menu-item menu-item-type-custom menu-item-object-custom current-menu-item current_page_item menu-item-home menu-item-50"><Link href="/" aria-current="page">首页</Link></li>
                      <li id="menu-item-63" className="menu-item menu-item-type-taxonomy menu-item-object-category menu-item-63"><Link href="/category/头状花序/6ddbe4ab-f368-0b74-2323-3a142ee657cc">头状花序</Link></li>
                      <li id="menu-item-53" className="menu-item menu-item-type-taxonomy menu-item-object-category menu-item-53"><Link href="/category/玫瑰掠影/7212c406-4ddd-c09f-12a1-3a14143dce29">玫瑰掠影</Link></li>
                      <li id="menu-item-51" className="menu-item menu-item-type-post_type menu-item-object-page menu-item-51"><Link href="/flower">田园花趣</Link></li>
                      <li id="menu-item-52" className="menu-item menu-item-type-post_type menu-item-object-page menu-item-52"><Link href="/about">关于我</Link></li>
                    </ul>			
                  </nav> 
            </div> 
        </header>
  );
}
