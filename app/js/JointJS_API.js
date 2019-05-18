// var jquery = require("../../node_modules/jointjs/node_modules/jquery/dist/jquery");
// var lodash = require("../../node_modules/jointjs/node_modules/lodash/lodash");
// var backbone = require("../../node_modules/jointjs/node_modules/backbone/backbone");
var joint = require("../../node_modules/jointjs/dist/joint")

module.exports.graph = new joint.dia.Graph;

// module.exports.paper = new joint.dia.Paper({
//     el: document.getElementById('myholder'),
//     model: graph,
//     width: 600,
//     height: 100,
//     gridSize: 1
// });

module.exports.all = function () {

  var graph = new joint.dia.Graph;
  var paper = new joint.dia.Paper({
      el: document.getElementById('myholder'),
      model: graph,
      width: 600,
      height: 100,
      gridSize: 1
  });

  console.log(paper instanceof joint.dia.Paper);

  // var paper = new joint.dia.Paper();
  //
  // paper.el = document.getElementById('myholder');
  // paper.model = graph;
  // paper.width = 600;
  // paper.height = 100;
  // paper.gridSize = 1;
}
