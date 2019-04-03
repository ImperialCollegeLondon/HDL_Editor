window.onload = function() {

  var items = [];

  function updateButton() {
    console.log("Add button clicked!");
    items.push(createNewBlocks());
    console.log(items.length);
  }

  function addLinkButton() {
    console.log("Link button clicked!");
    createLink(items[0], items[1], graph);
  }

  document.getElementById('elmish-button').addEventListener('click', updateButton);
  document.getElementById('add-link-button').addEventListener('click', addLinkButton);

  // testing JointJS
  var drawRectangle = nodeRequire("./js/jointjs-add-shape.js");

  var graph = new joint.dia.Graph;

  var paper = new joint.dia.Paper({
      el: document.getElementById('myholder'),
      model: graph,
      width: 1000,
      height: 1000,
      gridSize: 1
  });

  function createNewBlocks() {
    var rect = new joint.shapes.standard.Rectangle();
    rect.position(100, 30);
    rect.resize(100, 40);
    rect.attr({
        body: {
            fill: 'blue'
        },
        label: {
            text: 'Hello',
            fill: 'white'
        }
    });

    rect.addTo(graph);
    return rect;
  }

  function createLink(source, sink, graph) {
    var link = new joint.shapes.standard.Link();
    link.source(source);
    link.target(sink);
    link.addTo(graph);
  }
  // var rect2 = rect.clone();
  // rect2.translate(300, 0);
  // rect2.attr('label/text', 'World!');
  // rect2.addTo(graph);
}
