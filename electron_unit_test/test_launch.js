const testHelper = require('../js/test_helper');
const app = testHelper.initialiseSpectron();
const electron = require('electron');
var path = require('path')

const assert = require('assert');

describe("check full screen on launch", function() {
  this.timeout(10000)

  beforeEach(function () {
    this.app = app
    return this.app.start()
  })

  afterEach(function () {
    if (this.app && this.app.isRunning()) {
      return this.app.stop()
    }
  })

  it("Check window fullscreen on launch", (done) => {
    const window = new electron.BrowserWindow({ show:false });
    assert(!window.isFullScreen(), "the main window should not be full-screen when launching");
    window.destroy();
    done();
  });

  it("Check window title", function() {
    const window = new electron.BrowserWindow({ show:false });
    assert.equal(window.loadTitle(), "Electron", "the main window should have the name of \"HDL Editor\"");
    window.destroy();
    done();
  });
});
