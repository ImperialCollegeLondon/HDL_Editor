/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/Main/Main.fsproj");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./.fable/fable-library.2.2.3/Reflection.js":
/*!**************************************************!*\
  !*** ./.fable/fable-library.2.2.3/Reflection.js ***!
  \**************************************************/
/*! exports provided: CaseInfo, TypeInfo, getGenerics, equals, compare, type, record, union, tuple, delegate, lambda, option, list, array, obj, unit, char, string, bool, int8, uint8, int16, uint16, int32, uint32, float32, float64, decimal, name, fullName, namespace, isArray, getElementType, isGenericType, getGenericTypeDefinition, getUnionCases, getRecordElements, getTupleElements, getFunctionElements, isUnion, isRecord, isTuple, isFunction, getUnionFields, getUnionCaseFields, getRecordFields, getRecordField, getTupleFields, getTupleField, makeUnion, makeRecord, makeTuple, getCaseTag, getCaseName, getCaseFields */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CaseInfo", function() { return CaseInfo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TypeInfo", function() { return TypeInfo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getGenerics", function() { return getGenerics; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "equals", function() { return equals; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compare", function() { return compare; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "type", function() { return type; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "record", function() { return record; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "union", function() { return union; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tuple", function() { return tuple; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "delegate", function() { return delegate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "lambda", function() { return lambda; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "option", function() { return option; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "list", function() { return list; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "array", function() { return array; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "obj", function() { return obj; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "unit", function() { return unit; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "char", function() { return _char; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "string", function() { return string; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "bool", function() { return bool; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "int8", function() { return int8; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "uint8", function() { return uint8; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "int16", function() { return int16; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "uint16", function() { return uint16; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "int32", function() { return int32; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "uint32", function() { return uint32; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "float32", function() { return float32; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "float64", function() { return float64; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "decimal", function() { return decimal; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "name", function() { return name; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fullName", function() { return fullName; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "namespace", function() { return namespace; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isArray", function() { return isArray; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getElementType", function() { return getElementType; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isGenericType", function() { return isGenericType; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getGenericTypeDefinition", function() { return getGenericTypeDefinition; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getUnionCases", function() { return getUnionCases; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getRecordElements", function() { return getRecordElements; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getTupleElements", function() { return getTupleElements; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getFunctionElements", function() { return getFunctionElements; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isUnion", function() { return isUnion; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isRecord", function() { return isRecord; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isTuple", function() { return isTuple; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isFunction", function() { return isFunction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getUnionFields", function() { return getUnionFields; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getUnionCaseFields", function() { return getUnionCaseFields; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getRecordFields", function() { return getRecordFields; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getRecordField", function() { return getRecordField; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getTupleFields", function() { return getTupleFields; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getTupleField", function() { return getTupleField; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "makeUnion", function() { return makeUnion; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "makeRecord", function() { return makeRecord; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "makeTuple", function() { return makeTuple; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getCaseTag", function() { return getCaseTag; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getCaseName", function() { return getCaseName; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getCaseFields", function() { return getCaseFields; });
/* harmony import */ var _babel_runtime_helpers_construct__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/construct */ "./node_modules/@babel/runtime/helpers/construct.js");
/* harmony import */ var _babel_runtime_helpers_construct__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_construct__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @babel/runtime/helpers/toConsumableArray */ "./node_modules/@babel/runtime/helpers/toConsumableArray.js");
/* harmony import */ var _babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @babel/runtime/helpers/createClass */ "./node_modules/@babel/runtime/helpers/createClass.js");
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @babel/runtime/helpers/classCallCheck */ "./node_modules/@babel/runtime/helpers/classCallCheck.js");
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var _Types__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./Types */ "./.fable/fable-library.2.2.3/Types.js");
/* harmony import */ var _Util__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./Util */ "./.fable/fable-library.2.2.3/Util.js");






var CaseInfo = function CaseInfo(declaringType, tag, name, fields) {
  _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_3___default()(this, CaseInfo);

  this.declaringType = declaringType;
  this.tag = tag;
  this.name = name;
  this.fields = fields;
};
var TypeInfo =
/*#__PURE__*/
function () {
  function TypeInfo(fullname, generics, constructor, fields, cases) {
    _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_3___default()(this, TypeInfo);

    this.fullname = fullname;
    this.generics = generics;
    this.constructor = constructor;
    this.fields = fields;
    this.cases = cases;
  }

  _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_2___default()(TypeInfo, [{
    key: "toString",
    value: function toString() {
      return fullName(this);
    }
  }, {
    key: "Equals",
    value: function Equals(other) {
      return equals(this, other);
    }
  }, {
    key: "CompareTo",
    value: function CompareTo(other) {
      return compare(this, other);
    }
  }]);

  return TypeInfo;
}();
function getGenerics(t) {
  return t.generics != null ? t.generics : [];
}
function equals(t1, t2) {
  return t1.fullname === t2.fullname && Object(_Util__WEBPACK_IMPORTED_MODULE_5__["equalArraysWith"])(getGenerics(t1), getGenerics(t2), equals);
} // System.Type is not comparable in .NET, but let's implement this
// in case users want to create a dictionary with types as keys

function compare(t1, t2) {
  if (t1.fullname !== t2.fullname) {
    return t1.fullname < t2.fullname ? -1 : 1;
  } else {
    return Object(_Util__WEBPACK_IMPORTED_MODULE_5__["compareArraysWith"])(getGenerics(t1), getGenerics(t2), compare);
  }
}
function type(fullname, generics) {
  return new TypeInfo(fullname, generics);
}
function record(fullname, generics, constructor, fields) {
  return new TypeInfo(fullname, generics, constructor, fields);
}
function union(fullname, generics, constructor, cases) {
  var t = new TypeInfo(fullname, generics, constructor, null, function () {
    return cases().map(function (x, i) {
      return typeof x === "string" ? new CaseInfo(t, i, x) : new CaseInfo(t, i, x[0], x[1]);
    });
  });
  return t;
}
function tuple() {
  for (var _len = arguments.length, generics = new Array(_len), _key = 0; _key < _len; _key++) {
    generics[_key] = arguments[_key];
  }

  return new TypeInfo("System.Tuple`" + generics.length, generics);
}
function delegate() {
  for (var _len2 = arguments.length, generics = new Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
    generics[_key2] = arguments[_key2];
  }

  return new TypeInfo("System.Func`" + generics.length, generics);
}
function lambda(argType, returnType) {
  return new TypeInfo("Microsoft.FSharp.Core.FSharpFunc`2", [argType, returnType]);
}
function option(generic) {
  return new TypeInfo("Microsoft.FSharp.Core.FSharpOption`1", [generic]);
}
function list(generic) {
  return new TypeInfo("Microsoft.FSharp.Collections.FSharpList`1", [generic]);
}
function array(generic) {
  return new TypeInfo(generic.fullname + "[]", [generic]);
}
var obj = new TypeInfo("System.Object");
var unit = new TypeInfo("Microsoft.FSharp.Core.Unit");

var _char = new TypeInfo("System.Char");


var string = new TypeInfo("System.String");
var bool = new TypeInfo("System.Boolean");
var int8 = new TypeInfo("System.SByte");
var uint8 = new TypeInfo("System.Byte");
var int16 = new TypeInfo("System.Int16");
var uint16 = new TypeInfo("System.UInt16");
var int32 = new TypeInfo("System.Int32");
var uint32 = new TypeInfo("System.UInt32");
var float32 = new TypeInfo("System.Single");
var float64 = new TypeInfo("System.Double");
var decimal = new TypeInfo("System.Decimal");
function name(info) {
  if (Array.isArray(info)) {
    return info[0];
  } else if (info instanceof CaseInfo) {
    return info.name;
  } else {
    var i = info.fullname.lastIndexOf(".");
    return i === -1 ? info.fullname : info.fullname.substr(i + 1);
  }
}
function fullName(t) {
  var gen = t.generics != null && !isArray(t) ? t.generics : [];

  if (gen.length > 0) {
    return t.fullname + "[" + gen.map(function (x) {
      return fullName(x);
    }).join(",") + "]";
  } else {
    return t.fullname;
  }
}
function namespace(t) {
  var i = t.fullname.lastIndexOf(".");
  return i === -1 ? "" : t.fullname.substr(0, i);
}
function isArray(t) {
  return t.fullname.endsWith("[]");
}
function getElementType(t) {
  return isArray(t) ? t.generics[0] : null;
}
function isGenericType(t) {
  return t.generics != null && t.generics.length > 0;
}
/**
 * This doesn't replace types for fields (records) or cases (unions)
 * but it should be enough for type comparison purposes
 */

function getGenericTypeDefinition(t) {
  return t.generics == null ? t : new TypeInfo(t.fullname, t.generics.map(function () {
    return obj;
  }));
} // FSharpType

function getUnionCases(t) {
  if (t.cases != null) {
    return t.cases();
  } else {
    throw new Error("".concat(t.fullname, " is not an F# union type"));
  }
}
function getRecordElements(t) {
  if (t.fields != null) {
    return t.fields();
  } else {
    throw new Error("".concat(t.fullname, " is not an F# record type"));
  }
}
function getTupleElements(t) {
  if (isTuple(t)) {
    return t.generics;
  } else {
    throw new Error("".concat(t.fullname, " is not a tuple type"));
  }
}
function getFunctionElements(t) {
  if (isFunction(t)) {
    var gen = t.generics;
    return [gen[0], gen[1]];
  } else {
    throw new Error("".concat(t.fullname, " is not an F# function type"));
  }
}
function isUnion(t) {
  return t instanceof TypeInfo ? t.cases != null : t instanceof _Types__WEBPACK_IMPORTED_MODULE_4__["Union"];
}
function isRecord(t) {
  return t instanceof TypeInfo ? t.fields != null : t instanceof _Types__WEBPACK_IMPORTED_MODULE_4__["Record"];
}
function isTuple(t) {
  return t.fullname.startsWith("System.Tuple");
} // In .NET this is false for delegates

function isFunction(t) {
  return t.fullname === "Microsoft.FSharp.Core.FSharpFunc`2";
} // FSharpValue

function getUnionFields(v, t) {
  var cases = getUnionCases(t);
  var case_ = cases[v.tag];

  if (case_ == null) {
    throw new Error("Cannot find case ".concat(v.name, " in union type"));
  }

  return [case_, v.fields];
}
function getUnionCaseFields(uci) {
  return uci.fields == null ? [] : uci.fields.map(function (t, i) {
    return ["Data" + i, t];
  });
}
function getRecordFields(v) {
  return Object.keys(v).map(function (k) {
    return v[k];
  });
}
function getRecordField(v, field) {
  return v[field[0]];
}
function getTupleFields(v) {
  return v;
}
function getTupleField(v, i) {
  return v[i];
}
function makeUnion(uci, values) {
  var expectedLength = (uci.fields || []).length;

  if (values.length !== expectedLength) {
    throw new Error("Expected an array of length ".concat(expectedLength, " but got ").concat(values.length));
  }

  return _babel_runtime_helpers_construct__WEBPACK_IMPORTED_MODULE_0___default()(uci.declaringType.constructor, [uci.tag, uci.name].concat(_babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_1___default()(values)));
}
function makeRecord(t, values) {
  var fields = getRecordElements(t);

  if (fields.length !== values.length) {
    throw new Error("Expected an array of length ".concat(fields.length, " but got ").concat(values.length));
  }

  return _babel_runtime_helpers_construct__WEBPACK_IMPORTED_MODULE_0___default()(t.constructor, _babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_1___default()(values));
}
function makeTuple(values, t) {
  return values;
} // Fable.Core.Reflection

function assertUnion(x) {
  if (!(x instanceof _Types__WEBPACK_IMPORTED_MODULE_4__["Union"])) {
    throw new Error("Value is not an F# union type");
  }
}

function getCaseTag(x) {
  assertUnion(x);
  return x.tag;
}
function getCaseName(x) {
  assertUnion(x);
  return x.name;
}
function getCaseFields(x) {
  assertUnion(x);
  return x.fields;
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Types.js":
/*!*********************************************!*\
  !*** ./.fable/fable-library.2.2.3/Types.js ***!
  \*********************************************/
/*! exports provided: declare, SystemObject, List, Union, Record, anonRecord, FSharpRef, Exception, isException, FSharpException, MatchFailureException, Attribute */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "declare", function() { return declare; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "SystemObject", function() { return SystemObject; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "List", function() { return List; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Union", function() { return Union; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Record", function() { return Record; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "anonRecord", function() { return anonRecord; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FSharpRef", function() { return FSharpRef; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Exception", function() { return Exception; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isException", function() { return isException; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FSharpException", function() { return FSharpException; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MatchFailureException", function() { return MatchFailureException; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Attribute", function() { return Attribute; });
/* harmony import */ var _Util__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./Util */ "./.fable/fable-library.2.2.3/Util.js");


function sameType(x, y) {
  return y != null && Object.getPrototypeOf(x).constructor === Object.getPrototypeOf(y).constructor;
} // Taken from Babel helpers


function inherits(subClass, superClass) {
  // if (typeof superClass !== "function" && superClass !== null) {
  //   throw new TypeError(
  //     "Super expression must either be null or a function, not " +
  //       typeof superClass
  //   );
  // }
  subClass.prototype = Object.create(superClass && superClass.prototype, {
    constructor: {
      value: subClass,
      enumerable: false,
      writable: true,
      configurable: true
    }
  }); // if (superClass)
  //   Object.setPrototypeOf
  //     ? Object.setPrototypeOf(subClass, superClass)
  //     : (subClass.__proto__ = superClass);
}

function declare(cons, superClass) {
  inherits(cons, superClass || SystemObject);
  return cons;
}
function SystemObject() {}

SystemObject.prototype.toString = function () {
  var _this = this;

  return "{" + Object.keys(this).map(function (k) {
    return k + " = " + String(_this[k]);
  }).join(";\n ") + "}";
};

SystemObject.prototype.GetHashCode = function () {
  return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["identityHash"])(this);
};

SystemObject.prototype.Equals = function (other) {
  return this === other;
};

function compareList(self, other) {
  if (self === other) {
    return 0;
  } else {
    if (other == null) {
      return -1;
    }

    while (self.tail != null) {
      if (other.tail == null) {
        return 1;
      }

      var res = Object(_Util__WEBPACK_IMPORTED_MODULE_0__["compare"])(self.head, other.head);

      if (res !== 0) {
        return res;
      }

      self = self.tail;
      other = other.tail;
    }

    return other.tail == null ? 0 : -1;
  }
}

function List(head, tail) {
  this.head = head;
  this.tail = tail;
}

List.prototype.toString = function () {
  return "[" + Array.from(this).map(function (x) {
    return String(x);
  }).join("; ") + "]";
};

List.prototype.toJSON = function () {
  return Array.from(this);
};

List.prototype[Symbol.iterator] = function () {
  var cur = this;
  return {
    next: function next() {
      var tmp = cur;
      cur = cur.tail;
      return {
        done: tmp.tail == null,
        value: tmp.head
      };
    }
  };
};

List.prototype.GetHashCode = function () {
  var hashes = Array.from(this).map(_Util__WEBPACK_IMPORTED_MODULE_0__["structuralHash"]);
  return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["combineHashCodes"])(hashes);
};

List.prototype.Equals = function (other) {
  return compareList(this, other) === 0;
};

List.prototype.CompareTo = function (other) {
  return compareList(this, other);
};

function Union(tag, name) {
  this.tag = tag | 0;
  this.name = name;

  for (var _len = arguments.length, fields = new Array(_len > 2 ? _len - 2 : 0), _key = 2; _key < _len; _key++) {
    fields[_key - 2] = arguments[_key];
  }

  this.fields = fields;
}

Union.prototype.toString = function () {
  var len = this.fields.length;

  if (len === 0) {
    return this.name;
  } else if (len === 1) {
    return this.name + " " + String(this.fields[0]);
  } else {
    return this.name + " (" + this.fields.map(function (x) {
      return String(x);
    }).join(",") + ")";
  }
};

Union.prototype.toJSON = function () {
  return this.fields.length === 0 ? this.name : [this.name].concat(this.fields);
};

Union.prototype.GetHashCode = function () {
  var hashes = this.fields.map(function (x) {
    return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["structuralHash"])(x);
  });
  hashes.splice(0, 0, Object(_Util__WEBPACK_IMPORTED_MODULE_0__["numberHash"])(this.tag));
  return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["combineHashCodes"])(hashes);
};

Union.prototype.Equals = function (other) {
  return this === other || sameType(this, other) && this.tag === other.tag && Object(_Util__WEBPACK_IMPORTED_MODULE_0__["equalArrays"])(this.fields, other.fields);
};

Union.prototype.CompareTo = function (other) {
  if (this === other) {
    return 0;
  } else if (!sameType(this, other)) {
    return -1;
  } else if (this.tag === other.tag) {
    return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["compareArrays"])(this.fields, other.fields);
  } else {
    return this.tag < other.tag ? -1 : 1;
  }
};

function recordToJson(record, getFieldNames) {
  var o = {};
  var keys = getFieldNames == null ? Object.keys(record) : getFieldNames(record);

  for (var i = 0; i < keys.length; i++) {
    o[keys[i]] = record[keys[i]];
  }

  return o;
}

function recordEquals(self, other, getFieldNames) {
  if (self === other) {
    return true;
  } else if (!sameType(self, other)) {
    return false;
  } else {
    var thisNames = getFieldNames == null ? Object.keys(self) : getFieldNames(self);

    for (var i = 0; i < thisNames.length; i++) {
      if (!Object(_Util__WEBPACK_IMPORTED_MODULE_0__["equals"])(self[thisNames[i]], other[thisNames[i]])) {
        return false;
      }
    }

    return true;
  }
}

function recordCompare(self, other, getFieldNames) {
  if (self === other) {
    return 0;
  } else if (!sameType(self, other)) {
    return -1;
  } else {
    var thisNames = getFieldNames == null ? Object.keys(self) : getFieldNames(self);

    for (var i = 0; i < thisNames.length; i++) {
      var result = Object(_Util__WEBPACK_IMPORTED_MODULE_0__["compare"])(self[thisNames[i]], other[thisNames[i]]);

      if (result !== 0) {
        return result;
      }
    }

    return 0;
  }
}

function Record() {}

Record.prototype.toString = function () {
  var _this2 = this;

  return "{" + Object.keys(this).map(function (k) {
    return k + " = " + String(_this2[k]);
  }).join(";\n ") + "}";
};

Record.prototype.toJSON = function () {
  return recordToJson(this);
};

Record.prototype.GetHashCode = function () {
  var _this3 = this;

  var hashes = Object.keys(this).map(function (k) {
    return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["structuralHash"])(_this3[k]);
  });
  return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["combineHashCodes"])(hashes);
};

Record.prototype.Equals = function (other) {
  return recordEquals(this, other);
};

Record.prototype.CompareTo = function (other) {
  return recordCompare(this, other);
};

function anonRecord(o) {
  return Object.assign(Object.create(Record.prototype), o);
}
var FSharpRef = declare(function FSharpRef(contents) {
  this.contents = contents;
}, Record); // EXCEPTIONS

var Exception = declare(function Exception(msg) {
  this.stack = Error().stack;
  this.message = msg;
});
function isException(x) {
  return x instanceof Error || x instanceof Exception;
}

function getFSharpExceptionFieldNames(self) {
  return Object.keys(self).filter(function (k) {
    return k !== "message" && k !== "stack";
  });
}

var FSharpException = declare(function FSharpException() {
  Exception.call(this);
}, Exception);

FSharpException.prototype.toString = function () {
  var _this4 = this;

  var fieldNames = getFSharpExceptionFieldNames(this);
  var len = fieldNames.length;

  if (len === 0) {
    return this.message;
  } else if (len === 1) {
    return this.message + " " + String(this[fieldNames[0]]);
  } else {
    return this.message + " (" + fieldNames.map(function (k) {
      return String(_this4[k]);
    }).join(",") + ")";
  }
};

FSharpException.prototype.toJSON = function () {
  return recordToJson(this, getFSharpExceptionFieldNames);
};

FSharpException.prototype.GetHashCode = function () {
  var _this5 = this;

  var hashes = getFSharpExceptionFieldNames(this).map(function (k) {
    return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["structuralHash"])(_this5[k]);
  });
  return Object(_Util__WEBPACK_IMPORTED_MODULE_0__["combineHashCodes"])(hashes);
};

FSharpException.prototype.Equals = function (other) {
  return recordEquals(this, other, getFSharpExceptionFieldNames);
};

FSharpException.prototype.CompareTo = function (other) {
  return recordCompare(this, other, getFSharpExceptionFieldNames);
};

var MatchFailureException = declare(function MatchFailureException(arg1, arg2, arg3) {
  this.arg1 = arg1;
  this.arg2 = arg2 | 0;
  this.arg3 = arg3 | 0;
  this.message = "The match cases were incomplete";
}, FSharpException);
var Attribute = declare(function Attribute() {});

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Util.js":
/*!********************************************!*\
  !*** ./.fable/fable-library.2.2.3/Util.js ***!
  \********************************************/
/*! exports provided: extend, isDisposable, Comparer, comparerFromEqualityComparer, containsValue, tryGetValue, addToSet, assertEqual, assertNotEqual, Lazy, lazyFromValue, padWithZeros, padLeftAndRightWithZeros, dateOffset, int16ToString, int32ToString, ObjectRef, stringHash, numberHash, combineHashCodes, identityHash, structuralHash, isArray, isIterable, equalArraysWith, equalArrays, equals, compareDates, comparePrimitives, compareArraysWith, compareArrays, compareObjects, compare, min, max, createAtom, createObj, jsOptions, round, sign, randomNext, randomBytes, unescapeDataString, escapeDataString, escapeUriString, count, clear, uncurry, curry, partialApply, addToDict, getItemFromDict */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "extend", function() { return extend; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isDisposable", function() { return isDisposable; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Comparer", function() { return Comparer; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "comparerFromEqualityComparer", function() { return comparerFromEqualityComparer; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "containsValue", function() { return containsValue; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryGetValue", function() { return tryGetValue; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addToSet", function() { return addToSet; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "assertEqual", function() { return assertEqual; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "assertNotEqual", function() { return assertNotEqual; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Lazy", function() { return Lazy; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "lazyFromValue", function() { return lazyFromValue; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "padWithZeros", function() { return padWithZeros; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "padLeftAndRightWithZeros", function() { return padLeftAndRightWithZeros; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "dateOffset", function() { return dateOffset; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "int16ToString", function() { return int16ToString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "int32ToString", function() { return int32ToString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ObjectRef", function() { return ObjectRef; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "stringHash", function() { return stringHash; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "numberHash", function() { return numberHash; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "combineHashCodes", function() { return combineHashCodes; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "identityHash", function() { return identityHash; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "structuralHash", function() { return structuralHash; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isArray", function() { return isArray; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isIterable", function() { return isIterable; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "equalArraysWith", function() { return equalArraysWith; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "equalArrays", function() { return equalArrays; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "equals", function() { return equals; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareDates", function() { return compareDates; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "comparePrimitives", function() { return comparePrimitives; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareArraysWith", function() { return compareArraysWith; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareArrays", function() { return compareArrays; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareObjects", function() { return compareObjects; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compare", function() { return compare; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "min", function() { return min; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "max", function() { return max; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "createAtom", function() { return createAtom; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "createObj", function() { return createObj; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "jsOptions", function() { return jsOptions; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "round", function() { return round; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "sign", function() { return sign; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "randomNext", function() { return randomNext; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "randomBytes", function() { return randomBytes; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "unescapeDataString", function() { return unescapeDataString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "escapeDataString", function() { return escapeDataString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "escapeUriString", function() { return escapeUriString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "count", function() { return count; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "clear", function() { return clear; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "uncurry", function() { return uncurry; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "curry", function() { return curry; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "partialApply", function() { return partialApply; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addToDict", function() { return addToDict; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getItemFromDict", function() { return getItemFromDict; });
/* harmony import */ var _babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/typeof */ "./node_modules/@babel/runtime/helpers/typeof.js");
/* harmony import */ var _babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @babel/runtime/helpers/createClass */ "./node_modules/@babel/runtime/helpers/createClass.js");
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @babel/runtime/helpers/classCallCheck */ "./node_modules/@babel/runtime/helpers/classCallCheck.js");
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2__);



// tslint:disable:ban-types
// Object.assign flattens getters and setters
// See https://stackoverflow.com/questions/37054596/js-es5-how-to-assign-objects-with-setters-and-getters
function extend(target) {
  for (var _len = arguments.length, sources = new Array(_len > 1 ? _len - 1 : 0), _key = 1; _key < _len; _key++) {
    sources[_key - 1] = arguments[_key];
  }

  for (var _i = 0, _sources = sources; _i < _sources.length; _i++) {
    var source = _sources[_i];

    for (var _i2 = 0, _Object$keys = Object.keys(source); _i2 < _Object$keys.length; _i2++) {
      var key = _Object$keys[_i2];
      Object.defineProperty(target, key, Object.getOwnPropertyDescriptor(source, key));
    }
  }

  return target;
}
function isDisposable(x) {
  return x != null && typeof x.Dispose === "function";
}
var Comparer = function Comparer(f) {
  _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2___default()(this, Comparer);

  this.Compare = f || compare;
};
function comparerFromEqualityComparer(comparer) {
  // Sometimes IEqualityComparer also implements IComparer
  if (typeof comparer.Compare === "function") {
    return new Comparer(comparer.Compare);
  } else {
    return new Comparer(function (x, y) {
      var xhash = comparer.GetHashCode(x);
      var yhash = comparer.GetHashCode(y);

      if (xhash === yhash) {
        return comparer.Equals(x, y) ? 0 : -1;
      } else {
        return xhash < yhash ? -1 : 1;
      }
    });
  }
} // TODO: Move these three methods to Map and Set modules

function containsValue(v, map) {
  var _iteratorNormalCompletion = true;
  var _didIteratorError = false;
  var _iteratorError = undefined;

  try {
    for (var _iterator = map[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
      var kv = _step.value;

      if (equals(v, kv[1])) {
        return true;
      }
    }
  } catch (err) {
    _didIteratorError = true;
    _iteratorError = err;
  } finally {
    try {
      if (!_iteratorNormalCompletion && _iterator["return"] != null) {
        _iterator["return"]();
      }
    } finally {
      if (_didIteratorError) {
        throw _iteratorError;
      }
    }
  }

  return false;
}
function tryGetValue(map, key, defaultValue) {
  return map.has(key) ? [true, map.get(key)] : [false, defaultValue];
}
function addToSet(v, set) {
  if (set.has(v)) {
    return false;
  }

  set.add(v);
  return true;
}
function assertEqual(actual, expected, msg) {
  if (!equals(actual, expected)) {
    throw Object.assign(new Error(msg || "Expected: ".concat(expected, " - Actual: ").concat(actual)), {
      actual: actual,
      expected: expected
    });
  }
}
function assertNotEqual(actual, expected, msg) {
  if (equals(actual, expected)) {
    throw Object.assign(new Error(msg || "Expected: ".concat(expected, " - Actual: ").concat(actual)), {
      actual: actual,
      expected: expected
    });
  }
}
var Lazy =
/*#__PURE__*/
function () {
  function Lazy(factory) {
    _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2___default()(this, Lazy);

    this.factory = factory;
    this.isValueCreated = false;
  }

  _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1___default()(Lazy, [{
    key: "Value",
    get: function get() {
      if (!this.isValueCreated) {
        this.createdValue = this.factory();
        this.isValueCreated = true;
      }

      return this.createdValue;
    }
  }, {
    key: "IsValueCreated",
    get: function get() {
      return this.isValueCreated;
    }
  }]);

  return Lazy;
}();
function lazyFromValue(v) {
  return new Lazy(function () {
    return v;
  });
}
function padWithZeros(i, length) {
  var str = i.toString(10);

  while (str.length < length) {
    str = "0" + str;
  }

  return str;
}
function padLeftAndRightWithZeros(i, lengthLeft, lengthRight) {
  var str = i.toString(10);

  while (str.length < lengthLeft) {
    str = "0" + str;
  }

  while (str.length < lengthRight) {
    str = str + "0";
  }

  return str;
}
function dateOffset(date) {
  var date1 = date;
  return typeof date1.offset === "number" ? date1.offset : date.kind === 1
  /* UTC */
  ? 0 : date.getTimezoneOffset() * -60000;
}
function int16ToString(i, radix) {
  i = i < 0 && radix != null && radix !== 10 ? 0xFFFF + i + 1 : i;
  return i.toString(radix);
}
function int32ToString(i, radix) {
  i = i < 0 && radix != null && radix !== 10 ? 0xFFFFFFFF + i + 1 : i;
  return i.toString(radix);
}
var ObjectRef =
/*#__PURE__*/
function () {
  function ObjectRef() {
    _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2___default()(this, ObjectRef);
  }

  _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1___default()(ObjectRef, null, [{
    key: "id",
    value: function id(o) {
      if (!ObjectRef.idMap.has(o)) {
        ObjectRef.idMap.set(o, ++ObjectRef.count);
      }

      return ObjectRef.idMap.get(o);
    }
  }]);

  return ObjectRef;
}();
ObjectRef.idMap = new WeakMap();
ObjectRef.count = 0;
function stringHash(s) {
  var i = 0;
  var h = 5381;
  var len = s.length;

  while (i < len) {
    h = h * 33 ^ s.charCodeAt(i++);
  }

  return h;
}
function numberHash(x) {
  return x * 2654435761 | 0;
} // From https://stackoverflow.com/a/37449594

function combineHashCodes(hashes) {
  if (hashes.length === 0) {
    return 0;
  }

  return hashes.reduce(function (h1, h2) {
    return (h1 << 5) + h1 ^ h2;
  });
}
function identityHash(x) {
  if (x == null) {
    return 0;
  }

  switch (_babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0___default()(x)) {
    case "boolean":
      return x ? 1 : 0;

    case "number":
      return numberHash(x);

    case "string":
      return stringHash(x);

    default:
      return numberHash(ObjectRef.id(x));
  }
}
function structuralHash(x) {
  if (x == null) {
    return 0;
  }

  switch (_babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0___default()(x)) {
    case "boolean":
      return x ? 1 : 0;

    case "number":
      return numberHash(x);

    case "string":
      return stringHash(x);

    default:
      {
        if (typeof x.GetHashCode === "function") {
          return x.GetHashCode();
        } else if (isArray(x)) {
          var ar = x;
          var len = ar.length;
          var hashes = new Array(len);

          for (var i = 0; i < len; i++) {
            hashes[i] = structuralHash(ar[i]);
          }

          return combineHashCodes(hashes);
        } else {
          return stringHash(String(x));
        }
      }
  }
}
function isArray(x) {
  return Array.isArray(x) || ArrayBuffer.isView(x);
}
function isIterable(x) {
  return x != null && _babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0___default()(x) === "object" && Symbol.iterator in x;
}
function equalArraysWith(x, y, eq) {
  if (x == null) {
    return y == null;
  }

  if (y == null) {
    return false;
  }

  if (x.length !== y.length) {
    return false;
  }

  for (var i = 0; i < x.length; i++) {
    if (!eq(x[i], y[i])) {
      return false;
    }
  }

  return true;
}
function equalArrays(x, y) {
  return equalArraysWith(x, y, equals);
} // export function equalObjects(x: { [k: string]: any }, y: { [k: string]: any }): boolean {
//   if (x == null) { return y == null; }
//   if (y == null) { return false; }
//   const xKeys = Object.keys(x);
//   const yKeys = Object.keys(y);
//   if (xKeys.length !== yKeys.length) {
//     return false;
//   }
//   xKeys.sort();
//   yKeys.sort();
//   for (let i = 0; i < xKeys.length; i++) {
//     if (xKeys[i] !== yKeys[i] || !equals(x[xKeys[i]], y[yKeys[i]])) {
//       return false;
//     }
//   }
//   return true;
// }

function equals(x, y) {
  if (x === y) {
    return true;
  } else if (x == null) {
    return y == null;
  } else if (y == null) {
    return false;
  } else if (_babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0___default()(x) !== "object") {
    return false;
  } else if (typeof x.Equals === "function") {
    return x.Equals(y);
  } else if (isArray(x)) {
    return isArray(y) && equalArrays(x, y);
  } else if (x instanceof Date) {
    return y instanceof Date && compareDates(x, y) === 0;
  } else {
    return false;
  }
}
function compareDates(x, y) {
  var xtime;
  var ytime; // DateTimeOffset and DateTime deals with equality differently.

  if ("offset" in x && "offset" in y) {
    xtime = x.getTime();
    ytime = y.getTime();
  } else {
    xtime = x.getTime() + dateOffset(x);
    ytime = y.getTime() + dateOffset(y);
  }

  return xtime === ytime ? 0 : xtime < ytime ? -1 : 1;
}
function comparePrimitives(x, y) {
  return x === y ? 0 : x < y ? -1 : 1;
}
function compareArraysWith(x, y, comp) {
  if (x == null) {
    return y == null ? 0 : 1;
  }

  if (y == null) {
    return -1;
  }

  if (x.length !== y.length) {
    return x.length < y.length ? -1 : 1;
  }

  for (var i = 0, j = 0; i < x.length; i++) {
    j = comp(x[i], y[i]);

    if (j !== 0) {
      return j;
    }
  }

  return 0;
}
function compareArrays(x, y) {
  return compareArraysWith(x, y, compare);
}
function compareObjects(x, y) {
  if (x == null) {
    return y == null ? 0 : 1;
  }

  if (y == null) {
    return -1;
  }

  var xKeys = Object.keys(x);
  var yKeys = Object.keys(y);

  if (xKeys.length !== yKeys.length) {
    return xKeys.length < yKeys.length ? -1 : 1;
  }

  xKeys.sort();
  yKeys.sort();

  for (var i = 0, j = 0; i < xKeys.length; i++) {
    var key = xKeys[i];

    if (key !== yKeys[i]) {
      return key < yKeys[i] ? -1 : 1;
    } else {
      j = compare(x[key], y[key]);

      if (j !== 0) {
        return j;
      }
    }
  }

  return 0;
}
function compare(x, y) {
  if (x === y) {
    return 0;
  } else if (x == null) {
    return y == null ? 0 : -1;
  } else if (y == null) {
    return 1;
  } else if (_babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_0___default()(x) !== "object") {
    return x < y ? -1 : 1;
  } else if (typeof x.CompareTo === "function") {
    return x.CompareTo(y);
  } else if (isArray(x)) {
    return isArray(y) && compareArrays(x, y);
  } else if (x instanceof Date) {
    return y instanceof Date && compareDates(x, y);
  } else {
    return 1;
  }
}
function min(comparer, x, y) {
  return comparer(x, y) < 0 ? x : y;
}
function max(comparer, x, y) {
  return comparer(x, y) > 0 ? x : y;
}
function createAtom(value) {
  var atom = value;
  return function (value) {
    if (value === void 0) {
      return atom;
    } else {
      atom = value;
      return void 0;
    }
  };
}
var CaseRules = {
  None: 0,
  LowerFirst: 1
};

function changeCase(str, caseRule) {
  switch (caseRule) {
    case CaseRules.LowerFirst:
      return str.charAt(0).toLowerCase() + str.slice(1);

    case CaseRules.None:
    default:
      return str;
  }
}

function createObj(fields) {
  var caseRule = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : CaseRules.None;

  function fail(kvPair) {
    throw new Error("Cannot infer key and value of " + String(kvPair));
  }

  var o = {};
  var definedCaseRule = caseRule;
  var _iteratorNormalCompletion2 = true;
  var _didIteratorError2 = false;
  var _iteratorError2 = undefined;

  try {
    for (var _iterator2 = fields[Symbol.iterator](), _step2; !(_iteratorNormalCompletion2 = (_step2 = _iterator2.next()).done); _iteratorNormalCompletion2 = true) {
      var kvPair = _step2.value;
      var _caseRule = CaseRules.None;

      if (kvPair == null) {
        fail(kvPair);
      } // Deflate unions and use the defined case rule


      if (typeof kvPair.toJSON === "function") {
        kvPair = kvPair.toJSON();
        _caseRule = definedCaseRule;
      }

      if (Array.isArray(kvPair)) {
        switch (kvPair.length) {
          case 0:
            fail(kvPair);
            break;

          case 1:
            o[changeCase(kvPair[0], _caseRule)] = true;
            break;

          case 2:
            var value = kvPair[1];
            o[changeCase(kvPair[0], _caseRule)] = value;
            break;

          default:
            o[changeCase(kvPair[0], _caseRule)] = kvPair.slice(1);
        }
      } else if (typeof kvPair === "string") {
        o[changeCase(kvPair, _caseRule)] = true;
      } else {
        fail(kvPair);
      }
    }
  } catch (err) {
    _didIteratorError2 = true;
    _iteratorError2 = err;
  } finally {
    try {
      if (!_iteratorNormalCompletion2 && _iterator2["return"] != null) {
        _iterator2["return"]();
      }
    } finally {
      if (_didIteratorError2) {
        throw _iteratorError2;
      }
    }
  }

  return o;
}
function jsOptions(mutator) {
  var opts = {};
  mutator(opts);
  return opts;
}
function round(value) {
  var digits = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : 0;
  var m = Math.pow(10, digits);
  var n = +(digits ? value * m : value).toFixed(8);
  var i = Math.floor(n);
  var f = n - i;
  var e = 1e-8;
  var r = f > 0.5 - e && f < 0.5 + e ? i % 2 === 0 ? i : i + 1 : Math.round(n);
  return digits ? r / m : r;
}
function sign(x) {
  return x > 0 ? 1 : x < 0 ? -1 : 0;
}
function randomNext(min, max) {
  return Math.floor(Math.random() * (max - min)) + min;
}
function randomBytes(buffer) {
  if (buffer == null) {
    throw new Error("Buffer cannot be null");
  }

  for (var i = 0; i < buffer.length; i += 6) {
    // Pick random 48-bit number. Fill buffer in 2 24-bit chunks to avoid bitwise truncation.
    var r = Math.floor(Math.random() * 281474976710656); // Low 24 bits = chunk 1.

    var rhi = Math.floor(r / 16777216); // High 24 bits shifted via division = chunk 2.

    for (var j = 0; j < 6 && i + j < buffer.length; j++) {
      if (j === 3) {
        r = rhi;
      }

      buffer[i + j] = r & 255;
      r >>>= 8;
    }
  }
}
function unescapeDataString(s) {
  // https://stackoverflow.com/a/4458580/524236
  return decodeURIComponent(s.replace(/\+/g, "%20"));
}
function escapeDataString(s) {
  return encodeURIComponent(s).replace(/!/g, "%21").replace(/'/g, "%27").replace(/\(/g, "%28").replace(/\)/g, "%29").replace(/\*/g, "%2A");
}
function escapeUriString(s) {
  return encodeURI(s);
} // ICollection.Clear and Count members can be called on Arrays
// or Dictionaries so we need a runtime check (see #1120)

function count(col) {
  return isArray(col) ? col.length : col.size;
}
function clear(col) {
  if (isArray(col)) {
    col.splice(0);
  } else {
    col.clear();
  }
}
function uncurry(arity, f) {
  // f may be a function option with None value
  if (f == null) {
    return null;
  } // return (...args: any[]) => {
  //   // In some cases there may be more arguments applied than necessary
  //   // (e.g. index when mapping an array), discard them
  //   args = args.slice(0, arity);
  //   let res = f;
  //   while (args.length > 0) {
  //       const curArgs = args.splice(0, res.length);
  //       res = res.apply(null, curArgs);
  //   }
  //   return res;
  // };


  switch (arity) {
    case 2:
      return function (a1, a2) {
        return f(a1)(a2);
      };

    case 3:
      return function (a1, a2, a3) {
        return f(a1)(a2)(a3);
      };

    case 4:
      return function (a1, a2, a3, a4) {
        return f(a1)(a2)(a3)(a4);
      };

    case 5:
      return function (a1, a2, a3, a4, a5) {
        return f(a1)(a2)(a3)(a4)(a5);
      };

    case 6:
      return function (a1, a2, a3, a4, a5, a6) {
        return f(a1)(a2)(a3)(a4)(a5)(a6);
      };

    case 7:
      return function (a1, a2, a3, a4, a5, a6, a7) {
        return f(a1)(a2)(a3)(a4)(a5)(a6)(a7);
      };

    case 8:
      return function (a1, a2, a3, a4, a5, a6, a7, a8) {
        return f(a1)(a2)(a3)(a4)(a5)(a6)(a7)(a8);
      };

    default:
      throw new Error("Uncurrying to more than 8-arity is not supported: " + arity);
  }
}
function curry(arity, f) {
  if (f == null) {
    return null;
  }

  switch (arity) {
    case 2:
      return function (a1) {
        return function (a2) {
          return f(a1, a2);
        };
      };

    case 3:
      return function (a1) {
        return function (a2) {
          return function (a3) {
            return f(a1, a2, a3);
          };
        };
      };

    case 4:
      return function (a1) {
        return function (a2) {
          return function (a3) {
            return function (a4) {
              return f(a1, a2, a3, a4);
            };
          };
        };
      };

    case 5:
      return function (a1) {
        return function (a2) {
          return function (a3) {
            return function (a4) {
              return function (a5) {
                return f(a1, a2, a3, a4, a5);
              };
            };
          };
        };
      };

    case 6:
      return function (a1) {
        return function (a2) {
          return function (a3) {
            return function (a4) {
              return function (a5) {
                return function (a6) {
                  return f(a1, a2, a3, a4, a5, a6);
                };
              };
            };
          };
        };
      };

    case 7:
      return function (a1) {
        return function (a2) {
          return function (a3) {
            return function (a4) {
              return function (a5) {
                return function (a6) {
                  return function (a7) {
                    return f(a1, a2, a3, a4, a5, a6, a7);
                  };
                };
              };
            };
          };
        };
      };

    case 8:
      return function (a1) {
        return function (a2) {
          return function (a3) {
            return function (a4) {
              return function (a5) {
                return function (a6) {
                  return function (a7) {
                    return function (a8) {
                      return f(a1, a2, a3, a4, a5, a6, a7, a8);
                    };
                  };
                };
              };
            };
          };
        };
      };

    default:
      throw new Error("Currying to more than 8-arity is not supported: " + arity);
  }
}
function partialApply(arity, f, args) {
  if (f == null) {
    return null;
  } else {
    switch (arity) {
      case 1:
        // Wrap arguments to make sure .concat doesn't destruct arrays. Example
        // [1,2].concat([3,4],5)   --> [1,2,3,4,5]    // fails
        // [1,2].concat([[3,4],5]) --> [1,2,[3,4],5]  // ok
        return function (a1) {
          return f.apply(null, args.concat([a1]));
        };

      case 2:
        return function (a1) {
          return function (a2) {
            return f.apply(null, args.concat([a1, a2]));
          };
        };

      case 3:
        return function (a1) {
          return function (a2) {
            return function (a3) {
              return f.apply(null, args.concat([a1, a2, a3]));
            };
          };
        };

      case 4:
        return function (a1) {
          return function (a2) {
            return function (a3) {
              return function (a4) {
                return f.apply(null, args.concat([a1, a2, a3, a4]));
              };
            };
          };
        };

      case 5:
        return function (a1) {
          return function (a2) {
            return function (a3) {
              return function (a4) {
                return function (a5) {
                  return f.apply(null, args.concat([a1, a2, a3, a4, a5]));
                };
              };
            };
          };
        };

      case 6:
        return function (a1) {
          return function (a2) {
            return function (a3) {
              return function (a4) {
                return function (a5) {
                  return function (a6) {
                    return f.apply(null, args.concat([a1, a2, a3, a4, a5, a6]));
                  };
                };
              };
            };
          };
        };

      case 7:
        return function (a1) {
          return function (a2) {
            return function (a3) {
              return function (a4) {
                return function (a5) {
                  return function (a6) {
                    return function (a7) {
                      return f.apply(null, args.concat([a1, a2, a3, a4, a5, a6, a7]));
                    };
                  };
                };
              };
            };
          };
        };

      case 8:
        return function (a1) {
          return function (a2) {
            return function (a3) {
              return function (a4) {
                return function (a5) {
                  return function (a6) {
                    return function (a7) {
                      return function (a8) {
                        return f.apply(null, args.concat([a1, a2, a3, a4, a5, a6, a7, a8]));
                      };
                    };
                  };
                };
              };
            };
          };
        };

      default:
        throw new Error("Partially applying to more than 8-arity is not supported: " + arity);
    }
  }
}
function addToDict(dict, k, v) {
  if (dict.has(k)) {
    throw new Error("An item with the same key has already been added. Key: " + k);
  }

  dict.set(k, v);
}
function getItemFromDict(map, key) {
  if (map.has(key)) {
    return map.get(key);
  } else {
    throw new Error("The given key '".concat(key, "' was not present in the dictionary."));
  }
}

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/arrayWithoutHoles.js":
/*!******************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/arrayWithoutHoles.js ***!
  \******************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _arrayWithoutHoles(arr) {
  if (Array.isArray(arr)) {
    for (var i = 0, arr2 = new Array(arr.length); i < arr.length; i++) {
      arr2[i] = arr[i];
    }

    return arr2;
  }
}

module.exports = _arrayWithoutHoles;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/classCallCheck.js":
/*!***************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/classCallCheck.js ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _classCallCheck(instance, Constructor) {
  if (!(instance instanceof Constructor)) {
    throw new TypeError("Cannot call a class as a function");
  }
}

module.exports = _classCallCheck;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/construct.js":
/*!**********************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/construct.js ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

var setPrototypeOf = __webpack_require__(/*! ./setPrototypeOf */ "./node_modules/@babel/runtime/helpers/setPrototypeOf.js");

function isNativeReflectConstruct() {
  if (typeof Reflect === "undefined" || !Reflect.construct) return false;
  if (Reflect.construct.sham) return false;
  if (typeof Proxy === "function") return true;

  try {
    Date.prototype.toString.call(Reflect.construct(Date, [], function () {}));
    return true;
  } catch (e) {
    return false;
  }
}

function _construct(Parent, args, Class) {
  if (isNativeReflectConstruct()) {
    module.exports = _construct = Reflect.construct;
  } else {
    module.exports = _construct = function _construct(Parent, args, Class) {
      var a = [null];
      a.push.apply(a, args);
      var Constructor = Function.bind.apply(Parent, a);
      var instance = new Constructor();
      if (Class) setPrototypeOf(instance, Class.prototype);
      return instance;
    };
  }

  return _construct.apply(null, arguments);
}

module.exports = _construct;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/createClass.js":
/*!************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/createClass.js ***!
  \************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _defineProperties(target, props) {
  for (var i = 0; i < props.length; i++) {
    var descriptor = props[i];
    descriptor.enumerable = descriptor.enumerable || false;
    descriptor.configurable = true;
    if ("value" in descriptor) descriptor.writable = true;
    Object.defineProperty(target, descriptor.key, descriptor);
  }
}

function _createClass(Constructor, protoProps, staticProps) {
  if (protoProps) _defineProperties(Constructor.prototype, protoProps);
  if (staticProps) _defineProperties(Constructor, staticProps);
  return Constructor;
}

module.exports = _createClass;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/iterableToArray.js":
/*!****************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/iterableToArray.js ***!
  \****************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _iterableToArray(iter) {
  if (Symbol.iterator in Object(iter) || Object.prototype.toString.call(iter) === "[object Arguments]") return Array.from(iter);
}

module.exports = _iterableToArray;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/nonIterableSpread.js":
/*!******************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/nonIterableSpread.js ***!
  \******************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _nonIterableSpread() {
  throw new TypeError("Invalid attempt to spread non-iterable instance");
}

module.exports = _nonIterableSpread;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/setPrototypeOf.js":
/*!***************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/setPrototypeOf.js ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _setPrototypeOf(o, p) {
  module.exports = _setPrototypeOf = Object.setPrototypeOf || function _setPrototypeOf(o, p) {
    o.__proto__ = p;
    return o;
  };

  return _setPrototypeOf(o, p);
}

module.exports = _setPrototypeOf;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/toConsumableArray.js":
/*!******************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/toConsumableArray.js ***!
  \******************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

var arrayWithoutHoles = __webpack_require__(/*! ./arrayWithoutHoles */ "./node_modules/@babel/runtime/helpers/arrayWithoutHoles.js");

var iterableToArray = __webpack_require__(/*! ./iterableToArray */ "./node_modules/@babel/runtime/helpers/iterableToArray.js");

var nonIterableSpread = __webpack_require__(/*! ./nonIterableSpread */ "./node_modules/@babel/runtime/helpers/nonIterableSpread.js");

function _toConsumableArray(arr) {
  return arrayWithoutHoles(arr) || iterableToArray(arr) || nonIterableSpread();
}

module.exports = _toConsumableArray;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/typeof.js":
/*!*******************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/typeof.js ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _typeof2(obj) { if (typeof Symbol === "function" && typeof Symbol.iterator === "symbol") { _typeof2 = function _typeof2(obj) { return typeof obj; }; } else { _typeof2 = function _typeof2(obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; }; } return _typeof2(obj); }

function _typeof(obj) {
  if (typeof Symbol === "function" && _typeof2(Symbol.iterator) === "symbol") {
    module.exports = _typeof = function _typeof(obj) {
      return _typeof2(obj);
    };
  } else {
    module.exports = _typeof = function _typeof(obj) {
      return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : _typeof2(obj);
    };
  }

  return _typeof(obj);
}

module.exports = _typeof;

/***/ }),

/***/ "./src/Main/Main.fs":
/*!**************************!*\
  !*** ./src/Main/Main.fs ***!
  \**************************/
/*! exports provided: mainWindow, MenuItemClass, MenuItemClass$reflection, MenuItemClass$$$$002Ector$$7A0753F0, createMainWindow */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mainWindow", function() { return mainWindow; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MenuItemClass", function() { return MenuItemClass; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MenuItemClass$reflection", function() { return MenuItemClass$reflection; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MenuItemClass$$$$002Ector$$7A0753F0", function() { return MenuItemClass$$$$002Ector$$7A0753F0; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "createMainWindow", function() { return createMainWindow; });
/* harmony import */ var _fable_fable_library_2_2_3_Util_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/Util.js */ "./.fable/fable-library.2.2.3/Util.js");
/* harmony import */ var _fable_fable_library_2_2_3_Types_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/Types.js */ "./.fable/fable-library.2.2.3/Types.js");
/* harmony import */ var _fable_fable_library_2_2_3_Reflection_js__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/Reflection.js */ "./.fable/fable-library.2.2.3/Reflection.js");
/* harmony import */ var electron__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! electron */ "electron");
/* harmony import */ var electron__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(electron__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var path__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! path */ "path");
/* harmony import */ var path__WEBPACK_IMPORTED_MODULE_4___default = /*#__PURE__*/__webpack_require__.n(path__WEBPACK_IMPORTED_MODULE_4__);
/* harmony import */ var url__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! url */ "url");
/* harmony import */ var url__WEBPACK_IMPORTED_MODULE_5___default = /*#__PURE__*/__webpack_require__.n(url__WEBPACK_IMPORTED_MODULE_5__);
/* harmony import */ var fs__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! fs */ "fs");
/* harmony import */ var fs__WEBPACK_IMPORTED_MODULE_6___default = /*#__PURE__*/__webpack_require__.n(fs__WEBPACK_IMPORTED_MODULE_6__);







var mainWindow = Object(_fable_fable_library_2_2_3_Util_js__WEBPACK_IMPORTED_MODULE_0__["createAtom"])(null);
var MenuItemClass = Object(_fable_fable_library_2_2_3_Types_js__WEBPACK_IMPORTED_MODULE_1__["declare"])(function Main_MenuItemClass(clickData, typeData, labelData, sublabelData, acceleratorData, iconData, enabledData, visibleData, checkedData, submenuData, idData, positionData, roleData) {
  var $this$$1 = this;
  $this$$1["clickData@27"] = clickData;
  $this$$1["typeData@28"] = typeData;
  $this$$1["labelData@29"] = labelData;
  $this$$1["sublabelData@30"] = sublabelData;
  $this$$1["acceleratorData@31"] = acceleratorData;
  $this$$1["iconData@32"] = iconData;
  $this$$1["enabledData@33"] = enabledData;
  $this$$1["visibleData@34"] = visibleData;
  $this$$1["checkedData@35"] = checkedData;
  $this$$1["submenuData@36"] = submenuData;
  $this$$1["idData@37"] = idData;
  $this$$1["positionData@38"] = positionData;
  $this$$1["roleData@39"] = roleData;
});
function MenuItemClass$reflection() {
  return Object(_fable_fable_library_2_2_3_Reflection_js__WEBPACK_IMPORTED_MODULE_2__["type"])("Main.MenuItemClass");
}
function MenuItemClass$$$$002Ector$$7A0753F0(clickData, typeData, labelData, sublabelData, acceleratorData, iconData, enabledData, visibleData, checkedData, submenuData, idData, positionData, roleData) {
  return this instanceof MenuItemClass ? MenuItemClass.call(this, clickData, typeData, labelData, sublabelData, acceleratorData, iconData, enabledData, visibleData, checkedData, submenuData, idData, positionData, roleData) : new MenuItemClass(clickData, typeData, labelData, sublabelData, acceleratorData, iconData, enabledData, visibleData, checkedData, submenuData, idData, positionData, roleData);
}
Object.defineProperty(MenuItemClass.prototype, "click", {
  "get": function get() {
    var self$ = this;
    return self$["clickData@27"];
  },
  "set": function set(clickVal) {
    var self$$$1 = this;
    self$$$1["clickData@27"] = clickVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "type", {
  "get": function get() {
    var self$$$2 = this;
    return self$$$2["typeData@28"];
  },
  "set": function set(typeVal) {
    var self$$$3 = this;
    self$$$3["typeData@28"] = typeVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "label", {
  "get": function get() {
    var self$$$4 = this;
    return self$$$4["labelData@29"];
  },
  "set": function set(labelVal) {
    var self$$$5 = this;
    self$$$5["labelData@29"] = labelVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "sublabel", {
  "get": function get() {
    var self$$$6 = this;
    return self$$$6["sublabelData@30"];
  },
  "set": function set(sublabelVal) {
    var self$$$7 = this;
    self$$$7["sublabelData@30"] = sublabelVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "accelerator", {
  "get": function get() {
    var self$$$8 = this;
    return self$$$8["acceleratorData@31"];
  },
  "set": function set(acceleratorVal) {
    var self$$$9 = this;
    self$$$9["acceleratorData@31"] = acceleratorVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "icon", {
  "get": function get() {
    var self$$$10 = this;
    return self$$$10["iconData@32"];
  },
  "set": function set(iconVal) {
    var self$$$11 = this;
    self$$$11["iconData@32"] = iconVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "enabled", {
  "get": function get() {
    var self$$$12 = this;
    return self$$$12["enabledData@33"];
  },
  "set": function set(enabledVal) {
    var self$$$13 = this;
    self$$$13["enabledData@33"] = enabledVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "visible", {
  "get": function get() {
    var self$$$14 = this;
    return self$$$14["visibleData@34"];
  },
  "set": function set(visibleVal) {
    var self$$$15 = this;
    self$$$15["visibleData@34"] = visibleVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "checked", {
  "get": function get() {
    var self$$$16 = this;
    return self$$$16["checkedData@35"];
  },
  "set": function set(checkedVal) {
    var self$$$17 = this;
    self$$$17["checkedData@35"] = checkedVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "submenu", {
  "get": function get() {
    var self$$$18 = this;
    return self$$$18["submenuData@36"];
  },
  "set": function set(submenuVal) {
    var self$$$19 = this;
    self$$$19["submenuData@36"] = submenuVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "id", {
  "get": function get() {
    var self$$$20 = this;
    return self$$$20["idData@37"];
  },
  "set": function set(idVal) {
    var self$$$21 = this;
    self$$$21["idData@37"] = idVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "position", {
  "get": function get() {
    var self$$$22 = this;
    return self$$$22["positionData@38"];
  },
  "set": function set(positionVal) {
    var self$$$23 = this;
    self$$$23["positionData@38"] = positionVal;
  }
});
Object.defineProperty(MenuItemClass.prototype, "role", {
  "get": function get() {
    var self$$$24 = this;
    return self$$$24["roleData@39"];
  },
  "set": function set(roleVal) {
    var self$$$25 = this;
    self$$$25["roleData@39"] = roleVal;
  }
});
function createMainWindow() {
  var options = {};
  options.width = 1366;
  options.height = 1024;
  options.autoHideMenuBar = false;
  var window$ = new electron__WEBPACK_IMPORTED_MODULE_3___default.a.BrowserWindow(options);
  var opts = {};
  opts.pathname = path__WEBPACK_IMPORTED_MODULE_4__["join"](__dirname, "../index.html");
  opts.protocol = "file:";
  window$.loadURL(url__WEBPACK_IMPORTED_MODULE_5__["format"](opts));
  var menuTemplate = [];
  var menuItem = MenuItemClass$$$$002Ector$$7A0753F0(null, "normal", "Quit", null, "Ctrl+Q", null, true, true, false, null, null, null, "quit");
  throw 1;
  menuTemplate.push(menuItem);
  var systemMenu = electron__WEBPACK_IMPORTED_MODULE_3___default.a.Menu.buildFromTemplate(menuTemplate);
  electron__WEBPACK_IMPORTED_MODULE_3___default.a.Menu.setApplicationMenu(systemMenu);
  fs__WEBPACK_IMPORTED_MODULE_6__["watch"](path__WEBPACK_IMPORTED_MODULE_4__["join"](__dirname, "renderer.js"), function (_arg2, _arg1) {
    window$.webContents.reloadIgnoringCache();
  });
  window$.on("closed", function () {
    mainWindow(null);
  });
  window$.maximize();
  mainWindow(window$);
}
electron__WEBPACK_IMPORTED_MODULE_3___default.a.app.on("ready", function () {
  createMainWindow();
});
electron__WEBPACK_IMPORTED_MODULE_3___default.a.app.on("window-all-closed", function () {
  if (process.platform !== "darwin") {
    electron__WEBPACK_IMPORTED_MODULE_3___default.a.app.quit();
  }
});
electron__WEBPACK_IMPORTED_MODULE_3___default.a.app.on("activate", function () {
  if (mainWindow() == null) {
    createMainWindow();
  }
});

/***/ }),

/***/ "./src/Main/Main.fsproj":
/*!******************************!*\
  !*** ./src/Main/Main.fsproj ***!
  \******************************/
/*! exports provided: mainWindow, MenuItemClass, MenuItemClass$reflection, MenuItemClass$$$$002Ector$$7A0753F0, createMainWindow */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _Main_fs__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./Main.fs */ "./src/Main/Main.fs");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "mainWindow", function() { return _Main_fs__WEBPACK_IMPORTED_MODULE_0__["mainWindow"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "MenuItemClass", function() { return _Main_fs__WEBPACK_IMPORTED_MODULE_0__["MenuItemClass"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "MenuItemClass$reflection", function() { return _Main_fs__WEBPACK_IMPORTED_MODULE_0__["MenuItemClass$reflection"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "MenuItemClass$$$$002Ector$$7A0753F0", function() { return _Main_fs__WEBPACK_IMPORTED_MODULE_0__["MenuItemClass$$$$002Ector$$7A0753F0"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "createMainWindow", function() { return _Main_fs__WEBPACK_IMPORTED_MODULE_0__["createMainWindow"]; });



/***/ }),

/***/ "electron":
/*!***************************!*\
  !*** external "electron" ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = require("electron");

/***/ }),

/***/ "fs":
/*!*********************!*\
  !*** external "fs" ***!
  \*********************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = require("fs");

/***/ }),

/***/ "path":
/*!***********************!*\
  !*** external "path" ***!
  \***********************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = require("path");

/***/ }),

/***/ "url":
/*!**********************!*\
  !*** external "url" ***!
  \**********************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = require("url");

/***/ })

/******/ });
//# sourceMappingURL=main.js.map