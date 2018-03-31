/**
 * @description fetch enw hackernews post | job | comment
 */
const apiConfig = require("../hackernews").api;
const axios = require("axios");

 class FetcherService {
    
    constructor() {
        this.makeRequest = this.makeRequest.bind(this);
    }

    async getPost() {
        const ids = await this.makeRequest(apiConfig.new);
        return ids;
    }

    async getJob() {
        const ids = await this.makeRequest(apiConfig.job);
        return ids;
    }

    async detail(id) {
         const dataJson =  await this.makeRequest(apiConfig.item + '/'+ id+ '.json');
         return dataJson;
    }

    async makeRequest(suffixUrl) {
         const response = await axios.get(apiConfig.base+suffixUrl,{ responseType: 'json' });
         return response.data;
    }
 }


 module.exports =  new FetcherService();