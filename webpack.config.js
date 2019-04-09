const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');

function resolve(filePath) {
  return path.join(__dirname, filePath);
}

var babelOptions = fableUtils.resolveBabelOptions({
  presets: [['es2015', { 'modules': false }]],
  plugins: ['transform-runtime']
});

var isProduction = process.argv.indexOf('-p') >=0;
console.log("Bundling for " + (isProduction ? "production" : "development") + "...");

module.exports = {
  mode: 'development',
  entry: {
    app: './src/index.js',
    print: './src/print.js'
  },
  devtool: 'inline-source-map',
  plugins: [
    new CleanWebpackPlugin(),
    new HtmlWebpackPlugin({
      title: 'Output Management'
    })
  ],
  output: {
    filename: '[name].bundle.js',
    path: path.resolve(__dirname, 'dist')
  },
  module: {
    rules: [
      {
        test: /\.css$/,
        use: [
          'style-loader',
          'css-loader'
        ]
      },
      {
        test: /\.(png|svg|jpg|gif)$/,
        use: [
          'file-loader'
        ]
      },
      {
        test: /\.(woff|woff2|eot|ttf|otf)$/,
        use: [
          'file-loader'
        ]
      }
    ]
  }
};
