const Sequelize = require("sequelize");

module.exports = function sequelizeFactory(dbConfig) {
    const sequelize = new Sequelize(dbConfig.dbname, dbConfig.username, dbConfig.password, {
        dialect: 'mssql',
        host: dbConfig.server,
        operatorsAliases: false,
        logging: false
    });
    return sequelize;
}