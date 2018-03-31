/**
 * export all models
 */

// make the relation
const dbConfig = require("../hackernews").database;
const sequelize = require("./sequelize")(dbConfig);
const PostType = require("./postType")(sequelize);
const Post = require("./post")(sequelize);


const modules = {
    PostType,
    Post,
    sequelize
};

require("./relationShip")(modules);

module.exports = modules;