/**
 * @description menage all relationship between models
 */
function relationship_Post_PostType(PostType, Post) {
    Post.belongsTo(PostType);
}
module.exports = function relationship({PostType, Post}) {
    relationship_Post_PostType(PostType, Post);
}