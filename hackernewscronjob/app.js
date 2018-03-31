const CronJob = require('cron').CronJob;
const postCron = require("./postJob");
const jobCron = require("./jobCron");


new CronJob('0 */1 * * * *', jobCron, null, true); 