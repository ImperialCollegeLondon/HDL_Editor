// ts2fable 0.0.0
module rec Backbone
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

let [<Import("*","backbone")>] backbone: Backbone.IExports = jsNative

module Backbone =

    type [<AllowNullLiteral>] IExports =
        abstract Events: Events
        abstract EventsMixin: EventsMixinStatic
        abstract ModelBase: ModelBaseStatic
        abstract Model: ModelStatic
        abstract Collection: CollectionStatic
        abstract Router: RouterStatic
        abstract history: History
        abstract History: HistoryStatic
        abstract View: ViewStatic
        abstract sync: ``method``: string * model: U2<Model, Collection<Model>> * ?options: JQueryAjaxSettings -> obj option
        abstract ajax: ?options: JQueryAjaxSettings -> JQueryXHR
        abstract emulateHTTP: bool
        abstract emulateJSON: bool
        abstract noConflict: unit -> obj
        abstract ``$``: JQueryStatic

    type [<AllowNullLiteral>] AddOptions =
        inherit Silenceable
        abstract at: float option with get, set
        abstract merge: bool option with get, set
        abstract sort: bool option with get, set

    type [<AllowNullLiteral>] CollectionSetOptions =
        inherit Silenceable
        abstract add: bool option with get, set
        abstract remove: bool option with get, set
        abstract merge: bool option with get, set

    type [<AllowNullLiteral>] HistoryOptions =
        inherit Silenceable
        abstract pushState: bool option with get, set
        abstract root: string option with get, set

    type [<AllowNullLiteral>] NavigateOptions =
        abstract trigger: bool option with get, set
        abstract replace: bool option with get, set

    type [<AllowNullLiteral>] RouterOptions =
        abstract routes: obj option with get, set

    type [<AllowNullLiteral>] Silenceable =
        abstract silent: bool option with get, set

    type [<AllowNullLiteral>] Validable =
        abstract validate: bool option with get, set

    type [<AllowNullLiteral>] Waitable =
        abstract wait: bool option with get, set

    type [<AllowNullLiteral>] Parseable =
        abstract parse: obj option with get, set

    type [<AllowNullLiteral>] PersistenceOptions =
        abstract url: string option with get, set
        abstract data: obj option with get, set
        abstract beforeSend: (JQueryXHR -> unit) option with get, set
        abstract success: (obj -> obj -> obj -> unit) option with get, set
        abstract error: (obj -> JQueryXHR -> obj -> unit) option with get, set

    type [<AllowNullLiteral>] ModelSetOptions =
        inherit Silenceable
        inherit Validable

    type [<AllowNullLiteral>] ModelFetchOptions =
        inherit PersistenceOptions
        inherit ModelSetOptions
        inherit Parseable

    type [<AllowNullLiteral>] ModelSaveOptions =
        inherit Silenceable
        inherit Waitable
        inherit Validable
        inherit Parseable
        inherit PersistenceOptions
        abstract patch: bool option with get, set

    type [<AllowNullLiteral>] ModelDestroyOptions =
        inherit Waitable
        inherit PersistenceOptions

    type [<AllowNullLiteral>] CollectionFetchOptions =
        inherit PersistenceOptions
        inherit Parseable
        inherit CollectionSetOptions
        abstract reset: bool option with get, set

    type [<AllowNullLiteral>] ObjectHash =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] RoutesHash =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: routePattern: string -> U2<string, TypeLiteral_01> with get, set

    /// DOM events (used in the events property of a View)
    type [<AllowNullLiteral>] EventsHash =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: selector: string -> U2<string, TypeLiteral_02> with get, set

    /// JavaScript events (used in the methods of the Events interface)
    type [<AllowNullLiteral>] EventHandler =
        [<Emit "$0($1...)">] abstract Invoke: [<ParamArray>] args: ResizeArray<obj option> -> unit

    type [<AllowNullLiteral>] EventMap =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: ``event``: string -> EventHandler with get, set

    type [<AllowNullLiteral>] Events =
        inherit EventsMixin

    /// Helper shorthands for classes that implement the Events interface.
    /// Define your class like this:
    /// 
    /// import {
    ///      Events,
    ///      Events_On,
    ///      Events_Off,
    ///      Events_Trigger,
    ///      Events_Listen,
    ///      Events_Stop,
    /// } from 'backbone';
    /// 
    /// class YourClass implements Events {
    ///      on: Events_On<YourClass>;
    ///      off: Events_Off<YourClass>;
    ///      trigger: Events_Trigger<YourClass>;
    ///      bind: Events_On<YourClass>;
    ///      unbind: Events_Off<YourClass>;
    /// 
    ///      once: Events_On<YourClass>;
    ///      listenTo: Events_Listen<YourClass>;
    ///      listenToOnce: Events_Listen<YourClass>;
    ///      stopListening: Events_Stop<YourClass>;
    /// 
    ///      // ... (other methods)
    /// }
    /// 
    /// Object.assign(YourClass.prototype, Events);  // can also use underscore.extend
    /// 
    /// If you are just writing a class type declaration that doesn't already
    /// extend some other base class, you can use the EventsMixin instead;
    /// see below.
    type [<AllowNullLiteral>] Events_On<'BaseT> =
        [<Emit "$0($1...)">] abstract Invoke: this: T * eventName: string * callback: EventHandler * ?context: obj -> T
        [<Emit "$0($1...)">] abstract Invoke: this: T * eventMap: EventMap * ?context: obj -> T

    type [<AllowNullLiteral>] Events_Off<'BaseT> =
        [<Emit "$0($1...)">] abstract Invoke: this: T * ?eventName: string * ?callback: EventHandler * ?context: obj -> T

    type [<AllowNullLiteral>] Events_Trigger<'BaseT> =
        [<Emit "$0($1...)">] abstract Invoke: this: T * eventName: string * [<ParamArray>] args: ResizeArray<obj option> -> T

    type [<AllowNullLiteral>] Events_Listen<'BaseT> =
        [<Emit "$0($1...)">] abstract Invoke: this: T * ``object``: obj option * events: string * callback: EventHandler -> T
        [<Emit "$0($1...)">] abstract Invoke: this: T * ``object``: obj option * eventMap: EventMap -> T

    type [<AllowNullLiteral>] Events_Stop<'BaseT> =
        [<Emit "$0($1...)">] abstract Invoke: this: T * ?``object``: obj * ?events: string * ?callback: EventHandler -> T

    /// Helper to avoid code repetition in type declarations.
    /// Backbone.Events cannot be extended, hence a separate abstract
    /// class with a different name. Both classes and interfaces can
    /// extend from this helper class to reuse the signatures.
    /// 
    /// For class type declarations that already extend another base
    /// class, and for actual class definitions, please see the
    /// Events_* interfaces above.
    type [<AllowNullLiteral>] EventsMixin =
        inherit Events
        abstract on: eventName: string * callback: EventHandler * ?context: obj -> EventsMixin
        abstract on: eventMap: EventMap * ?context: obj -> EventsMixin
        abstract off: ?eventName: string * ?callback: EventHandler * ?context: obj -> EventsMixin
        abstract trigger: eventName: string * [<ParamArray>] args: ResizeArray<obj option> -> EventsMixin
        abstract bind: eventName: string * callback: EventHandler * ?context: obj -> EventsMixin
        abstract bind: eventMap: EventMap * ?context: obj -> EventsMixin
        abstract unbind: ?eventName: string * ?callback: EventHandler * ?context: obj -> EventsMixin
        abstract once: events: string * callback: EventHandler * ?context: obj -> EventsMixin
        abstract once: eventMap: EventMap * ?context: obj -> EventsMixin
        abstract listenTo: ``object``: obj option * events: string * callback: EventHandler -> EventsMixin
        abstract listenTo: ``object``: obj option * eventMap: EventMap -> EventsMixin
        abstract listenToOnce: ``object``: obj option * events: string * callback: EventHandler -> EventsMixin
        abstract listenToOnce: ``object``: obj option * eventMap: EventMap -> EventsMixin
        abstract stopListening: ?``object``: obj * ?events: string * ?callback: EventHandler -> EventsMixin

    /// Helper to avoid code repetition in type declarations.
    /// Backbone.Events cannot be extended, hence a separate abstract
    /// class with a different name. Both classes and interfaces can
    /// extend from this helper class to reuse the signatures.
    /// 
    /// For class type declarations that already extend another base
    /// class, and for actual class definitions, please see the
    /// Events_* interfaces above.
    type [<AllowNullLiteral>] EventsMixinStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> EventsMixin

    type [<AllowNullLiteral>] ModelBase =
        inherit EventsMixin
        abstract parse: response: obj option * ?options: obj -> obj option
        abstract toJSON: ?options: obj -> obj option
        abstract sync: [<ParamArray>] arg: ResizeArray<obj option> -> JQueryXHR

    type [<AllowNullLiteral>] ModelBaseStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ModelBase

    type [<AllowNullLiteral>] Model =
        inherit ModelBase
        inherit Events
        abstract attributes: obj option with get, set
        abstract changed: ResizeArray<obj option> with get, set
        abstract cidPrefix: string with get, set
        abstract cid: string with get, set
        abstract collection: Collection<obj option> with get, set
        /// Default attributes for the model. It can be an object hash or a method returning an object hash.
        /// For assigning an object hash, do it like this: this.defaults = <any>{ attribute: value, ... };
        /// That works only if you set it in the constructor or the initialize method.
        abstract defaults: unit -> ObjectHash
        abstract id: obj option with get, set
        abstract idAttribute: string with get, set
        abstract validationError: obj option with get, set
        /// Returns the relative URL where the model's resource would be located on the server.
        abstract url: (unit -> string) with get, set
        abstract urlRoot: obj option with get, set
        abstract initialize: ?attributes: obj * ?options: obj -> unit
        abstract fetch: ?options: ModelFetchOptions -> JQueryXHR
        /// For strongly-typed access to attributes, use the `get` method only privately in public getter properties.
        abstract get: attributeName: string -> obj option
        /// For strongly-typed assignment of attributes, use the `set` method only privately in public setter properties.
        abstract set: attributeName: string * value: obj option * ?options: ModelSetOptions -> Model
        abstract set: obj: obj option * ?options: ModelSetOptions -> Model
        /// Return an object containing all the attributes that have changed, or
        /// false if there are no changed attributes. Useful for determining what
        /// parts of a view need to be updated and/or what attributes need to be
        /// persisted to the server. Unset attributes will be set to undefined.
        /// You can also pass an attributes object to diff against the model,
        /// determining if there *would be* a change. 
        abstract changedAttributes: ?attributes: obj -> obj option
        abstract clear: ?options: Silenceable -> obj option
        abstract clone: unit -> Model
        abstract destroy: ?options: ModelDestroyOptions -> obj option
        abstract escape: attribute: string -> string
        abstract has: attribute: string -> bool
        abstract hasChanged: ?attribute: string -> bool
        abstract isNew: unit -> bool
        abstract isValid: ?options: obj -> bool
        abstract previous: attribute: string -> obj option
        abstract previousAttributes: unit -> ResizeArray<obj option>
        abstract save: ?attributes: obj * ?options: ModelSaveOptions -> obj option
        abstract unset: attribute: string * ?options: Silenceable -> Model
        abstract validate: attributes: obj option * ?options: obj -> obj option
        abstract keys: unit -> ResizeArray<string>
        abstract values: unit -> ResizeArray<obj option>
        abstract pairs: unit -> ResizeArray<obj option>
        abstract invert: unit -> obj option
        abstract pick: keys: ResizeArray<string> -> obj option
        abstract pick: [<ParamArray>] keys: ResizeArray<string> -> obj option
        abstract pick: fn: (obj option -> obj option -> obj option -> obj option) -> obj option
        abstract omit: keys: ResizeArray<string> -> obj option
        abstract omit: [<ParamArray>] keys: ResizeArray<string> -> obj option
        abstract omit: fn: (obj option -> obj option -> obj option -> obj option) -> obj option
        abstract chain: unit -> obj option
        abstract isEmpty: unit -> bool
        abstract matches: attrs: obj option -> bool

    type [<AllowNullLiteral>] ModelStatic =
        /// Do not use, prefer TypeScript's extend functionality.
        abstract extend: properties: obj option * ?classProperties: obj -> obj option
        [<Emit "new $0($1...)">] abstract Create: ?attributes: obj * ?options: obj -> Model

    type [<AllowNullLiteral>] Collection<'TModel> =
        inherit ModelBase
        inherit Events
        abstract model: obj with get, set
        abstract models: ResizeArray<'TModel> with get, set
        abstract length: float with get, set
        abstract initialize: ?models: U2<ResizeArray<'TModel>, ResizeArray<Object>> * ?options: obj -> unit
        abstract fetch: ?options: CollectionFetchOptions -> JQueryXHR
        /// Specify a model attribute name (string) or function that will be used to sort the collection.
        abstract comparator: U3<string, TypeLiteral_03<'TModel>, TypeLiteral_04<'TModel>> with get, set
        abstract add: model: U2<TypeLiteral_05, 'TModel> * ?options: AddOptions -> 'TModel
        abstract add: models: ResizeArray<U2<TypeLiteral_05, 'TModel>> * ?options: AddOptions -> ResizeArray<'TModel>
        abstract at: index: float -> 'TModel
        /// Get a model from a collection, specified by an id, a cid, or by passing in a model.
        abstract get: id: U3<float, string, Model> -> 'TModel
        abstract has: key: U3<float, string, Model> -> bool
        abstract clone: unit -> Collection<'TModel>
        abstract create: attributes: obj option * ?options: ModelSaveOptions -> 'TModel
        abstract pluck: attribute: string -> ResizeArray<obj option>
        abstract push: model: 'TModel * ?options: AddOptions -> 'TModel
        abstract pop: ?options: Silenceable -> 'TModel
        abstract remove: model: U2<TypeLiteral_05, 'TModel> * ?options: Silenceable -> 'TModel
        abstract remove: models: ResizeArray<U2<TypeLiteral_05, 'TModel>> * ?options: Silenceable -> ResizeArray<'TModel>
        abstract reset: ?models: ResizeArray<'TModel> * ?options: Silenceable -> ResizeArray<'TModel>
        /// <summary>The set method performs a "smart" update of the collection with the passed list of models.
        /// If a model in the list isn't yet in the collection it will be added; if the model is already in the
        /// collection its attributes will be merged; and if the collection contains any models that aren't present
        /// in the list, they'll be removed. All of the appropriate "add", "remove", and "change" events are fired as
        /// this happens. Returns the touched models in the collection. If you'd like to customize the behavior, you can
        /// disable it with options: {add: false}, {remove: false}, or {merge: false}.</summary>
        /// <param name="models"></param>
        /// <param name="options"></param>
        abstract set: ?models: ResizeArray<'TModel> * ?options: CollectionSetOptions -> ResizeArray<'TModel>
        abstract shift: ?options: Silenceable -> 'TModel
        abstract sort: ?options: Silenceable -> Collection<'TModel>
        abstract unshift: model: 'TModel * ?options: AddOptions -> 'TModel
        abstract where: properties: obj option -> ResizeArray<'TModel>
        abstract findWhere: properties: obj option -> 'TModel
        abstract modelId: attrs: obj option -> obj option
        /// Return a shallow copy of this collection's models, using the same options as native Array#slice.
        abstract slice: ?min: float * ?max: float -> ResizeArray<'TModel>
        abstract all: ?iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> bool
        abstract any: ?iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> bool
        abstract chain: unit -> obj option
        abstract collect: iterator: Underscore.ListIterator<'TModel, 'TResult> * ?context: obj -> ResizeArray<'TResult>
        abstract contains: value: 'TModel -> bool
        abstract countBy: ?iterator: Underscore.ListIterator<'TModel, obj option> -> Underscore.Dictionary<float>
        abstract countBy: iterator: string -> Underscore.Dictionary<float>
        abstract detect: iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> 'TModel
        abstract difference: others: ResizeArray<'TModel> -> ResizeArray<'TModel>
        abstract drop: ?n: float -> ResizeArray<'TModel>
        abstract each: iterator: Underscore.ListIterator<'TModel, unit> * ?context: obj -> ResizeArray<'TModel>
        abstract every: iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> bool
        abstract filter: iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> ResizeArray<'TModel>
        abstract find: iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> 'TModel
        abstract findIndex: predicate: Underscore.ListIterator<'TModel, bool> * ?context: obj -> float
        abstract findLastIndex: predicate: Underscore.ListIterator<'TModel, bool> * ?context: obj -> float
        abstract first: unit -> 'TModel
        abstract first: n: float -> ResizeArray<'TModel>
        abstract foldl: iterator: Underscore.MemoIterator<'TModel, 'TResult> * ?memo: 'TResult * ?context: obj -> 'TResult
        abstract foldr: iterator: Underscore.MemoIterator<'TModel, 'TResult> * ?memo: 'TResult * ?context: obj -> 'TResult
        abstract forEach: iterator: Underscore.ListIterator<'TModel, unit> * ?context: obj -> ResizeArray<'TModel>
        abstract groupBy: iterator: Underscore.ListIterator<'TModel, obj option> * ?context: obj -> Underscore.Dictionary<ResizeArray<'TModel>>
        abstract groupBy: iterator: string * ?context: obj -> Underscore.Dictionary<ResizeArray<'TModel>>
        abstract head: unit -> 'TModel
        abstract head: n: float -> ResizeArray<'TModel>
        abstract ``include``: value: 'TModel -> bool
        abstract includes: value: 'TModel -> bool
        abstract indexBy: iterator: Underscore.ListIterator<'TModel, obj option> * ?context: obj -> Underscore.Dictionary<'TModel>
        abstract indexBy: iterator: string * ?context: obj -> Underscore.Dictionary<'TModel>
        abstract indexOf: value: 'TModel * ?isSorted: bool -> float
        abstract initial: unit -> 'TModel
        abstract initial: n: float -> ResizeArray<'TModel>
        abstract inject: iterator: Underscore.MemoIterator<'TModel, 'TResult> * ?memo: 'TResult * ?context: obj -> 'TResult
        abstract invoke: methodName: string * [<ParamArray>] args: ResizeArray<obj option> -> obj option
        abstract isEmpty: unit -> bool
        abstract last: unit -> 'TModel
        abstract last: n: float -> ResizeArray<'TModel>
        abstract lastIndexOf: value: 'TModel * ?from: float -> float
        abstract map: iterator: Underscore.ListIterator<'TModel, 'TResult> * ?context: obj -> ResizeArray<'TResult>
        abstract max: ?iterator: Underscore.ListIterator<'TModel, obj option> * ?context: obj -> 'TModel
        abstract min: ?iterator: Underscore.ListIterator<'TModel, obj option> * ?context: obj -> 'TModel
        abstract partition: iterator: Underscore.ListIterator<'TModel, bool> -> ResizeArray<ResizeArray<'TModel>>
        abstract reduce: iterator: Underscore.MemoIterator<'TModel, 'TResult> * ?memo: 'TResult * ?context: obj -> 'TResult
        abstract reduceRight: iterator: Underscore.MemoIterator<'TModel, 'TResult> * ?memo: 'TResult * ?context: obj -> 'TResult
        abstract reject: iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> ResizeArray<'TModel>
        abstract rest: ?n: float -> ResizeArray<'TModel>
        abstract sample: unit -> 'TModel
        abstract sample: n: float -> ResizeArray<'TModel>
        abstract select: iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> ResizeArray<'TModel>
        abstract shuffle: unit -> ResizeArray<'TModel>
        abstract size: unit -> float
        abstract some: ?iterator: Underscore.ListIterator<'TModel, bool> * ?context: obj -> bool
        abstract sortBy: ?iterator: Underscore.ListIterator<'TModel, 'TSort> * ?context: obj -> ResizeArray<'TModel>
        abstract sortBy: iterator: string * ?context: obj -> ResizeArray<'TModel>
        abstract tail: ?n: float -> ResizeArray<'TModel>
        abstract take: unit -> 'TModel
        abstract take: n: float -> ResizeArray<'TModel>
        abstract toArray: unit -> ResizeArray<'TModel>
        /// Sets the url property (or function) on a collection to reference its location on the server.
        abstract url: U2<string, (unit -> string)> with get, set
        abstract without: [<ParamArray>] values: ResizeArray<'TModel> -> ResizeArray<'TModel>

    type [<AllowNullLiteral>] CollectionStatic =
        /// Do not use, prefer TypeScript's extend functionality.
        abstract extend: properties: obj option * ?classProperties: obj -> obj option
        [<Emit "new $0($1...)">] abstract Create: ?models: U2<ResizeArray<'TModel>, ResizeArray<Object>> * ?options: obj -> Collection<'TModel>

    type [<AllowNullLiteral>] Router =
        inherit EventsMixin
        inherit Events
        /// Routes hash or a method returning the routes hash that maps URLs with parameters to methods on your Router.
        /// For assigning routes as object hash, do it like this: this.routes = <any>{ "route": callback, ... };
        /// That works only if you set it in the constructor or the initialize method.
        abstract routes: U2<RoutesHash, obj option> with get, set
        abstract initialize: ?options: RouterOptions -> unit
        abstract route: route: U2<string, RegExp> * name: string * ?callback: Function -> Router
        abstract navigate: fragment: string * ?options: NavigateOptions -> Router
        abstract navigate: fragment: string * ?trigger: bool -> Router
        abstract execute: callback: Function * args: ResizeArray<obj option> * name: string -> unit

    type [<AllowNullLiteral>] RouterStatic =
        /// Do not use, prefer TypeScript's extend functionality.
        abstract extend: properties: obj option * ?classProperties: obj -> obj option
        [<Emit "new $0($1...)">] abstract Create: ?options: RouterOptions -> Router

    type [<AllowNullLiteral>] History =
        inherit EventsMixin
        inherit Events
        abstract handlers: ResizeArray<obj option> with get, set
        abstract interval: float with get, set
        abstract start: ?options: HistoryOptions -> bool
        abstract getHash: ?window: Window -> string
        abstract getFragment: ?fragment: string -> string
        abstract decodeFragment: fragment: string -> string
        abstract getSearch: unit -> string
        abstract stop: unit -> unit
        abstract route: route: U2<string, RegExp> * callback: Function -> float
        abstract checkUrl: ?e: obj -> unit
        abstract getPath: unit -> string
        abstract matchRoot: unit -> bool
        abstract atRoot: unit -> bool
        abstract loadUrl: ?fragmentOverride: string -> bool
        abstract navigate: fragment: string * ?options: obj -> bool
        abstract options: obj option with get, set

    type [<AllowNullLiteral>] HistoryStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> History
        abstract started: bool with get, set

    type [<AllowNullLiteral>] ViewOptions<'TModel> =
        abstract model: 'TModel option with get, set
        abstract collection: Backbone.Collection<obj option> option with get, set
        abstract el: obj option with get, set
        abstract events: EventsHash option with get, set
        abstract id: string option with get, set
        abstract className: string option with get, set
        abstract tagName: string option with get, set
        abstract attributes: TypeLiteral_06 option with get, set

    type [<AllowNullLiteral>] View<'TModel> =
        inherit EventsMixin
        inherit Events
        abstract initialize: ?options: ViewOptions<'TModel> -> unit
        /// Events hash or a method returning the events hash that maps events/selectors to methods on your View.
        /// For assigning events as object hash, do it like this: this.events = <any>{ "event:selector": callback, ... };
        /// That works only if you set it in the constructor or the initialize method.
        abstract events: unit -> EventsHash
        abstract ``$``: selector: string -> JQuery
        abstract model: 'TModel with get, set
        abstract collection: Collection<'TModel> with get, set
        abstract setElement: element: U2<HTMLElement, JQuery> * ?``delegate``: bool -> View<'TModel>
        abstract id: string with get, set
        abstract cid: string with get, set
        abstract className: string with get, set
        abstract tagName: string with get, set
        abstract el: obj option with get, set
        abstract ``$el``: JQuery with get, set
        abstract setElement: element: obj option -> View<'TModel>
        abstract attributes: obj option with get, set
        abstract ``$``: selector: obj option -> JQuery
        abstract render: unit -> View<'TModel>
        abstract remove: unit -> View<'TModel>
        abstract delegateEvents: ?events: EventsHash -> obj option
        abstract ``delegate``: eventName: string * selector: string * listener: Function -> View<'TModel>
        abstract undelegateEvents: unit -> obj option
        abstract undelegate: eventName: string * ?selector: string * ?listener: Function -> View<'TModel>
        abstract _ensureElement: unit -> unit

    type [<AllowNullLiteral>] ViewStatic =
        /// Do not use, prefer TypeScript's extend functionality.
        abstract extend: properties: obj option * ?classProperties: obj -> obj option
        [<Emit "new $0($1...)">] abstract Create: ?options: ViewOptions<'TModel> -> View<'TModel>

    type [<AllowNullLiteral>] TypeLiteral_05 =
        interface end

    type [<AllowNullLiteral>] TypeLiteral_06 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: id: string -> obj option with get, set

    type [<AllowNullLiteral>] TypeLiteral_04<'TModel> =
        abstract bivarianceHack: compare: 'TModel * ?``to``: 'TModel -> float

    type [<AllowNullLiteral>] TypeLiteral_03<'TModel> =
        abstract bivarianceHack: element: 'TModel -> U2<float, string>

    type [<AllowNullLiteral>] TypeLiteral_02 =
        [<Emit "$0($1...)">] abstract Invoke: eventObject: JQuery.TriggeredEvent -> unit

    type [<AllowNullLiteral>] TypeLiteral_01 =
        [<Emit "$0($1...)">] abstract Invoke: [<ParamArray>] urlParts: ResizeArray<string> -> unit
