const PROXY_CONFIG = [
  {
    "/api": {
      target: "https://localhost:7063",
      "secure": false
    },
    "pathRewrite": {
      "^/api": ""
    },
    "changeOrigin": true,    
    "logLevel": "debug"
  }
]

module.exports = PROXY_CONFIG;
