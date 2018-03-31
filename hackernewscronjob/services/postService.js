/**
 * @description menage all post transaction
 */
const {Post} = require("../models");

class PostService {
    
    build(Title, Score = 0, text, Url, originid, PostTypeID) {
        console.log(Title, Score, text, Url, originid, PostTypeID);
        Post
        .build({Title, Score, text, Url, originid, PostTypeID})
        .save()
    }

    async findByOrigin(originid) {
        return await Post.findOne({ where:{ originid }}).catch(e => console.log(e))
    }
}

module.exports = new PostService();