const {
    FetcherService,
    PostService,
    PostTypeService
} = require("./services");


module.exports = postCron


async function postCron() {
    const ids = await FetcherService.getPost();
    if (Array.isArray(ids) && ids.length) {
        let postType = await PostTypeService.find('story');
        let postDetailPromes = ids.forEach((async function (id) {
            let isExist = await PostService.findByOrigin(id);
            if (!isExist) {
                let post = await FetcherService.detail.bind(FetcherService)(id);
                insertPost(post, postType);
            }
        }));
    }
}

function insertPost(post, postType) {
    var post = PostService.build(post.title, post.score, post.text, post.url, post.id, postType.ID);
}