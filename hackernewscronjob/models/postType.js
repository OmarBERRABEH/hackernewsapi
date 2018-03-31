const Sequelize = require("sequelize");

function createPostTypeModel(sequelize) {
    const PostType = sequelize.define("PostType", {
        ID: {
            type: Sequelize.INTEGER,
            primaryKey: true,
            autoIncrement: true
        },
        Created: {
            type: Sequelize.DATE,
            defaultValue: Sequelize.NOW
        },
        Name: Sequelize.STRING
    }, {
        tableName: "PostType",
        createdAt: false,
        updatedAt: false
    });
    return PostType;
}

let postType;
module.exports = function postTypeFactory(sequelize) {
    if (!postType) postType = createPostTypeModel(sequelize);
    return postType;
}