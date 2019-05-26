var path = require("path");
var webpack = require("webpack");

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
  }
};

var unitTest = Object.assign({
  target: "electron-renderer",
  entry: resolve("./src/UnitTest/UnitTest.fsproj"),
  output: {
    path: resolve("./test"),
    filename: "test.js"
  }
}, basicConfig);

module.exports = [unitTest]
