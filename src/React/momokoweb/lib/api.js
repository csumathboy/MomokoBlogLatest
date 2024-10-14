// Get Post by classid
export async function getPostsByClassId(classid="",sorting="Sort",SkipCount=0,MaxResultCount=12) {
    let reqUrl=process.env.API_HOST+'/api/app/post/by-condition?Sorting='+sorting+'&SkipCount='+SkipCount+'&MaxResultCount='+MaxResultCount;
    if(classid!=""){
      reqUrl=reqUrl+"&classid="+classid;
    }
    const response = await fetch(reqUrl);
    const data = await response.json();

    const res = {};
 
    data.items.forEach(({id, title, author, description,className,picture,postTagNames,creationTime}) => {
      res[id] = JSON.stringify({
        postid:id,
        title,
        author,
        description,
        classname:className,
        picture:process.env.API_HOST+picture,
        tagname:postTagNames,
        addtime:creationTime
      })
    });
  
    return res
  }
  // Get Post by tagid
export async function getPostsByTagName(tagname,SkipCount=0,MaxResultCount=12) {
    let reqUrl=process.env.API_HOST+'/api/app/post/by-tag?SkipCount='+SkipCount+"&MaxResultCount="+MaxResultCount;
    if(tagname!=""){
      reqUrl=reqUrl+"&tagName="+tagname;
    }
    const response = await fetch(reqUrl);
    const data = await response.json();

    const res = {};
  
    data.items.forEach(({id, title, author, description,className,picture,postTagNames,creationTime}) => {
        res[id] = JSON.stringify({
          title,
          author,
          description,
          classname:className,
          picture:process.env.API_HOST+picture,
          tagname:postTagNames,
          addtime:creationTime
        })
      });
  
    return res
  }
  // getPostById
  export async function getPostById(id) {
    let reqUrl=process.env.API_HOST+'/api/app/post/';
    if(id!=""){
      reqUrl=reqUrl+id;
    }
    const response = await fetch(reqUrl);
    if (!response.ok) {
      // 由最近的 error.js 处理
      throw new Error('Failed to fetch data')
    }
    const data = await response.json();
    return {
      title:data.title,
      author:data.author,
      description:data.description,
      classname:data.className,
      classid:data.classId,
      picture:process.env.API_HOST+data.picture,
      tagname:data.postTagNames,
      addtime:data.creationTime,
      id: data.id
    }
  }
  