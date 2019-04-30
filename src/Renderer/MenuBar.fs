module MenuBar

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Node.Exports
open System


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
let menuFileSubmenuTemplate = ResizeArray<MenuItemOptions> [menuFileSubmenu]
*)

let menuFile = menuBuilder(Option.None, 
                           Some (MenuItemType.Normal), 
                           Some "File", 
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


let initMenu() = 
    printf "initMenu()"
    let template = ResizeArray<MenuItemOptions> [
        menuFile
        menuEdit
        menuView
        menuHelp
        ]
    template
    |> electron.remote.Menu.buildFromTemplate
    |> electron.remote.Menu.setApplicationMenu

