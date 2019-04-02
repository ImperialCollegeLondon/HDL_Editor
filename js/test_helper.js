var path = require('path')
var Application = require('spectron').Application

function initialiseSpectron() {
   let electronPath = path.join(__dirname, "../../Parallel_HDL_Dev/node_modules", ".bin", "electron");
   const appPath = path.join(__dirname, "../../Parallel_HDL_Dev");
   if (process.platform === "win32") {
       electronPath += ".cmd";
   }

   return new Application({
       path: electronPath,
       args: [appPath],
       env: {
           ELECTRON_ENABLE_LOGGING: true,
           ELECTRON_ENABLE_STACK_DUMPING: true,
           NODE_ENV: "development"
       },
       startTimeout: 20000,
       chromeDriverLogPath: '../Parallel_HDL_Dev/chromedriverlog.log'
  });
}

module.exports.initialiseSpectron = initialiseSpectron;
