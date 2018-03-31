const Sequelize = require("sequelize");

function createPostModel(sequelize) {
    const Post = sequelize.define("Post", {
        ID: {
            type: Sequelize.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },
        Score: {
            type: Sequelize.INTEGER,
            defaultValue: 0
        },
        Created: {
            type: Sequelize.DATE,
            defaultValue: Sequelize.NOW
        },
        Text: Sequelize.STRING,
        Title: Sequelize.STRING,
        Url: Sequelize.STRING,
        originid: Sequelize.INTEGER
    },{
        tableName: "Post",
        createdAt: false,
        updatedAt: false
    });
    return Post;
}

let post;
module.exports = function postFactory(sequelize) {
    if (!post) post = createPostModel(sequelize);
    return post;
};