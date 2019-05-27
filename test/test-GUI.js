const spectron = require('spectron')
const Application = spectron.Application
const assert = require('assert')
const electronPath = require('electron') // Require Electron from the binaries included in node_modules.
const path = require('path')
// const ut = require('./test-non-GUI')

describe('GUI tests', function () {
  this.timeout(10000)

  beforeEach(function () {
    this.app = new Application({
      // Your electron path can be any binary
      // i.e for OSX an example path could be '/Applications/MyApp.app/Contents/MacOS/MyApp'
      // But for the sake of the example we fetch it from our node_modules.
      path: electronPath,

      // Assuming you have the following directory structure

      //  |__ my project
      //     |__ ...
      //     |__ main.js
      //     |__ package.json
      //     |__ index.html
      //     |__ ...
      //     |__ test
      //        |__ spec.js  <- You are here! ~ Well you should be.

      // The following line tells spectron to look and use the main.js file
      // and the package.json located 1 level above.
      args: [path.join(__dirname, '../app/js/main.js')]
    })
    return this.app.start()
  })

  afterEach(function () {
    if (this.app && this.app.isRunning()) {
      return this.app.stop()
    }
  })

  it('check initial window visible', function () {
    return this.app.browserWindow.isVisible().then(function (visibility) {
      assert.equal(visibility, true)
    })
  })

  it('shows an initial window', function () {
    return this.app.client.getWindowCount().then(function (count) {
      assert.equal(count, 1)
      // Please note that getWindowCount() will return 2 if `dev tools` are opened.
      // assert.equal(count, 2)
    })
  })

  it('check main window name', function () {
    return this.app.browserWindow.getTitle().then(function (title) {
      assert.equal(title, "HDL Editor")
    })
  })

  // it('check about window name', async function () {
  //   await this.app.client.waitUntilWindowLoaded().pause(1000);
  //   var menu = await this.app.electron.remote.Menu.getApplicationMenu()
  //   var helpButton = menu.getMenuItemById("aboutMenuItem")
  //   helpButton.click()
  //   done()
  // })
})
