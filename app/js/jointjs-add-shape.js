module.exports.drawRectangle = function (positionX, positionY) {
    var rect = new joint.shapes.standard.Rectangle();
    rect.position(positionX, positionY);
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
    return rect;
};
