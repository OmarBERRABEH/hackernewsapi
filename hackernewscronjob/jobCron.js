module.exports = find;


async function find() {
    const ids = await FetcherService.getJob();
    if (Array.isArray(ids) && ids.length) {
        let postType = await PostTypeService.find('job');
        let postDetailPromes = ids.forEach((async function (id) {
            let isExist = await PostService.findByOrigin(id);
            if (!isExist) {
                let job = await FetcherService.detail.bind(FetcherService)(id);
                insertPost(job, postType);
            }
        }));
    }
}

function insertPost(job, postType) {
    var post = PostService.build(job.title, job.score, job.text, job.url, job.id, postType.ID);
}