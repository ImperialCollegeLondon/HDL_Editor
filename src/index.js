import _ from 'lodash';
import './style.css';
import Icon from './icon.png';
import printMe from './print.js';

function component() {
  var element = document.createElement('div');
  var btn = document.createElement('button');

  element.innerHTML = _.join(['Hello', 'webpack'], ' ');
  element.classList.add('hello');

  btn.innerHTML = 'Click me and check the console!';
  btn.onclick = printMe;

  // add the image to the existing div
  var myIcon = new Image();
  myIcon.src = Icon;

  element.appendChild(myIcon);
  element.appendChild(btn);
  
  return element;
}

document.body.appendChild(component());
