// Get Post by classid
export async function getPostsByClassId(classid) {
    const response = await fetch('https://apimk.chouxiangpai.com:8443/api/app/post/by-condition?classid='+classid);
    const data = await response.json();

    const res = {};
  
    data.items.forEach(({id, title, author, description,className,picture,postTagNames,creationTime}) => {
      res[id] = JSON.stringify({
        title,
        author,
        description,
        classname:className,
        picture,
        tagname:postTagNames,
        addtime:creationTime
      })
    });
  
    return res
  }
  // Get Post by tagid
export async function getPostsByTagId(tagid) {
    const response = await fetch('https://apimk.chouxiangpai.com:8443/api/app/post/bytag?'+tagid);
    const data = await response.json();

    const res = {};
  
    data.items.forEach(({id, title, author, description,className,picture,postTagNames,creationTime}) => {
        res[id] = JSON.stringify({
          title,
          author,
          description,
          classname:className,
          picture,
          tagname:postTagNames,
          addtime:creationTime
        })
      });
  
    return res
  }
  // getPostById
  export async function getPostById(id) {
    const response = await fetch('https://apimk.chouxiangpai.com:8443/api/app/post/'+id);
    if (!response.ok) {
      // 由最近的 error.js 处理
      throw new Error('Failed to fetch data')
    }
    const data = await response.json();
    return {
      title:data.items[0].title,
      author:data.items[0].author,
      description:data.items[0].description,
      classname:data.items[0].className,
      picture:data.items[0].picture,
      tagname:data.items[0].postTagNames,
      addtime:data.items[0].creationTime,
      id: data.items[0].id
    }
  }
  