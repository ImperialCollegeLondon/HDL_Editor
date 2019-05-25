var path = require("path");
var webpack = require("webpack");
var MonacoWebpackPlugin = require('monaco-editor-webpack-plugin');

function resolve(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = {
  presets: [["@babel/preset-env", {"modules": false}]],
  plugins: ["@babel/plugin-transform-runtime"]
};

var isProduction = process.argv.indexOf("-p") >= 0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

var basicConfig = {
  mode: "development",
  devtool: "source-map",
  node: {
    __dirname: false,
    __filename: false
  },
  module: {
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: {
          loader: "fable-loader",
          options: {
            babel: babelOptions,
            define: isProduction ? [] : ["DEBUG"]
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        },
      },
      {
        test:/\.css$/,
        use: {
          loader: 'style-loader',
          options: {
            sourceMap: true
          }
        }
      },
      {
        test:/\.css$/,
        use: {
          loader: 'css-loader',
          options: {
            sourceMap: true
          }
        }
      }
    ]
  },
  plugins: [
    new MonacoWebpackPlugin()
  ]
};

var mainConfig = Object.assign({
  target: "electron-main",
  entry: resolve("./src/Main/Main.fsproj"),
  output: {
    path: resolve("./app"),
    filename: "js/main.js"
  }
}, basicConfig);

var rendererConfig = Object.assign({
  target: "electron-renderer",
  entry: resolve("./src/Renderer/Renderer.fsproj"),
  output: {
    path: resolve("./app"),
    filename: "js/renderer.js"
  }
}, basicConfig);

var rendererAboutWindowConfig = Object.assign({
  target: "electron-renderer",
  entry: resolve("./src/RendererAboutWindow/RendererAboutWindow.fsproj"),
  output: {
    path: resolve("./app"),
    filename: "js/renderer_about_window.js"
  }
}, basicConfig);

var unitTest = Object.assign({
  target: "electron-renderer",
  entry: resolve("./src/RendererAboutWindow/RendererAboutWindow.fsproj"),
  output: {
    path: resolve("./test"),
    filename: "test.js"
  }
}, basicConfig);

module.exports = [mainConfig, rendererConfig, rendererAboutWindowConfig, unitTest]
