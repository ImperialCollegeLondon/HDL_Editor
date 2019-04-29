module Main

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Node.Exports
open System

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mutable mainWindow: BrowserWindow option = Option.None

type MenuItemClass(clickData:Func<MenuItem, BrowserWindow, unit> option, 
                   typeData:MenuItemType option, 
                   labelData:string option, 
                   sublabelData:string option, 
                   acceleratorData:string option, 
                   iconData:U2<NativeImage, string> option,
                   enabledData:bool option,
                   visibleData:bool option,
                   checkedData:bool option,
                   submenuData:U2<Menu, ResizeArray<MenuItemOptions>> option,
                   idData:string option,
                   positionData:string option,
                   roleData:U2<MenuItemRole, MenuItemRoleMac> option) = 
    let mutable clickData = clickData
    let mutable typeData = typeData
    let mutable labelData = labelData
    let mutable sublabelData = sublabelData
    let mutable acceleratorData = acceleratorData
    let mutable iconData = iconData
    let mutable enabledData = enabledData
    let mutable visibleData = visibleData
    let mutable checkedData = checkedData
    let mutable submenuData = submenuData
    let mutable idData = idData
    let mutable positionData = positionData
    let mutable roleData = roleData

    interface MenuItemOptions with 
        member self.click 
            with get() = clickData
            and set clickVal = clickData <- clickVal 
        member self.``type``
            with get() = typeData
            and set typeVal = typeData <- typeVal
        member self.label
            with get() = labelData
            and set labelVal = labelData <- labelVal
        member self.sublabel
            with get() = sublabelData
            and set sublabelVal = sublabelData <- sublabelVal
        member self.accelerator
            with get() = acceleratorData
            and set acceleratorVal = acceleratorData <- acceleratorVal
        member self.icon
            with get() = iconData
            and set iconVal = iconData <- iconVal
        member self.enabled
            with get() = enabledData
            and set enabledVal = enabledData <- enabledVal
        member self.visible
            with get() = visibleData
            and set visibleVal = visibleData <- visibleVal
        member self.``checked``
            with get() = checkedData
            and set checkedVal = checkedData <- checkedVal
        member self.submenu
            with get() = submenuData
            and set submenuVal = submenuData <- submenuVal
        member self.id
            with get() = idData
            and set idVal = idData <- idVal
        member self.position
            with get() = positionData
            and set positionVal = positionData <- positionVal
        member self.role
            with get() = roleData
            and set roleVal = roleData <- roleVal
    
let createMainWindow () =
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 1366.
    options.height <- Some 1024.
    options.autoHideMenuBar <- Some false
    let window = electron.BrowserWindow.Create(options)

    // Load the index.html of the app.
    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some <| Path.join(Node.Globals.__dirname, "../index.html")
    opts.protocol <- Some "file:"
    window.loadURL(Url.format(opts))

    let menuTemplate = new ResizeArray<MenuItemOptions>()
    let menuItem = MenuItemClass(clickData = Option.None, 
                                 typeData = Some (MenuItemType.Normal), 
                                 labelData = Some "Quit", 
                                 sublabelData = Option.None, 
                                 acceleratorData = Some "Ctrl+Q", 
                                 iconData = Option.None,
                                 enabledData = Some true,
                                 visibleData = Some true,
                                 checkedData = Some false,
                                 submenuData = Option.None,
                                 idData = Option.None,
                                 positionData = Option.None,
                                 roleData = Some (U2.Case1 MenuItemRole.Quit))
    menuItem.label <- Some "Quit"
    menuTemplate.Add(menuItem)
    let systemMenu = electron.Menu.buildFromTemplate(menuTemplate)

    electron.Menu.setApplicationMenu(systemMenu)

    #if DEBUG
    Fs.watch(Path.join(Node.Globals.__dirname, "renderer.js"), fun _ _ ->
        window.webContents.reloadIgnoringCache()
    ) |> ignore
    #endif

    // Emitted when the window is closed.
    window.on("closed", unbox(fun () ->
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        mainWindow <- Option.None
    )) |> ignore

    // Maximize the window
    window.maximize()

    mainWindow <- Some window

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
electron.app.on("ready", unbox createMainWindow) |> ignore

// Quit when all windows are closed.
electron.app.on("window-all-closed", unbox(fun () ->
    // On OS X it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    if Node.Globals.``process``.platform <> Node.Base.NodeJS.Darwin then
        electron.app.quit()
)) |> ignore

electron.app.on("activate", unbox(fun () ->
    // On OS X it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if mainWindow.IsNone then
        createMainWindow()
)) |> ignore
