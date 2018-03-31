/**
 * @description  PostTypeService
 * @author omar BERRABEH
 */

const { PostType } = require("../models");

class PostTypeService {
    async find(type = 'story') {
        return await PostType.findOne({
            name: type
        });
    }
}


module.exports = new PostTypeService();