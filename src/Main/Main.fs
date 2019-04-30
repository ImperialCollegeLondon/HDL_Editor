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

// the following code using interfaces via the keyword "interface...with..." is obsolete
// need to remove them in the future implementation
// but served well as I learnt how to use F# interfaces
(*
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
    let mutable label = labelData
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
            with get() = label
            and set labelVal = label <- labelVal
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
*)

let menuBuilder(clickData:Func<MenuItem, BrowserWindow, unit> option, 
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
                {new MenuItemOptions with
                     member this.accelerator
                         with set (v: string option): unit = 
                             this.accelerator <- v
                     member this.``checked``
                         with set (v: bool option): unit = 
                             this.``checked`` <- v
                     member this.click
                         with set (v: Func<MenuItem,BrowserWindow,unit> option): unit = 
                             this.click <- v
                     member this.enabled
                         with set (v: bool option): unit = 
                             this.enabled <- v
                     member this.icon
                         with set (v: U2<NativeImage,string> option): unit = 
                             this.icon <- v
                     member this.id
                         with set (v: string option): unit = 
                             this.id <- v
                     member this.label
                         with set (v: string option): unit = 
                             this.label <- v
                     member this.position
                         with set (v: string option): unit = 
                             this.position <- v
                     member this.role
                         with set (v: U2<MenuItemRole,MenuItemRoleMac> option): unit = 
                             this.role <- v
                     member this.sublabel
                         with set (v: string option): unit = 
                             this.sublabel <- v
                     member this.submenu
                         with set (v: U2<Menu,ResizeArray<MenuItemOptions>> option): unit = 
                             this.submenu <- v
                     member this.``type``
                         with set (v: MenuItemType option): unit = 
                             this.``type`` <- v
                     member this.visible
                         with set (v: bool option): unit = 
                             this.visible <- v
                     member this.click = clickData
                     member this.``type`` = typeData
                     member this.label = labelData
                     member this.sublabel = sublabelData
                     member this.accelerator = acceleratorData
                     member this.icon = iconData
                     member this.enabled = enabledData
                     member this.visible = visibleData
                     member this.``checked`` = checkedData
                     member this.submenu = submenuData
                     member this.id = idData
                     member this.position = positionData
                     member this.role = roleData}

let ch (str) = 
    let m = createEmpty<MenuItemOptions>
    m.label <- str
    m

let newMenu item name = 
    let m = createEmpty<MenuItemOptions>
    m.label <- name
    m.submenu <- item
    m

let makeItem (label : string) (accelerator : string option) = //(iAction : unit -> unit) =
    let handlerCaster f = System.Func<MenuItem, BrowserWindow, unit> f |> Some
    let item = createEmpty<MenuItemOptions>
    item.label <- Some label
    item.accelerator <- accelerator
    //item.click <- handlerCaster (fun _ _ -> iAction())
    item

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
    
    (*
    let menuFileSubmenu = menuBuilder(Option.None, 
                                      Some (MenuItemType.Normal), 
                                      Some "Quit", 
                                      Option.None, 
                                      Some "Ctrl+Q", 
                                      Option.None,
                                      Some true,
                                      Some true,
                                      Some false,
                                      Option.None,
                                      Option.None,
                                      Option.None,
                                      Some (U2.Case1 MenuItemRole.Quit))
    let file' = makeItem "Quit" Option.None
    let menuFileSubmenuTemplate = ResizeArray<MenuItemOptions> [menuFileSubmenu]

    let menuFile = menuBuilder(Option.None, 
                               Some (MenuItemType.Normal), 
                               Some "File", 
                               Option.None, 
                               Option.None, 
                               Option.None,
                               Some true,
                               Some true,
                               Some false,
                               Some (U2.Case2 menuFileSubmenuTemplate),
                               Option.None,
                               Option.None,
                               Option.None)  
     
    let menuEdit = menuBuilder(Option.None, 
                               Some (MenuItemType.Normal), 
                               Some "Edit", 
                               Option.None, 
                               Some "Ctrl+A", 
                               Option.None,
                               Some true,
                               Some true,
                               Some false,
                               Option.None,
                               Option.None,
                               Option.None,
                               Some (U2.Case1 MenuItemRole.EditMenu))  

    let menuView = menuBuilder(Option.None, 
                               Some (MenuItemType.Normal), 
                               Some "View", 
                               Option.None, 
                               Some "Ctrl+P", 
                               Option.None,
                               Some true,
                               Some true,
                               Some false,
                               Option.None,
                               Option.None,
                               Option.None,
                               Option.None)  

    let menuHelp = menuBuilder(Option.None, 
                               Some (MenuItemType.Normal), 
                               Some "Help", 
                               Option.None, 
                               Option.None, 
                               Option.None,
                               Some true,
                               Some true,
                               Some false,
                               Option.None,
                               Option.None,
                               Option.None,
                               Option.None)  

    let menuTemplate = ResizeArray<MenuItemOptions> [
        menuFile
        menuEdit
        menuView
        menuHelp
        ]

    let systemMenu = electron.Menu.buildFromTemplate(menuTemplate)
   
    electron.Menu.setApplicationMenu(systemMenu)
     
     // Clear the menuBar, this is overwritten by the renderer process
    let template = ResizeArray<MenuItemOptions> [
                         createEmpty<MenuItemOptions>
                     ]
    electron.Menu.setApplicationMenu(electron.Menu.buildFromTemplate(template))
    *)
    let filemenu() = ch (Some "yes")
    let newFileMenu() = newMenu (Some (U2.Case2 (ResizeArray<MenuItemOptions>[filemenu()]))) (Some "File")
    let template = ResizeArray<MenuItemOptions> [
        newFileMenu()
    ]
    electron.Menu.setApplicationMenu(electron.Menu.buildFromTemplate(template))

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
