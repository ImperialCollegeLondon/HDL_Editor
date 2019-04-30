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
/******/ 	return __webpack_require__(__webpack_require__.s = "./src/Renderer/Renderer.fsproj");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./.fable/fable-library.2.2.3/Date.js":
/*!********************************************!*\
  !*** ./.fable/fable-library.2.2.3/Date.js ***!
  \********************************************/
/*! exports provided: offsetRegex, dateOffsetToString, dateToHalfUTCString, toString, default, fromTicks, fromDateTimeOffset, getTicks, minValue, maxValue, parseRaw, parse, tryParse, create, now, utcNow, today, isLeapYear, daysInMonth, toUniversalTime, toLocalTime, timeOfDay, date, day, hour, millisecond, minute, month, second, year, dayOfWeek, dayOfYear, add, addDays, addHours, addMinutes, addSeconds, addMilliseconds, addYears, addMonths, subtract, toLongDateString, toShortDateString, toLongTimeString, toShortTimeString, equals, compare, compareTo, op_Addition, op_Subtraction, isDaylightSavingTime */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "offsetRegex", function() { return offsetRegex; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "dateOffsetToString", function() { return dateOffsetToString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "dateToHalfUTCString", function() { return dateToHalfUTCString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toString", function() { return toString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "default", function() { return DateTime; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromTicks", function() { return fromTicks; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromDateTimeOffset", function() { return fromDateTimeOffset; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getTicks", function() { return getTicks; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "minValue", function() { return minValue; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "maxValue", function() { return maxValue; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "parseRaw", function() { return parseRaw; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "parse", function() { return parse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryParse", function() { return tryParse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "create", function() { return create; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "now", function() { return now; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "utcNow", function() { return utcNow; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "today", function() { return today; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isLeapYear", function() { return isLeapYear; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "daysInMonth", function() { return daysInMonth; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toUniversalTime", function() { return toUniversalTime; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toLocalTime", function() { return toLocalTime; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "timeOfDay", function() { return timeOfDay; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "date", function() { return date; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "day", function() { return day; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "hour", function() { return hour; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "millisecond", function() { return millisecond; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "minute", function() { return minute; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "month", function() { return month; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "second", function() { return second; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "year", function() { return year; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "dayOfWeek", function() { return dayOfWeek; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "dayOfYear", function() { return dayOfYear; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "add", function() { return add; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addDays", function() { return addDays; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addHours", function() { return addHours; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addMinutes", function() { return addMinutes; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addSeconds", function() { return addSeconds; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addMilliseconds", function() { return addMilliseconds; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addYears", function() { return addYears; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "addMonths", function() { return addMonths; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "subtract", function() { return subtract; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toLongDateString", function() { return toLongDateString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toShortDateString", function() { return toShortDateString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toLongTimeString", function() { return toLongTimeString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toShortTimeString", function() { return toShortTimeString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "equals", function() { return equals; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compare", function() { return compare; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareTo", function() { return compareTo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_Addition", function() { return op_Addition; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_Subtraction", function() { return op_Subtraction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isDaylightSavingTime", function() { return isDaylightSavingTime; });
/* harmony import */ var _Long__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./Long */ "./.fable/fable-library.2.2.3/Long.js");
/* harmony import */ var _Util__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Util */ "./.fable/fable-library.2.2.3/Util.js");
/**
 * DateTimeOffset functions.
 *
 * Note: Date instances are always DateObjects in local
 * timezone (because JS dates are all kinds of messed up).
 * A local date returns UTC epoc when `.getTime()` is called.
 *
 * Basically; invariant: date.getTime() always return UTC time.
 */


var offsetRegex = /(?:Z|[+-](\d+):?([0-5]?\d)?)\s*$/;
function dateOffsetToString(offset) {
  var isMinus = offset < 0;
  offset = Math.abs(offset);
  var hours = ~~(offset / 3600000);
  var minutes = offset % 3600000 / 60000;
  return (isMinus ? "-" : "+") + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(hours, 2) + ":" + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(minutes, 2);
}
function dateToHalfUTCString(date, half) {
  var str = date.toISOString();
  return half === "first" ? str.substring(0, str.indexOf("T")) : str.substring(str.indexOf("T") + 1, str.length - 1);
}

function dateToISOString(d, utc) {
  if (utc) {
    return d.toISOString();
  } else {
    // JS Date is always local
    var printOffset = d.kind == null ? true : d.kind === 2
    /* Local */
    ;
    return Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(d.getFullYear(), 4) + "-" + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(d.getMonth() + 1, 2) + "-" + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(d.getDate(), 2) + "T" + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(d.getHours(), 2) + ":" + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(d.getMinutes(), 2) + ":" + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(d.getSeconds(), 2) + "." + Object(_Util__WEBPACK_IMPORTED_MODULE_1__["padWithZeros"])(d.getMilliseconds(), 3) + (printOffset ? dateOffsetToString(d.getTimezoneOffset() * -60000) : "");
  }
}

function dateToISOStringWithOffset(dateWithOffset, offset) {
  var str = dateWithOffset.toISOString();
  return str.substring(0, str.length - 1) + dateOffsetToString(offset);
}

function dateToStringWithCustomFormat(date, format, utc) {
  return format.replace(/(\w)\1*/g, function (match) {
    var rep = match;

    switch (match.substring(0, 1)) {
      case "y":
        var y = utc ? date.getUTCFullYear() : date.getFullYear();
        rep = match.length < 4 ? y % 100 : y;
        break;

      case "M":
        rep = (utc ? date.getUTCMonth() : date.getMonth()) + 1;
        break;

      case "d":
        rep = utc ? date.getUTCDate() : date.getDate();
        break;

      case "H":
        rep = utc ? date.getUTCHours() : date.getHours();
        break;

      case "h":
        var h = utc ? date.getUTCHours() : date.getHours();
        rep = h > 12 ? h % 12 : h;
        break;

      case "m":
        rep = utc ? date.getUTCMinutes() : date.getMinutes();
        break;

      case "s":
        rep = utc ? date.getUTCSeconds() : date.getSeconds();
        break;

      case "f":
        rep = utc ? date.getUTCMilliseconds() : date.getMilliseconds();
        break;
    }

    if (rep !== match && rep < 10 && match.length > 1) {
      rep = "0" + rep;
    }

    return rep;
  });
}

function dateToStringWithOffset(date, format) {
  var d = new Date(date.getTime() + date.offset);

  if (typeof format !== "string") {
    return d.toISOString().replace(/\.\d+/, "").replace(/[A-Z]|\.\d+/g, " ") + dateOffsetToString(date.offset);
  } else if (format.length === 1) {
    switch (format) {
      case "D":
      case "d":
        return dateToHalfUTCString(d, "first");

      case "T":
      case "t":
        return dateToHalfUTCString(d, "second");

      case "O":
      case "o":
        return dateToISOStringWithOffset(d, date.offset);

      default:
        throw new Error("Unrecognized Date print format");
    }
  } else {
    return dateToStringWithCustomFormat(d, format, true);
  }
}

function dateToStringWithKind(date, format) {
  var utc = date.kind === 1
  /* UTC */
  ;

  if (typeof format !== "string") {
    return utc ? date.toUTCString() : date.toLocaleString();
  } else if (format.length === 1) {
    switch (format) {
      case "D":
      case "d":
        return utc ? dateToHalfUTCString(date, "first") : date.toLocaleDateString();

      case "T":
      case "t":
        return utc ? dateToHalfUTCString(date, "second") : date.toLocaleTimeString();

      case "O":
      case "o":
        return dateToISOString(date, utc);

      default:
        throw new Error("Unrecognized Date print format");
    }
  } else {
    return dateToStringWithCustomFormat(date, format, utc);
  }
}

function toString(date, format) {
  return date.offset != null ? dateToStringWithOffset(date, format) : dateToStringWithKind(date, format);
}
function DateTime(value, kind) {
  var d = new Date(value);
  d.kind = (kind == null ? 0
  /* Unspecified */
  : kind) | 0;
  return d;
}
function fromTicks(ticks, kind) {
  ticks = Object(_Long__WEBPACK_IMPORTED_MODULE_0__["fromValue"])(ticks);
  kind = kind != null ? kind : 0
  /* Unspecified */
  ;
  var date = DateTime(Object(_Long__WEBPACK_IMPORTED_MODULE_0__["ticksToUnixEpochMilliseconds"])(ticks), kind); // Ticks are local to offset (in this case, either UTC or Local/Unknown).
  // If kind is anything but UTC, that means that the tick number was not
  // in utc, thus getTime() cannot return UTC, and needs to be shifted.

  if (kind !== 1
  /* UTC */
  ) {
      date = DateTime(date.getTime() - Object(_Util__WEBPACK_IMPORTED_MODULE_1__["dateOffset"])(date), kind);
    }

  return date;
}
function fromDateTimeOffset(date, kind) {
  switch (kind) {
    case 1
    /* UTC */
    :
      return DateTime(date.getTime(), 1
      /* UTC */
      );

    case 2
    /* Local */
    :
      return DateTime(date.getTime(), 2
      /* Local */
      );

    default:
      var d = DateTime(date.getTime() + date.offset, kind);
      return DateTime(d.getTime() - Object(_Util__WEBPACK_IMPORTED_MODULE_1__["dateOffset"])(d), kind);
  }
}
function getTicks(date) {
  return Object(_Long__WEBPACK_IMPORTED_MODULE_0__["unixEpochMillisecondsToTicks"])(date.getTime(), Object(_Util__WEBPACK_IMPORTED_MODULE_1__["dateOffset"])(date));
}
function minValue() {
  // This is "0001-01-01T00:00:00.000Z", actual JS min value is -8640000000000000
  return DateTime(-62135596800000, 0
  /* Unspecified */
  );
}
function maxValue() {
  // This is "9999-12-31T23:59:59.999Z", actual JS max value is 8640000000000000
  return DateTime(253402300799999, 0
  /* Unspecified */
  );
}
function parseRaw(str) {
  var date = new Date(str);

  if (isNaN(date.getTime())) {
    // Try to check strings JS Date cannot parse (see #1045, #1422)
    // tslint:disable-next-line:max-line-length
    var m = /^\s*(\d+[^\w\s:]\d+[^\w\s:]\d+)?\s*(\d+:\d+(?::\d+(?:\.\d+)?)?)?\s*([AaPp][Mm])?\s*([+-]\d+(?::\d+)?)?\s*$/.exec(str);

    if (m != null) {
      var baseDate = null;
      var timeInSeconds = 0;

      if (m[2] != null) {
        var timeParts = m[2].split(":");
        timeInSeconds = parseInt(timeParts[0], 10) * 3600 + parseInt(timeParts[1] || "0", 10) * 60 + parseFloat(timeParts[2] || "0");

        if (m[3] != null && m[3].toUpperCase() === "PM") {
          timeInSeconds += 720;
        }
      }

      if (m[4] != null) {
        // There's an offset, parse as UTC
        if (m[1] != null) {
          baseDate = new Date(m[1] + " UTC");
        } else {
          var d = new Date();
          baseDate = new Date(d.getUTCFullYear() + "/" + (d.getUTCMonth() + 1) + "/" + d.getUTCDate());
        }

        var offsetParts = m[4].substr(1).split(":");
        var offsetInMinutes = parseInt(offsetParts[0], 10) * 60 + parseInt(offsetParts[1] || "0", 10);

        if (m[4][0] === "+") {
          offsetInMinutes *= -1;
        }

        timeInSeconds += offsetInMinutes * 60;
      } else {
        if (m[1] != null) {
          baseDate = new Date(m[1]);
        } else {
          var _d = new Date();

          baseDate = new Date(_d.getFullYear() + "/" + (_d.getMonth() + 1) + "/" + _d.getDate());
        }
      }

      date = new Date(baseDate.getTime() + timeInSeconds * 1000); // correct for daylight savings time

      date = new Date(date.getTime() + (date.getTimezoneOffset() - baseDate.getTimezoneOffset()) * 60000);
    } else {
      throw new Error("The string is not a valid Date.");
    }
  }

  return date;
}
function parse(str) {
  var detectUTC = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : false;
  var date = parseRaw(str);
  var offset = offsetRegex.exec(str); // .NET always parses DateTime as Local if there's offset info (even "Z")
  // Newtonsoft.Json uses UTC if the offset is "Z"

  var kind = offset != null ? detectUTC && offset[0] === "Z" ? 1
  /* UTC */
  : 2
  /* Local */
  : 0
  /* Unspecified */
  ;
  return DateTime(date.getTime(), kind);
}
function tryParse(v) {
  try {
    // if value is null or whitespace, parsing fails
    if (v === null || v.trim() === "") {
      return [false, minValue()];
    }

    return [true, parse(v)];
  } catch (_err) {
    return [false, minValue()];
  }
}
function create(year, month, day) {
  var h = arguments.length > 3 && arguments[3] !== undefined ? arguments[3] : 0;
  var m = arguments.length > 4 && arguments[4] !== undefined ? arguments[4] : 0;
  var s = arguments.length > 5 && arguments[5] !== undefined ? arguments[5] : 0;
  var ms = arguments.length > 6 && arguments[6] !== undefined ? arguments[6] : 0;
  var kind = arguments.length > 7 ? arguments[7] : undefined;
  var dateValue = kind === 1
  /* UTC */
  ? Date.UTC(year, month - 1, day, h, m, s, ms) : new Date(year, month - 1, day, h, m, s, ms).getTime();

  if (isNaN(dateValue)) {
    throw new Error("The parameters describe an unrepresentable Date.");
  }

  var date = DateTime(dateValue, kind);

  if (year <= 99) {
    date.setFullYear(year, month - 1, day);
  }

  return date;
}
function now() {
  return DateTime(Date.now(), 2
  /* Local */
  );
}
function utcNow() {
  return DateTime(Date.now(), 1
  /* UTC */
  );
}
function today() {
  return date(now());
}
function isLeapYear(year) {
  return year % 4 === 0 && year % 100 !== 0 || year % 400 === 0;
}
function daysInMonth(year, month) {
  return month === 2 ? isLeapYear(year) ? 29 : 28 : month >= 8 ? month % 2 === 0 ? 31 : 30 : month % 2 === 0 ? 30 : 31;
}
function toUniversalTime(date) {
  return date.kind === 1
  /* UTC */
  ? date : DateTime(date.getTime(), 1
  /* UTC */
  );
}
function toLocalTime(date) {
  return date.kind === 2
  /* Local */
  ? date : DateTime(date.getTime(), 2
  /* Local */
  );
}
function timeOfDay(d) {
  return hour(d) * 3600000 + minute(d) * 60000 + second(d) * 1000 + millisecond(d);
}
function date(d) {
  return create(year(d), month(d), day(d), 0, 0, 0, 0, d.kind);
}
function day(d) {
  return d.kind === 1
  /* UTC */
  ? d.getUTCDate() : d.getDate();
}
function hour(d) {
  return d.kind === 1
  /* UTC */
  ? d.getUTCHours() : d.getHours();
}
function millisecond(d) {
  return d.kind === 1
  /* UTC */
  ? d.getUTCMilliseconds() : d.getMilliseconds();
}
function minute(d) {
  return d.kind === 1
  /* UTC */
  ? d.getUTCMinutes() : d.getMinutes();
}
function month(d) {
  return (d.kind === 1
  /* UTC */
  ? d.getUTCMonth() : d.getMonth()) + 1;
}
function second(d) {
  return d.kind === 1
  /* UTC */
  ? d.getUTCSeconds() : d.getSeconds();
}
function year(d) {
  return d.kind === 1
  /* UTC */
  ? d.getUTCFullYear() : d.getFullYear();
}
function dayOfWeek(d) {
  return d.kind === 1
  /* UTC */
  ? d.getUTCDay() : d.getDay();
}
function dayOfYear(d) {
  var _year = year(d);

  var _month = month(d);

  var _day = day(d);

  for (var i = 1; i < _month; i++) {
    _day += daysInMonth(_year, i);
  }

  return _day;
}
function add(d, ts) {
  return DateTime(d.getTime() + ts, d.kind);
}
function addDays(d, v) {
  return DateTime(d.getTime() + v * 86400000, d.kind);
}
function addHours(d, v) {
  return DateTime(d.getTime() + v * 3600000, d.kind);
}
function addMinutes(d, v) {
  return DateTime(d.getTime() + v * 60000, d.kind);
}
function addSeconds(d, v) {
  return DateTime(d.getTime() + v * 1000, d.kind);
}
function addMilliseconds(d, v) {
  return DateTime(d.getTime() + v, d.kind);
}
function addYears(d, v) {
  var newMonth = month(d);
  var newYear = year(d) + v;

  var _daysInMonth = daysInMonth(newYear, newMonth);

  var newDay = Math.min(_daysInMonth, day(d));
  return create(newYear, newMonth, newDay, hour(d), minute(d), second(d), millisecond(d), d.kind);
}
function addMonths(d, v) {
  var newMonth = month(d) + v;
  var newMonth_ = 0;
  var yearOffset = 0;

  if (newMonth > 12) {
    newMonth_ = newMonth % 12;
    yearOffset = Math.floor(newMonth / 12);
    newMonth = newMonth_;
  } else if (newMonth < 1) {
    newMonth_ = 12 + newMonth % 12;
    yearOffset = Math.floor(newMonth / 12) + (newMonth_ === 12 ? -1 : 0);
    newMonth = newMonth_;
  }

  var newYear = year(d) + yearOffset;

  var _daysInMonth = daysInMonth(newYear, newMonth);

  var newDay = Math.min(_daysInMonth, day(d));
  return create(newYear, newMonth, newDay, hour(d), minute(d), second(d), millisecond(d), d.kind);
}
function subtract(d, that) {
  return typeof that === "number" ? DateTime(d.getTime() - that, d.kind) : d.getTime() - that.getTime();
}
function toLongDateString(d) {
  return d.toDateString();
}
function toShortDateString(d) {
  return d.toLocaleDateString();
}
function toLongTimeString(d) {
  return d.toLocaleTimeString();
}
function toShortTimeString(d) {
  return d.toLocaleTimeString().replace(/:\d\d(?!:)/, "");
}
function equals(d1, d2) {
  return d1.getTime() === d2.getTime();
}
var compare = _Util__WEBPACK_IMPORTED_MODULE_1__["compareDates"];
var compareTo = _Util__WEBPACK_IMPORTED_MODULE_1__["compareDates"];
function op_Addition(x, y) {
  return add(x, y);
}
function op_Subtraction(x, y) {
  return subtract(x, y);
}
function isDaylightSavingTime(x) {
  var jan = new Date(x.getFullYear(), 0, 1);
  var jul = new Date(x.getFullYear(), 6, 1);
  return isDST(jan.getTimezoneOffset(), jul.getTimezoneOffset(), x.getTimezoneOffset());
}

function isDST(janOffset, julOffset, tOffset) {
  return Math.min(janOffset, julOffset) === tOffset;
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Event.js":
/*!*********************************************!*\
  !*** ./.fable/fable-library.2.2.3/Event.js ***!
  \*********************************************/
/*! exports provided: default, add, choose, filter, map, merge, pairwise, partition, scan, split */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "default", function() { return Event; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "add", function() { return add; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "choose", function() { return choose; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "filter", function() { return filter; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "map", function() { return map; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "merge", function() { return merge; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "pairwise", function() { return pairwise; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "partition", function() { return partition; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "scan", function() { return scan; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "split", function() { return split; });
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/classCallCheck */ "./node_modules/@babel/runtime/helpers/classCallCheck.js");
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @babel/runtime/helpers/createClass */ "./node_modules/@babel/runtime/helpers/createClass.js");
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _Observable__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./Observable */ "./.fable/fable-library.2.2.3/Observable.js");
/* harmony import */ var _Option__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./Option */ "./.fable/fable-library.2.2.3/Option.js");
/* harmony import */ var _Seq__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./Seq */ "./.fable/fable-library.2.2.3/Seq.js");






var Event =
/*#__PURE__*/
function () {
  function Event(_subscriber, delegates) {
    _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0___default()(this, Event);

    this._subscriber = _subscriber;
    this.delegates = delegates || new Array();
  }

  _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1___default()(Event, [{
    key: "Add",
    value: function Add(f) {
      this._addHandler(f);
    } // IEvent<T> methods

  }, {
    key: "Trigger",
    value: function Trigger(value) {
      Object(_Seq__WEBPACK_IMPORTED_MODULE_4__["iterate"])(function (f) {
        return f(value);
      }, this.delegates);
    } // IDelegateEvent<T> methods

  }, {
    key: "AddHandler",
    value: function AddHandler(handler) {
      if (this._dotnetDelegates == null) {
        this._dotnetDelegates = new Map();
      }

      var f = function f(x) {
        return handler(null, x);
      };

      this._dotnetDelegates.set(handler, f);

      this._addHandler(f);
    }
  }, {
    key: "RemoveHandler",
    value: function RemoveHandler(handler) {
      if (this._dotnetDelegates != null) {
        var f = this._dotnetDelegates.get(handler);

        if (f != null) {
          this._dotnetDelegates["delete"](handler);

          this._removeHandler(f);
        }
      }
    } // IObservable<T> methods

  }, {
    key: "Subscribe",
    value: function Subscribe(arg) {
      return typeof arg === "function" ? this._subscribeFromCallback(arg) : this._subscribeFromObserver(arg);
    }
  }, {
    key: "_addHandler",
    value: function _addHandler(f) {
      this.delegates.push(f);
    }
  }, {
    key: "_removeHandler",
    value: function _removeHandler(f) {
      var index = this.delegates.indexOf(f);

      if (index > -1) {
        this.delegates.splice(index, 1);
      }
    }
  }, {
    key: "_subscribeFromObserver",
    value: function _subscribeFromObserver(observer) {
      var _this = this;

      if (this._subscriber) {
        return this._subscriber(observer);
      }

      var callback = observer.OnNext;

      this._addHandler(callback);

      return {
        Dispose: function Dispose() {
          _this._removeHandler(callback);
        }
      };
    }
  }, {
    key: "_subscribeFromCallback",
    value: function _subscribeFromCallback(callback) {
      var _this2 = this;

      this._addHandler(callback);

      return {
        Dispose: function Dispose() {
          _this2._removeHandler(callback);
        }
      };
    }
  }, {
    key: "Publish",
    get: function get() {
      return this;
    }
  }]);

  return Event;
}();


function add(callback, sourceEvent) {
  sourceEvent.Subscribe(new _Observable__WEBPACK_IMPORTED_MODULE_2__["Observer"](callback));
}
function choose(chooser, sourceEvent) {
  var source = sourceEvent;
  return new Event(function (observer) {
    return source.Subscribe(new _Observable__WEBPACK_IMPORTED_MODULE_2__["Observer"](function (t) {
      return Object(_Observable__WEBPACK_IMPORTED_MODULE_2__["protect"])(function () {
        return chooser(t);
      }, function (u) {
        if (u != null) {
          observer.OnNext(Object(_Option__WEBPACK_IMPORTED_MODULE_3__["value"])(u));
        }
      }, observer.OnError);
    }, observer.OnError, observer.OnCompleted));
  }, source.delegates);
}
function filter(predicate, sourceEvent) {
  return choose(function (x) {
    return predicate(x) ? x : null;
  }, sourceEvent);
}
function map(mapping, sourceEvent) {
  var source = sourceEvent;
  return new Event(function (observer) {
    return source.Subscribe(new _Observable__WEBPACK_IMPORTED_MODULE_2__["Observer"](function (t) {
      return Object(_Observable__WEBPACK_IMPORTED_MODULE_2__["protect"])(function () {
        return mapping(t);
      }, observer.OnNext, observer.OnError);
    }, observer.OnError, observer.OnCompleted));
  }, source.delegates);
}
function merge(event1, event2) {
  var source1 = event1;
  var source2 = event2;
  return new Event(function (observer) {
    var stopped = false;
    var completed1 = false;
    var completed2 = false;
    var h1 = source1.Subscribe(new _Observable__WEBPACK_IMPORTED_MODULE_2__["Observer"](function (v) {
      if (!stopped) {
        observer.OnNext(v);
      }
    }, function (e) {
      if (!stopped) {
        stopped = true;
        observer.OnError(e);
      }
    }, function () {
      if (!stopped) {
        completed1 = true;

        if (completed2) {
          stopped = true;
          observer.OnCompleted();
        }
      }
    }));
    var h2 = source2.Subscribe(new _Observable__WEBPACK_IMPORTED_MODULE_2__["Observer"](function (v) {
      if (!stopped) {
        observer.OnNext(v);
      }
    }, function (e) {
      if (!stopped) {
        stopped = true;
        observer.OnError(e);
      }
    }, function () {
      if (!stopped) {
        completed2 = true;

        if (completed1) {
          stopped = true;
          observer.OnCompleted();
        }
      }
    }));
    return {
      Dispose: function Dispose() {
        h1.Dispose();
        h2.Dispose();
      }
    };
  }, source1.delegates.concat(source2.delegates));
}
function pairwise(sourceEvent) {
  var source = sourceEvent;
  return new Event(function (observer) {
    var last = null;
    return source.Subscribe(new _Observable__WEBPACK_IMPORTED_MODULE_2__["Observer"](function (next) {
      if (last != null) {
        observer.OnNext([last, next]);
      }

      last = next;
    }, observer.OnError, observer.OnCompleted));
  }, source.delegates);
}
function partition(predicate, sourceEvent) {
  return [filter(predicate, sourceEvent), filter(function (x) {
    return !predicate(x);
  }, sourceEvent)];
}
function scan(collector, state, sourceEvent) {
  var source = sourceEvent;
  return new Event(function (observer) {
    return source.Subscribe(new _Observable__WEBPACK_IMPORTED_MODULE_2__["Observer"](function (t) {
      Object(_Observable__WEBPACK_IMPORTED_MODULE_2__["protect"])(function () {
        return collector(state, t);
      }, function (u) {
        state = u;
        observer.OnNext(u);
      }, observer.OnError);
    }, observer.OnError, observer.OnCompleted));
  }, source.delegates);
}
function split(splitter, sourceEvent) {
  return [choose(function (v) {
    return Object(_Option__WEBPACK_IMPORTED_MODULE_3__["tryValueIfChoice1"])(splitter(v));
  }, sourceEvent), choose(function (v) {
    return Object(_Option__WEBPACK_IMPORTED_MODULE_3__["tryValueIfChoice2"])(splitter(v));
  }, sourceEvent)];
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Int32.js":
/*!*********************************************!*\
  !*** ./.fable/fable-library.2.2.3/Int32.js ***!
  \*********************************************/
/*! exports provided: NumberStyles, isValid, parse, tryParse, op_UnaryNegation_Int8, op_UnaryNegation_Int16, op_UnaryNegation_Int32 */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NumberStyles", function() { return NumberStyles; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isValid", function() { return isValid; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "parse", function() { return parse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryParse", function() { return tryParse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_UnaryNegation_Int8", function() { return op_UnaryNegation_Int8; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_UnaryNegation_Int16", function() { return op_UnaryNegation_Int16; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_UnaryNegation_Int32", function() { return op_UnaryNegation_Int32; });
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/slicedToArray */ "./node_modules/@babel/runtime/helpers/slicedToArray.js");
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__);

var NumberStyles;

(function (NumberStyles) {
  // None = 0x00000000,
  // AllowLeadingWhite = 0x00000001,
  // AllowTrailingWhite = 0x00000002,
  // AllowLeadingSign = 0x00000004,
  // AllowTrailingSign = 0x00000008,
  // AllowParentheses = 0x00000010,
  // AllowDecimalPoint = 0x00000020,
  // AllowThousands = 0x00000040,
  // AllowExponent = 0x00000080,
  // AllowCurrencySymbol = 0x00000100,
  NumberStyles[NumberStyles["AllowHexSpecifier"] = 512] = "AllowHexSpecifier"; // Integer = AllowLeadingWhite | AllowTrailingWhite | AllowLeadingSign,
  // HexNumber = AllowLeadingWhite | AllowTrailingWhite | AllowHexSpecifier,
  // Number = AllowLeadingWhite | AllowTrailingWhite | AllowLeadingSign |
  //          AllowTrailingSign | AllowDecimalPoint | AllowThousands,
  // Float = AllowLeadingWhite | AllowTrailingWhite | AllowLeadingSign |
  //         AllowDecimalPoint | AllowExponent,
  // Currency = AllowLeadingWhite | AllowTrailingWhite | AllowLeadingSign | AllowTrailingSign |
  //            AllowParentheses | AllowDecimalPoint | AllowThousands | AllowCurrencySymbol,
  // Any = AllowLeadingWhite | AllowTrailingWhite | AllowLeadingSign | AllowTrailingSign |
  //       AllowParentheses | AllowDecimalPoint | AllowThousands | AllowCurrencySymbol | AllowExponent,
})(NumberStyles || (NumberStyles = {}));

function validResponse(regexMatch, radix) {
  var _regexMatch = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(regexMatch, 4),
      _all = _regexMatch[0],
      sign = _regexMatch[1],
      prefix = _regexMatch[2],
      digits = _regexMatch[3];

  return {
    sign: sign || "",
    prefix: prefix || "",
    digits: digits,
    radix: radix
  };
}

function getRange(unsigned, bitsize) {
  switch (bitsize) {
    case 8:
      return unsigned ? [0, 255] : [-128, 127];

    case 16:
      return unsigned ? [0, 65535] : [-32768, 32767];

    case 32:
      return unsigned ? [0, 4294967295] : [-2147483648, 2147483647];

    default:
      throw new Error("Invalid bit size.");
  }
}

function getInvalidDigits(radix) {
  switch (radix) {
    case 2:
      return /[^0-1]/;

    case 8:
      return /[^0-7]/;

    case 10:
      return /[^0-9]/;

    case 16:
      return /[^0-9a-fA-F]/;

    default:
      throw new Error("Invalid Base.");
  }
}

function getRadix(prefix, style) {
  if (style & NumberStyles.AllowHexSpecifier) {
    return 16;
  } else {
    switch (prefix) {
      case "0b":
      case "0B":
        return 2;

      case "0o":
      case "0O":
        return 8;

      case "0x":
      case "0X":
        return 16;

      default:
        return 10;
    }
  }
}

function isValid(str, style, radix) {
  var integerRegex = /^\s*([\+\-])?(0[xXoObB])?([0-9a-fA-F]+)\s*$/;
  var res = integerRegex.exec(str.replace("_", ""));

  if (res != null) {
    var _res = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(res, 4),
        _all = _res[0],
        sign = _res[1],
        prefix = _res[2],
        digits = _res[3];

    radix = radix || getRadix(prefix, style);
    var invalidDigits = getInvalidDigits(radix);

    if (!invalidDigits.test(digits)) {
      return validResponse(res, radix);
    }
  }

  return null;
}
function parse(str, style, unsigned, bitsize, radix) {
  var res = isValid(str, style, radix);

  if (res != null) {
    var v = Number.parseInt(res.sign + res.digits, res.radix);

    if (!Number.isNaN(v)) {
      var _getRange = getRange(true, bitsize),
          _getRange2 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_getRange, 2),
          umin = _getRange2[0],
          umax = _getRange2[1];

      if (!unsigned && res.radix !== 10 && v >= umin && v <= umax) {
        v = v << 32 - bitsize >> 32 - bitsize;
      }

      var _getRange3 = getRange(unsigned, bitsize),
          _getRange4 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_getRange3, 2),
          min = _getRange4[0],
          max = _getRange4[1];

      if (v >= min && v <= max) {
        return v;
      }
    }
  }

  throw new Error("Input string was not in a correct format.");
}
function tryParse(str, style, unsigned, bitsize) {
  try {
    var v = parse(str, style, unsigned, bitsize);
    return [true, v];
  } catch (_a) {// supress error
  }

  return [false, 0];
}
function op_UnaryNegation_Int8(x) {
  return x === -128 ? x : -x;
}
function op_UnaryNegation_Int16(x) {
  return x === -32768 ? x : -x;
}
function op_UnaryNegation_Int32(x) {
  return x === -2147483648 ? x : -x;
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Long.js":
/*!********************************************!*\
  !*** ./.fable/fable-library.2.2.3/Long.js ***!
  \********************************************/
/*! exports provided: default, neg, not, add, sub, mul, div, mod, shl, shr, and, or, xor, fromInt, fromNumber, fromInteger, fromBits, fromString, parse, tryParse, fromValue, ZERO, UZERO, ONE, UONE, NEG_ONE, MAX_VALUE, MAX_UNSIGNED_VALUE, MIN_VALUE, toInt, toNumber, toString, getHighBits, getHighBitsUnsigned, getLowBits, getLowBitsUnsigned, getNumBitsAbs, isZero, isNegative, isPositive, isOdd, isEven, equals, notEquals, lessThan, lessThanOrEqual, greaterThan, greaterThanOrEqual, compare, abs, op_UnaryNegation, op_Addition, op_Subtraction, op_Multiply, op_Division, op_Modulus, op_LogicalNot, op_BitwiseAnd, op_BitwiseOr, op_ExclusiveOr, op_LeftShift, op_RightShift, op_RightShiftUnsigned, toSigned, toUnsigned, toBytes, toBytesLE, toBytesBE, fromBytes, fromBytesLE, fromBytesBE, unixEpochMillisecondsToTicks, ticksToUnixEpochMilliseconds, makeRangeStepFunction */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "default", function() { return Long; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "neg", function() { return neg; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "not", function() { return not; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "add", function() { return add; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "sub", function() { return sub; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mul", function() { return mul; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "div", function() { return div; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mod", function() { return mod; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "shl", function() { return shl; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "shr", function() { return shr; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "and", function() { return and; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "or", function() { return or; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "xor", function() { return xor; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromInt", function() { return fromInt; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromNumber", function() { return fromNumber; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromInteger", function() { return fromInteger; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromBits", function() { return fromBits; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromString", function() { return fromString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "parse", function() { return parse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryParse", function() { return tryParse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromValue", function() { return fromValue; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ZERO", function() { return ZERO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UZERO", function() { return UZERO; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ONE", function() { return ONE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UONE", function() { return UONE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "NEG_ONE", function() { return NEG_ONE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MAX_VALUE", function() { return MAX_VALUE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MAX_UNSIGNED_VALUE", function() { return MAX_UNSIGNED_VALUE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "MIN_VALUE", function() { return MIN_VALUE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toInt", function() { return toInt; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toNumber", function() { return toNumber; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toString", function() { return toString; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getHighBits", function() { return getHighBits; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getHighBitsUnsigned", function() { return getHighBitsUnsigned; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getLowBits", function() { return getLowBits; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getLowBitsUnsigned", function() { return getLowBitsUnsigned; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getNumBitsAbs", function() { return getNumBitsAbs; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isZero", function() { return isZero; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isNegative", function() { return isNegative; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isPositive", function() { return isPositive; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isOdd", function() { return isOdd; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isEven", function() { return isEven; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "equals", function() { return equals; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "notEquals", function() { return notEquals; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "lessThan", function() { return lessThan; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "lessThanOrEqual", function() { return lessThanOrEqual; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "greaterThan", function() { return greaterThan; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "greaterThanOrEqual", function() { return greaterThanOrEqual; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compare", function() { return compare; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "abs", function() { return abs; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_UnaryNegation", function() { return op_UnaryNegation; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_Addition", function() { return op_Addition; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_Subtraction", function() { return op_Subtraction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_Multiply", function() { return op_Multiply; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_Division", function() { return op_Division; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_Modulus", function() { return op_Modulus; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_LogicalNot", function() { return op_LogicalNot; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_BitwiseAnd", function() { return op_BitwiseAnd; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_BitwiseOr", function() { return op_BitwiseOr; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_ExclusiveOr", function() { return op_ExclusiveOr; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_LeftShift", function() { return op_LeftShift; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_RightShift", function() { return op_RightShift; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "op_RightShiftUnsigned", function() { return op_RightShiftUnsigned; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toSigned", function() { return toSigned; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toUnsigned", function() { return toUnsigned; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toBytes", function() { return toBytes; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toBytesLE", function() { return toBytesLE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toBytesBE", function() { return toBytesBE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromBytes", function() { return fromBytes; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromBytesLE", function() { return fromBytesLE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromBytesBE", function() { return fromBytesBE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "unixEpochMillisecondsToTicks", function() { return unixEpochMillisecondsToTicks; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ticksToUnixEpochMilliseconds", function() { return ticksToUnixEpochMilliseconds; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "makeRangeStepFunction", function() { return makeRangeStepFunction; });
/* harmony import */ var _Int32__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./Int32 */ "./.fable/fable-library.2.2.3/Int32.js");
/* harmony import */ var _Util__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Util */ "./.fable/fable-library.2.2.3/Util.js");
// Adapted from: https://github.com/dcodeIO/long.js/blob/f572e3a17d313730cf11eb838f6d2a5e31626f8a/src/long.js
// Apache License 2.0: https://github.com/dcodeIO/long.js/blob/master/LICENSE

/* tslint:disable */


/**
 * wasm optimizations, to do native i64 multiplication and divide
 */

var wasm = null;

try {
  wasm = new WebAssembly.Instance(new WebAssembly.Module(new Uint8Array([0, 97, 115, 109, 1, 0, 0, 0, 1, 13, 2, 96, 0, 1, 127, 96, 4, 127, 127, 127, 127, 1, 127, 3, 7, 6, 0, 1, 1, 1, 1, 1, 6, 6, 1, 127, 1, 65, 0, 11, 7, 50, 6, 3, 109, 117, 108, 0, 1, 5, 100, 105, 118, 95, 115, 0, 2, 5, 100, 105, 118, 95, 117, 0, 3, 5, 114, 101, 109, 95, 115, 0, 4, 5, 114, 101, 109, 95, 117, 0, 5, 8, 103, 101, 116, 95, 104, 105, 103, 104, 0, 0, 10, 191, 1, 6, 4, 0, 35, 0, 11, 36, 1, 1, 126, 32, 0, 173, 32, 1, 173, 66, 32, 134, 132, 32, 2, 173, 32, 3, 173, 66, 32, 134, 132, 126, 34, 4, 66, 32, 135, 167, 36, 0, 32, 4, 167, 11, 36, 1, 1, 126, 32, 0, 173, 32, 1, 173, 66, 32, 134, 132, 32, 2, 173, 32, 3, 173, 66, 32, 134, 132, 127, 34, 4, 66, 32, 135, 167, 36, 0, 32, 4, 167, 11, 36, 1, 1, 126, 32, 0, 173, 32, 1, 173, 66, 32, 134, 132, 32, 2, 173, 32, 3, 173, 66, 32, 134, 132, 128, 34, 4, 66, 32, 135, 167, 36, 0, 32, 4, 167, 11, 36, 1, 1, 126, 32, 0, 173, 32, 1, 173, 66, 32, 134, 132, 32, 2, 173, 32, 3, 173, 66, 32, 134, 132, 129, 34, 4, 66, 32, 135, 167, 36, 0, 32, 4, 167, 11, 36, 1, 1, 126, 32, 0, 173, 32, 1, 173, 66, 32, 134, 132, 32, 2, 173, 32, 3, 173, 66, 32, 134, 132, 130, 34, 4, 66, 32, 135, 167, 36, 0, 32, 4, 167, 11])), {}).exports;
} catch (e) {} // no wasm support :(

/**
 * Constructs a 64 bit two's-complement integer, given its low and high 32 bit values as *signed* integers.
 *  See the from* functions below for more convenient ways of constructing Longs.
 * @exports Long
 * @class A Long class for representing a 64 bit two's-complement integer value.
 * @param {number} low The low (signed) 32 bits of the long
 * @param {number} high The high (signed) 32 bits of the long
 * @param {boolean=} unsigned Whether unsigned or not, defaults to signed
 * @constructor
 */


function Long(low, high, unsigned) {
  /**
   * The low 32 bits as a signed value.
   * @type {number}
   */
  this.low = low | 0;
  /**
   * The high 32 bits as a signed value.
   * @type {number}
   */

  this.high = high | 0;
  /**
   * Whether unsigned or not.
   * @type {boolean}
   */

  this.unsigned = !!unsigned;
}

Long.prototype.GetHashCode = function () {
  return Object(_Util__WEBPACK_IMPORTED_MODULE_1__["combineHashCodes"])([this.unsigned ? 1 : 0, this.high, this.low]);
};

Long.prototype.Equals = function (x) {
  return equals(this, x);
};

Long.prototype.CompareTo = function (x) {
  return compare(this, x);
};

Long.prototype.toString = function (radix) {
  return toString(this, radix);
};

Long.prototype.toJSON = function () {
  return toString(this);
};

var neg = op_UnaryNegation;
var not = op_LogicalNot;
var add = op_Addition;
var sub = op_Subtraction;
var mul = op_Multiply;
var div = op_Division;
var mod = op_Modulus;
var shl = op_LeftShift;
var shr = op_RightShift;
var and = op_BitwiseAnd;
var or = op_BitwiseOr;
var xor = op_ExclusiveOr; // The internal representation of a long is the two given signed, 32-bit values.
// We use 32-bit pieces because these are the size of integers on which
// Javascript performs bit-operations.  For operations like addition and
// multiplication, we split each number into 16 bit pieces, which can easily be
// multiplied within Javascript's floating-point representation without overflow
// or change in sign.
//
// In the algorithms below, we frequently reduce the negative case to the
// positive case by negating the input(s) and then post-processing the result.
// Note that we must ALWAYS check specially whether those values are MIN_VALUE
// (-2^63) because -MIN_VALUE == MIN_VALUE (since 2^63 cannot be represented as
// a positive number, it overflows back into a negative).  Not handling this
// case would often result in infinite recursion.
//
// Common constant values ZERO, ONE, NEG_ONE, etc. are defined below the from*
// methods on which they depend.

/**
 * An indicator used to reliably determine if an object is a Long or not.
 * @type {boolean}
 * @const
 * @private
 */

Long.prototype.__isLong__;
Object.defineProperty(Long.prototype, "__isLong__", {
  value: true
});
/**
 * @function
 * @param {*} obj Object
 * @returns {boolean}
 * @inner
 */

function isLong(obj) {
  return (obj && obj["__isLong__"]) === true;
}
/**
 * A cache of the Long representations of small integer values.
 * @type {!Object}
 * @inner
 */


var INT_CACHE = {};
/**
 * A cache of the Long representations of small unsigned integer values.
 * @type {!Object}
 * @inner
 */

var UINT_CACHE = {};
/**
 * @param {number} value
 * @param {boolean=} unsigned
 * @returns {!Long}
 * @inner
 */

function fromInt(value, unsigned) {
  var obj, cachedObj, cache;

  if (unsigned) {
    value >>>= 0;

    if (cache = 0 <= value && value < 256) {
      cachedObj = UINT_CACHE[value];
      if (cachedObj) return cachedObj;
    }

    obj = fromBits(value, (value | 0) < 0 ? -1 : 0, true);
    if (cache) UINT_CACHE[value] = obj;
    return obj;
  } else {
    value |= 0;

    if (cache = -128 <= value && value < 128) {
      cachedObj = INT_CACHE[value];
      if (cachedObj) return cachedObj;
    }

    obj = fromBits(value, value < 0 ? -1 : 0, false);
    if (cache) INT_CACHE[value] = obj;
    return obj;
  }
}
/**
 * @param {number} value
 * @param {boolean=} unsigned
 * @returns {!Long}
 * @inner
 */

function fromNumber(value, unsigned) {
  if (isNaN(value)) return unsigned ? UZERO : ZERO;

  if (unsigned) {
    if (value < 0) return UZERO;
    if (value >= TWO_PWR_64_DBL) return MAX_UNSIGNED_VALUE;
  } else {
    if (value <= -TWO_PWR_63_DBL) return MIN_VALUE;
    if (value + 1 >= TWO_PWR_63_DBL) return MAX_VALUE;
  }

  if (value < 0) return op_UnaryNegation(fromNumber(-value, unsigned));
  return fromBits(value % TWO_PWR_32_DBL | 0, value / TWO_PWR_32_DBL | 0, unsigned);
}
/**
 * @param {number} value
 * @param {boolean} unsigned
 * @param {number} kind
 * @returns {!Long}
 * @inner
 */

function fromInteger(value, unsigned, kind) {
  var x;
  var xh = 0;

  switch (kind) {
    case 0:
      x = value << 24 >> 24;
      xh = x;
      break;

    case 4:
      x = value << 24 >>> 24;
      break;

    case 1:
      x = value << 16 >> 16;
      xh = x;
      break;

    case 5:
      x = value << 16 >>> 16;
      break;

    case 2:
      x = value >> 0;
      xh = x;
      break;

    case 6:
      x = value >>> 0;
  }

  return fromBits(x, xh >> 31, unsigned);
}
/**
 * @param {number} lowBits
 * @param {number} highBits
 * @param {boolean=} unsigned
 * @returns {!Long}
 * @inner
 */

function fromBits(lowBits, highBits, unsigned) {
  return new Long(lowBits, highBits, unsigned);
}
/**
 * @function
 * @param {number} base
 * @param {number} exponent
 * @returns {number}
 * @inner
 */

var pow_dbl = Math.pow; // Used 4 times (4*8 to 15+4)

/**
 * @param {string} str
 * @param {(boolean|number)=} unsigned
 * @param {number=} radix
 * @returns {!Long}
 * @inner
 */

function fromString(str, unsigned, radix) {
  if (str.length === 0) throw Error("empty string");
  if (str === "NaN" || str === "Infinity" || str === "+Infinity" || str === "-Infinity") return ZERO;

  if (typeof unsigned === "number") {
    // For goog.math.long compatibility
    radix = unsigned, unsigned = false;
  } else {
    unsigned = !!unsigned;
  }

  radix = radix || 10;
  if (radix < 2 || 36 < radix) throw RangeError("radix");
  var p = str.indexOf("-");
  if (p > 0) throw Error("interior hyphen");else if (p === 0) {
    return op_UnaryNegation(fromString(str.substring(1), unsigned, radix));
  } // Do several (8) digits each time through the loop, so as to
  // minimize the calls to the very expensive emulated div.

  var radixToPower = fromNumber(pow_dbl(radix, 8));
  var result = ZERO;

  for (var i = 0; i < str.length; i += 8) {
    var size = Math.min(8, str.length - i),
        value = parseInt(str.substring(i, i + size), radix);

    if (size < 8) {
      var power = fromNumber(pow_dbl(radix, size));
      result = op_Addition(op_Multiply(result, power), fromNumber(value));
    } else {
      result = op_Multiply(result, radixToPower);
      result = op_Addition(result, fromNumber(value));
    }
  }

  result.unsigned = unsigned;
  return result;
}

function getMaxValue(unsigned, radix, isNegative) {
  switch (radix) {
    case 2:
      return unsigned ? "1111111111111111111111111111111111111111111111111111111111111111" : isNegative ? "1000000000000000000000000000000000000000000000000000000000000000" : "111111111111111111111111111111111111111111111111111111111111111";

    case 8:
      return unsigned ? "1777777777777777777777" : isNegative ? "1000000000000000000000" : "777777777777777777777";

    case 10:
      return unsigned ? "18446744073709551615" : isNegative ? "9223372036854775808" : "9223372036854775807";

    case 16:
      return unsigned ? "FFFFFFFFFFFFFFFF" : isNegative ? "8000000000000000" : "7FFFFFFFFFFFFFFF";

    default:
      throw new Error("Invalid radix.");
  }
}

function parse(str, style, unsigned, bitsize, radix) {
  var res = Object(_Int32__WEBPACK_IMPORTED_MODULE_0__["isValid"])(str, style, radix);

  if (res != null) {
    var lessOrEqual = function lessOrEqual(x, y) {
      var len = Math.max(x.length, y.length);
      return x.padStart(len, "0") <= maxValue.padStart(len, "0");
    };

    var _isNegative = res.sign === "-";

    var maxValue = getMaxValue(unsigned || res.radix !== 10, res.radix, _isNegative);

    if (lessOrEqual(res.digits, maxValue)) {
      str = _isNegative ? res.sign + res.digits : res.digits;
      return fromString(str, unsigned, res.radix);
    }
  }

  throw new Error("Input string was not in a correct format.");
}
function tryParse(str, style, unsigned, bitsize) {
  try {
    var v = parse(str, style, unsigned, bitsize);
    return [true, v];
  } catch (_a) {// supress error
  }

  return [false, ZERO];
}
/**
 * @function
 * @param {!Long|number|string|!{low: number, high: number, unsigned: boolean}} val
 * @param {boolean=} unsigned
 * @returns {!Long}
 * @inner
 */

function fromValue(val, unsigned) {
  if (typeof val === "number") return fromNumber(val, unsigned);
  if (typeof val === "string") return fromString(val, unsigned); // Throws for non-objects, converts non-instanceof Long:

  return fromBits(val.low, val.high, typeof unsigned === "boolean" ? unsigned : val.unsigned);
} // NOTE: the compiler should inline these constant values below and then remove these variables, so there should be
// no runtime penalty for these.

/**
 * @type {number}
 * @const
 * @inner
 */

var TWO_PWR_16_DBL = 1 << 16;
/**
 * @type {number}
 * @const
 * @inner
 */

var TWO_PWR_24_DBL = 1 << 24;
/**
 * @type {number}
 * @const
 * @inner
 */

var TWO_PWR_32_DBL = TWO_PWR_16_DBL * TWO_PWR_16_DBL;
/**
 * @type {number}
 * @const
 * @inner
 */

var TWO_PWR_64_DBL = TWO_PWR_32_DBL * TWO_PWR_32_DBL;
/**
 * @type {number}
 * @const
 * @inner
 */

var TWO_PWR_63_DBL = TWO_PWR_64_DBL / 2;
/**
 * @type {!Long}
 * @const
 * @inner
 */

var TWO_PWR_24 = fromInt(TWO_PWR_24_DBL);
/**
 * @type {!Long}
 * @inner
 */

var ZERO = fromInt(0);
/**
 * @type {!Long}
 * @inner
 */

var UZERO = fromInt(0, true);
/**
 * @type {!Long}
 * @inner
 */

var ONE = fromInt(1);
/**
 * @type {!Long}
 * @inner
 */

var UONE = fromInt(1, true);
/**
 * @type {!Long}
 * @inner
 */

var NEG_ONE = fromInt(-1);
/**
 * @type {!Long}
 * @inner
 */

var MAX_VALUE = fromBits(0xFFFFFFFF | 0, 0x7FFFFFFF | 0, false);
/**
 * @type {!Long}
 * @inner
 */

var MAX_UNSIGNED_VALUE = fromBits(0xFFFFFFFF | 0, 0xFFFFFFFF | 0, true);
/**
 * @type {!Long}
 * @inner
 */

var MIN_VALUE = fromBits(0, 0x80000000 | 0, false);
/**
 * Converts the Long to a 32 bit integer, assuming it is a 32 bit integer.
 * @returns {number}
 */

function toInt($this) {
  return $this.unsigned ? $this.low >>> 0 : $this.low;
}
;
/**
 * Converts the Long to a the nearest floating-point representation of this value (double, 53 bit mantissa).
 * @returns {number}
 */

function toNumber($this) {
  if ($this.unsigned) return ($this.high >>> 0) * TWO_PWR_32_DBL + ($this.low >>> 0);
  return $this.high * TWO_PWR_32_DBL + ($this.low >>> 0);
}
;
/**
 * Converts the Long to a string written in the specified radix.
 * @param {number=} radix Radix (2-36), defaults to 10
 * @returns {string}
 * @override
 * @throws {RangeError} If `radix` is out of range
 */

function toString($this, radix) {
  radix = radix || 10;
  if (radix < 2 || 36 < radix) throw RangeError("radix");
  if (isZero($this)) return "0";

  if (isNegative($this)) {
    // Unsigned Longs are never negative
    if (equals($this, MIN_VALUE)) {
      // We need to change the Long value before it can be negated, so we remove
      // the bottom-most digit in this base and then recurse to do the rest.
      var radixLong = fromNumber(radix),
          div = op_Division($this, radixLong),
          rem1 = op_Subtraction(op_Multiply(div, radixLong), $this);
      return toString(div, radix) + toInt(rem1).toString(radix);
    } else return "-" + toString(op_UnaryNegation($this), radix);
  } // Do several (6) digits each time through the loop, so as to
  // minimize the calls to the very expensive emulated div.


  var radixToPower = fromNumber(pow_dbl(radix, 6), $this.unsigned),
      rem = $this;
  var result = "";

  while (true) {
    var remDiv = op_Division(rem, radixToPower),
        intval = toInt(op_Subtraction(rem, op_Multiply(remDiv, radixToPower))) >>> 0,
        digits = intval.toString(radix);
    rem = remDiv;
    if (isZero(rem)) return digits + result;else {
      while (digits.length < 6) {
        digits = "0" + digits;
      }

      result = "" + digits + result;
    }
  }
}
;
/**
 * Gets the high 32 bits as a signed integer.
 * @returns {number} Signed high bits
 */

function getHighBits($this) {
  return $this.high;
}
;
/**
 * Gets the high 32 bits as an unsigned integer.
 * @returns {number} Unsigned high bits
 */

function getHighBitsUnsigned($this) {
  return $this.high >>> 0;
}
;
/**
 * Gets the low 32 bits as a signed integer.
 * @returns {number} Signed low bits
 */

function getLowBits($this) {
  return $this.low;
}
;
/**
 * Gets the low 32 bits as an unsigned integer.
 * @returns {number} Unsigned low bits
 */

function getLowBitsUnsigned($this) {
  return $this.low >>> 0;
}
;
/**
 * Gets the number of bits needed to represent the absolute value of this Long.
 * @returns {number}
 */

function getNumBitsAbs($this) {
  if (isNegative($this)) // Unsigned Longs are never negative
    return equals($this, MIN_VALUE) ? 64 : getNumBitsAbs(op_UnaryNegation($this));
  var val = $this.high != 0 ? $this.high : $this.low;

  for (var bit = 31; bit > 0; bit--) {
    if ((val & 1 << bit) != 0) break;
  }

  return $this.high != 0 ? bit + 33 : bit + 1;
}
;
/**
 * Tests if this Long's value equals zero.
 * @returns {boolean}
 */

function isZero($this) {
  return $this.high === 0 && $this.low === 0;
}
;
/**
 * Tests if this Long's value is negative.
 * @returns {boolean}
 */

function isNegative($this) {
  return !$this.unsigned && $this.high < 0;
}
;
/**
 * Tests if this Long's value is positive.
 * @returns {boolean}
 */

function isPositive($this) {
  return $this.unsigned || $this.high >= 0;
}
;
/**
 * Tests if this Long's value is odd.
 * @returns {boolean}
 */

function isOdd($this) {
  return ($this.low & 1) === 1;
}
;
/**
 * Tests if this Long's value is even.
 * @returns {boolean}
 */

function isEven($this) {
  return ($this.low & 1) === 0;
}
;
/**
 * Tests if this Long's value equals the specified's.
 * @param {!Long|number|string} other Other value
 * @returns {boolean}
 */

function equals($this, other) {
  if (!isLong(other)) other = fromValue(other);
  if ($this.unsigned !== other.unsigned && $this.high >>> 31 === 1 && other.high >>> 31 === 1) return false;
  return $this.high === other.high && $this.low === other.low;
}
;
/**
 * Tests if this Long's value differs from the specified's.
 * @param {!Long|number|string} other Other value
 * @returns {boolean}
 */

function notEquals($this, other) {
  return !equals($this,
  /* validates */
  other);
}
;
/**
 * Tests if this Long's value is less than the specified's.
 * @param {!Long|number|string} other Other value
 * @returns {boolean}
 */

function lessThan($this, other) {
  return compare($this,
  /* validates */
  other) < 0;
}
;
/**
 * Tests if this Long's value is less than or equal the specified's.
 * @param {!Long|number|string} other Other value
 * @returns {boolean}
 */

function lessThanOrEqual($this, other) {
  return compare($this,
  /* validates */
  other) <= 0;
}
;
/**
 * Tests if this Long's value is greater than the specified's.
 * @param {!Long|number|string} other Other value
 * @returns {boolean}
 */

function greaterThan($this, other) {
  return compare($this,
  /* validates */
  other) > 0;
}
;
/**
 * Tests if this Long's value is greater than or equal the specified's.
 * @param {!Long|number|string} other Other value
 * @returns {boolean}
 */

function greaterThanOrEqual($this, other) {
  return compare($this,
  /* validates */
  other) >= 0;
}
;
/**
 * Compares this Long's value with the specified's.
 * @param {!Long|number|string} other Other value
 * @returns {number} 0 if they are the same, 1 if the this is greater and -1
 *  if the given one is greater
 */

function compare($this, other) {
  if (!isLong(other)) other = fromValue(other);
  if (equals($this, other)) return 0;
  var thisNeg = isNegative($this),
      otherNeg = isNegative(other);
  if (thisNeg && !otherNeg) return -1;
  if (!thisNeg && otherNeg) return 1; // At this point the sign bits are the same

  if (!$this.unsigned) return isNegative(op_Subtraction($this, other)) ? -1 : 1; // Both are positive if at least one is unsigned

  return other.high >>> 0 > $this.high >>> 0 || other.high === $this.high && other.low >>> 0 > $this.low >>> 0 ? -1 : 1;
}
;
/**
 * Absolute value of the given number.
 */

function abs($this) {
  if (!$this.unsigned && isNegative($this)) return op_UnaryNegation($this);else return $this;
}
/**
 * Negates this Long's value.
 * @returns {!Long} Negated Long
 */

function op_UnaryNegation($this) {
  if (!$this.unsigned && equals($this, MIN_VALUE)) return MIN_VALUE;
  return op_Addition(op_LogicalNot($this), ONE);
}
;
/**
 * Returns the sum of this and the specified Long.
 * @param {!Long|number|string} addend Addend
 * @returns {!Long} Sum
 */

function op_Addition($this, addend) {
  if (!isLong(addend)) addend = fromValue(addend); // Divide each number into 4 chunks of 16 bits, and then sum the chunks.

  var a48 = $this.high >>> 16;
  var a32 = $this.high & 0xFFFF;
  var a16 = $this.low >>> 16;
  var a00 = $this.low & 0xFFFF;
  var b48 = addend.high >>> 16;
  var b32 = addend.high & 0xFFFF;
  var b16 = addend.low >>> 16;
  var b00 = addend.low & 0xFFFF;
  var c48 = 0,
      c32 = 0,
      c16 = 0,
      c00 = 0;
  c00 += a00 + b00;
  c16 += c00 >>> 16;
  c00 &= 0xFFFF;
  c16 += a16 + b16;
  c32 += c16 >>> 16;
  c16 &= 0xFFFF;
  c32 += a32 + b32;
  c48 += c32 >>> 16;
  c32 &= 0xFFFF;
  c48 += a48 + b48;
  c48 &= 0xFFFF;
  return fromBits(c16 << 16 | c00, c48 << 16 | c32, $this.unsigned);
}
;
/**
 * Returns the difference of this and the specified Long.
 * @param {!Long|number|string} subtrahend Subtrahend
 * @returns {!Long} Difference
 */

function op_Subtraction($this, subtrahend) {
  if (!isLong(subtrahend)) subtrahend = fromValue(subtrahend);
  return op_Addition($this, op_UnaryNegation(subtrahend));
}
;
/**
 * Returns the product of this and the specified Long.
 * @param {!Long|number|string} multiplier Multiplier
 * @returns {!Long} Product
 */

function op_Multiply($this, multiplier) {
  if (isZero($this)) return $this.unsigned ? UZERO : ZERO;
  if (!isLong(multiplier)) multiplier = fromValue(multiplier); // use wasm support if present

  if (wasm) {
    var low = wasm.mul($this.low, $this.high, multiplier.low, multiplier.high);
    return fromBits(low, wasm.get_high(), $this.unsigned);
  }

  if (isZero(multiplier)) return $this.unsigned ? UZERO : ZERO;
  if (equals($this, MIN_VALUE)) return isOdd(multiplier) ? MIN_VALUE : ZERO;
  if (equals(multiplier, MIN_VALUE)) return isOdd($this) ? MIN_VALUE : ZERO;

  if (isNegative($this)) {
    if (isNegative(multiplier)) return op_Multiply(op_UnaryNegation($this), op_UnaryNegation(multiplier));else return op_UnaryNegation(op_Multiply(op_UnaryNegation($this), multiplier));
  } else if (isNegative(multiplier)) return op_UnaryNegation(op_Multiply($this, op_UnaryNegation(multiplier))); // If both longs are small, use float multiplication


  if (lessThan($this, TWO_PWR_24) && lessThan(multiplier, TWO_PWR_24)) return fromNumber(toNumber($this) * toNumber(multiplier), $this.unsigned); // Divide each long into 4 chunks of 16 bits, and then add up 4x4 products.
  // We can skip products that would overflow.

  var a48 = $this.high >>> 16;
  var a32 = $this.high & 0xFFFF;
  var a16 = $this.low >>> 16;
  var a00 = $this.low & 0xFFFF;
  var b48 = multiplier.high >>> 16;
  var b32 = multiplier.high & 0xFFFF;
  var b16 = multiplier.low >>> 16;
  var b00 = multiplier.low & 0xFFFF;
  var c48 = 0,
      c32 = 0,
      c16 = 0,
      c00 = 0;
  c00 += a00 * b00;
  c16 += c00 >>> 16;
  c00 &= 0xFFFF;
  c16 += a16 * b00;
  c32 += c16 >>> 16;
  c16 &= 0xFFFF;
  c16 += a00 * b16;
  c32 += c16 >>> 16;
  c16 &= 0xFFFF;
  c32 += a32 * b00;
  c48 += c32 >>> 16;
  c32 &= 0xFFFF;
  c32 += a16 * b16;
  c48 += c32 >>> 16;
  c32 &= 0xFFFF;
  c32 += a00 * b32;
  c48 += c32 >>> 16;
  c32 &= 0xFFFF;
  c48 += a48 * b00 + a32 * b16 + a16 * b32 + a00 * b48;
  c48 &= 0xFFFF;
  return fromBits(c16 << 16 | c00, c48 << 16 | c32, $this.unsigned);
}
;
/**
 * Returns this Long divided by the specified. The result is signed if this Long is signed or
 *  unsigned if this Long is unsigned.
 * @param {!Long|number|string} divisor Divisor
 * @returns {!Long} Quotient
 */

function op_Division($this, divisor) {
  if (!isLong(divisor)) divisor = fromValue(divisor);
  if (isZero(divisor)) throw Error("division by zero"); // use wasm support if present

  if (wasm) {
    // guard against signed division overflow: the largest
    // negative number / -1 would be 1 larger than the largest
    // positive number, due to two's complement.
    if (!$this.unsigned && $this.high === -0x80000000 && divisor.low === -1 && divisor.high === -1) {
      // be consistent with non-wasm code path
      return $this;
    }

    var low = ($this.unsigned ? wasm.div_u : wasm.div_s)($this.low, $this.high, divisor.low, divisor.high);
    return fromBits(low, wasm.get_high(), $this.unsigned);
  }

  if (isZero($this)) return $this.unsigned ? UZERO : ZERO;
  var approx, rem, res;

  if (!$this.unsigned) {
    // This section is only relevant for signed longs and is derived from the
    // closure library as a whole.
    if (equals($this, MIN_VALUE)) {
      if (equals(divisor, ONE) || equals(divisor, NEG_ONE)) return MIN_VALUE; // recall that -MIN_VALUE == MIN_VALUE
      else if (equals(divisor, MIN_VALUE)) return ONE;else {
          // At this point, we have |other| >= 2, so |this/other| < |MIN_VALUE|.
          var halfThis = op_RightShift($this, 1);
          approx = op_LeftShift(op_Division(halfThis, divisor), 1);

          if (equals(approx, ZERO)) {
            return isNegative(divisor) ? ONE : NEG_ONE;
          } else {
            rem = op_Subtraction($this, op_Multiply(divisor, approx));
            res = op_Addition(approx, op_Division(rem, divisor));
            return res;
          }
        }
    } else if (equals(divisor, MIN_VALUE)) return $this.unsigned ? UZERO : ZERO;

    if (isNegative($this)) {
      if (isNegative(divisor)) return op_Division(op_UnaryNegation($this), op_UnaryNegation(divisor));
      return op_UnaryNegation(op_Division(op_UnaryNegation($this), divisor));
    } else if (isNegative(divisor)) return op_UnaryNegation(op_Division($this, op_UnaryNegation(divisor)));

    res = ZERO;
  } else {
    // The algorithm below has not been made for unsigned longs. It's therefore
    // required to take special care of the MSB prior to running it.
    if (!divisor.unsigned) divisor = toUnsigned(divisor);
    if (greaterThan(divisor, $this)) return UZERO;
    if (greaterThan(divisor, op_RightShiftUnsigned($this, 1))) // 15 >>> 1 = 7 ; with divisor = 8 ; true
      return UONE;
    res = UZERO;
  } // Repeat the following until the remainder is less than other:  find a
  // floating-point that approximates remainder / other *from below*, add this
  // into the result, and subtract it from the remainder.  It is critical that
  // the approximate value is less than or equal to the real value so that the
  // remainder never becomes negative.


  rem = $this;

  while (greaterThanOrEqual(rem, divisor)) {
    // Approximate the result of division. This may be a little greater or
    // smaller than the actual value.
    approx = Math.max(1, Math.floor(toNumber(rem) / toNumber(divisor))); // We will tweak the approximate result by changing it in the 48-th digit or
    // the smallest non-fractional digit, whichever is larger.

    var log2 = Math.ceil(Math.log(approx) / Math.LN2),
        delta = log2 <= 48 ? 1 : pow_dbl(2, log2 - 48),
        // Decrease the approximation until it is smaller than the remainder.  Note
    // that if it is too large, the product overflows and is negative.
    approxRes = fromNumber(approx),
        approxRem = op_Multiply(approxRes, divisor);

    while (isNegative(approxRem) || greaterThan(approxRem, rem)) {
      approx -= delta;
      approxRes = fromNumber(approx, $this.unsigned);
      approxRem = op_Multiply(approxRes, divisor);
    } // We know the answer can't be zero... and actually, zero would cause
    // infinite recursion since we would make no progress.


    if (isZero(approxRes)) approxRes = ONE;
    res = op_Addition(res, approxRes);
    rem = op_Subtraction(rem, approxRem);
  }

  return res;
}
;
/**
 * Returns this Long modulo the specified.
 * @param {!Long|number|string} divisor Divisor
 * @returns {!Long} Remainder
 */

function op_Modulus($this, divisor) {
  if (!isLong(divisor)) divisor = fromValue(divisor); // use wasm support if present

  if (wasm) {
    var low = ($this.unsigned ? wasm.rem_u : wasm.rem_s)($this.low, $this.high, divisor.low, divisor.high);
    return fromBits(low, wasm.get_high(), $this.unsigned);
  }

  return op_Subtraction($this, op_Multiply(op_Division($this, divisor), divisor));
}
;
/**
 * Returns the bitwise NOT of this Long.
 * @returns {!Long}
 */

function op_LogicalNot($this) {
  return fromBits(~$this.low, ~$this.high, $this.unsigned);
}
;
/**
 * Returns the bitwise AND of this Long and the specified.
 * @param {!Long|number|string} other Other Long
 * @returns {!Long}
 */

function op_BitwiseAnd($this, other) {
  if (!isLong(other)) other = fromValue(other);
  return fromBits($this.low & other.low, $this.high & other.high, $this.unsigned);
}
;
/**
 * Returns the bitwise OR of this Long and the specified.
 * @param {!Long|number|string} other Other Long
 * @returns {!Long}
 */

function op_BitwiseOr($this, other) {
  if (!isLong(other)) other = fromValue(other);
  return fromBits($this.low | other.low, $this.high | other.high, $this.unsigned);
}
;
/**
 * Returns the bitwise XOR of this Long and the given one.
 * @param {!Long|number|string} other Other Long
 * @returns {!Long}
 */

function op_ExclusiveOr($this, other) {
  if (!isLong(other)) other = fromValue(other);
  return fromBits($this.low ^ other.low, $this.high ^ other.high, $this.unsigned);
}
;
/**
 * Returns this Long with bits shifted to the left by the given amount.
 * @param {number|!Long} numBits Number of bits
 * @returns {!Long} Shifted Long
 */

function op_LeftShift($this, numBits) {
  if (isLong(numBits)) numBits = toInt(numBits);
  if ((numBits &= 63) === 0) return $this;else if (numBits < 32) return fromBits($this.low << numBits, $this.high << numBits | $this.low >>> 32 - numBits, $this.unsigned);else return fromBits(0, $this.low << numBits - 32, $this.unsigned);
}
;
/**
 * Returns this Long with bits arithmetically shifted to the right by the given amount.
 * @param {number|!Long} numBits Number of bits
 * @returns {!Long} Shifted Long
 */

function op_RightShift($this, numBits) {
  if (isLong(numBits)) numBits = toInt(numBits);
  if ((numBits &= 63) === 0) return $this;else if (numBits < 32) return fromBits($this.low >>> numBits | $this.high << 32 - numBits, $this.high >> numBits, $this.unsigned);else return fromBits($this.high >> numBits - 32, $this.high >= 0 ? 0 : -1, $this.unsigned);
}
;
/**
 * Returns this Long with bits logically shifted to the right by the given amount.
 * @param {number|!Long} numBits Number of bits
 * @returns {!Long} Shifted Long
 */

function op_RightShiftUnsigned($this, numBits) {
  if (isLong(numBits)) numBits = toInt(numBits);
  numBits &= 63;
  if (numBits === 0) return $this;else {
    var high = $this.high;

    if (numBits < 32) {
      var low = $this.low;
      return fromBits(low >>> numBits | high << 32 - numBits, high >>> numBits, $this.unsigned);
    } else if (numBits === 32) return fromBits(high, 0, $this.unsigned);else return fromBits(high >>> numBits - 32, 0, $this.unsigned);
  }
}
;
/**
 * Converts this Long to signed.
 * @returns {!Long} Signed long
 */

function toSigned($this) {
  if (!$this.unsigned) return $this;
  return fromBits($this.low, $this.high, false);
}
;
/**
 * Converts this Long to unsigned.
 * @returns {!Long} Unsigned long
 */

function toUnsigned($this) {
  if ($this.unsigned) return $this;
  return fromBits($this.low, $this.high, true);
}
;
/**
 * Converts this Long to its byte representation.
 * @param {boolean=} le Whether little or big endian, defaults to big endian
 * @returns {!Array.<number>} Byte representation
 */

function toBytes($this, le) {
  return le ? toBytesLE($this) : toBytesBE($this);
}
;
/**
 * Converts this Long to its little endian byte representation.
 * @returns {!Array.<number>} Little endian byte representation
 */

function toBytesLE($this) {
  var hi = $this.high,
      lo = $this.low;
  return [lo & 0xff, lo >>> 8 & 0xff, lo >>> 16 & 0xff, lo >>> 24, hi & 0xff, hi >>> 8 & 0xff, hi >>> 16 & 0xff, hi >>> 24];
}
;
/**
 * Converts this Long to its big endian byte representation.
 * @returns {!Array.<number>} Big endian byte representation
 */

function toBytesBE($this) {
  var hi = $this.high,
      lo = $this.low;
  return [hi >>> 24, hi >>> 16 & 0xff, hi >>> 8 & 0xff, hi & 0xff, lo >>> 24, lo >>> 16 & 0xff, lo >>> 8 & 0xff, lo & 0xff];
}
;
/**
 * Creates a Long from its byte representation.
 * @param {!Array.<number>} bytes Byte representation
 * @param {boolean=} unsigned Whether unsigned or not, defaults to signed
 * @param {boolean=} le Whether little or big endian, defaults to big endian
 * @returns {Long} The corresponding Long value
 */

function fromBytes(bytes, unsigned, le) {
  return le ? fromBytesLE(bytes, unsigned) : fromBytesBE(bytes, unsigned);
}
;
/**
 * Creates a Long from its little endian byte representation.
 * @param {!Array.<number>} bytes Little endian byte representation
 * @param {boolean=} unsigned Whether unsigned or not, defaults to signed
 * @returns {Long} The corresponding Long value
 */

function fromBytesLE(bytes, unsigned) {
  return new Long(bytes[0] | bytes[1] << 8 | bytes[2] << 16 | bytes[3] << 24, bytes[4] | bytes[5] << 8 | bytes[6] << 16 | bytes[7] << 24, unsigned);
}
;
/**
 * Creates a Long from its big endian byte representation.
 * @param {!Array.<number>} bytes Big endian byte representation
 * @param {boolean=} unsigned Whether unsigned or not, defaults to signed
 * @returns {Long} The corresponding Long value
 */

function fromBytesBE(bytes, unsigned) {
  return new Long(bytes[4] << 24 | bytes[5] << 16 | bytes[6] << 8 | bytes[7], bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3], unsigned);
}
;
function unixEpochMillisecondsToTicks(ms, offset) {
  return op_Multiply(op_Addition(op_Addition(fromNumber(ms), 62135596800000), offset), 10000);
}
function ticksToUnixEpochMilliseconds(ticks) {
  return toNumber(op_Subtraction(op_Division(ticks, 10000), 62135596800000));
}
function makeRangeStepFunction(step, last, unsigned) {
  var zero = unsigned ? UZERO : ZERO;
  return function (x) {
    return greaterThan(step, zero) && lessThanOrEqual(x, last) || lessThan(step, zero) && greaterThanOrEqual(x, last) ? [x, op_Addition(x, step)] : null;
  };
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Observable.js":
/*!**************************************************!*\
  !*** ./.fable/fable-library.2.2.3/Observable.js ***!
  \**************************************************/
/*! exports provided: Observer, protect, add, choose, filter, map, merge, pairwise, partition, scan, split, subscribe */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Observer", function() { return Observer; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "protect", function() { return protect; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "add", function() { return add; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "choose", function() { return choose; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "filter", function() { return filter; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "map", function() { return map; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "merge", function() { return merge; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "pairwise", function() { return pairwise; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "partition", function() { return partition; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "scan", function() { return scan; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "split", function() { return split; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "subscribe", function() { return subscribe; });
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/classCallCheck */ "./node_modules/@babel/runtime/helpers/classCallCheck.js");
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _Option__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Option */ "./.fable/fable-library.2.2.3/Option.js");


var Observer = function Observer(onNext, onError, onCompleted) {
  _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0___default()(this, Observer);

  this.OnNext = onNext;

  this.OnError = onError || function (e) {
    return;
  };

  this.OnCompleted = onCompleted || function () {
    return;
  };
};

var Observable = function Observable(subscribe) {
  _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0___default()(this, Observable);

  this.Subscribe = subscribe;
};

function protect(f, succeed, fail) {
  try {
    return succeed(f());
  } catch (e) {
    fail(e);
  }
}
function add(callback, source) {
  source.Subscribe(new Observer(callback));
}
function choose(chooser, source) {
  return new Observable(function (observer) {
    return source.Subscribe(new Observer(function (t) {
      return protect(function () {
        return chooser(t);
      }, function (u) {
        if (u != null) {
          observer.OnNext(Object(_Option__WEBPACK_IMPORTED_MODULE_1__["value"])(u));
        }
      }, observer.OnError);
    }, observer.OnError, observer.OnCompleted));
  });
}
function filter(predicate, source) {
  return choose(function (x) {
    return predicate(x) ? x : null;
  }, source);
}
function map(mapping, source) {
  return new Observable(function (observer) {
    return source.Subscribe(new Observer(function (t) {
      protect(function () {
        return mapping(t);
      }, observer.OnNext, observer.OnError);
    }, observer.OnError, observer.OnCompleted));
  });
}
function merge(source1, source2) {
  return new Observable(function (observer) {
    var stopped = false;
    var completed1 = false;
    var completed2 = false;
    var h1 = source1.Subscribe(new Observer(function (v) {
      if (!stopped) {
        observer.OnNext(v);
      }
    }, function (e) {
      if (!stopped) {
        stopped = true;
        observer.OnError(e);
      }
    }, function () {
      if (!stopped) {
        completed1 = true;

        if (completed2) {
          stopped = true;
          observer.OnCompleted();
        }
      }
    }));
    var h2 = source2.Subscribe(new Observer(function (v) {
      if (!stopped) {
        observer.OnNext(v);
      }
    }, function (e) {
      if (!stopped) {
        stopped = true;
        observer.OnError(e);
      }
    }, function () {
      if (!stopped) {
        completed2 = true;

        if (completed1) {
          stopped = true;
          observer.OnCompleted();
        }
      }
    }));
    return {
      Dispose: function Dispose() {
        h1.Dispose();
        h2.Dispose();
      }
    };
  });
}
function pairwise(source) {
  return new Observable(function (observer) {
    var last = null;
    return source.Subscribe(new Observer(function (next) {
      if (last != null) {
        observer.OnNext([last, next]);
      }

      last = next;
    }, observer.OnError, observer.OnCompleted));
  });
}
function partition(predicate, source) {
  return [filter(predicate, source), filter(function (x) {
    return !predicate(x);
  }, source)];
}
function scan(collector, state, source) {
  return new Observable(function (observer) {
    return source.Subscribe(new Observer(function (t) {
      protect(function () {
        return collector(state, t);
      }, function (u) {
        state = u;
        observer.OnNext(u);
      }, observer.OnError);
    }, observer.OnError, observer.OnCompleted));
  });
}
function split(splitter, source) {
  return [choose(function (v) {
    return Object(_Option__WEBPACK_IMPORTED_MODULE_1__["tryValueIfChoice1"])(splitter(v));
  }, source), choose(function (v) {
    return Object(_Option__WEBPACK_IMPORTED_MODULE_1__["tryValueIfChoice2"])(splitter(v));
  }, source)];
}
function subscribe(callback, source) {
  return source.Subscribe(new Observer(callback));
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Option.js":
/*!**********************************************!*\
  !*** ./.fable/fable-library.2.2.3/Option.js ***!
  \**********************************************/
/*! exports provided: Some, some, value, defaultArg, defaultArgWith, filter, Choice, choice1, choice2, tryValueIfChoice1, tryValueIfChoice2, Result, ok, error, mapOk, mapError, bindOk */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Some", function() { return Some; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "some", function() { return some; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "value", function() { return value; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "defaultArg", function() { return defaultArg; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "defaultArgWith", function() { return defaultArgWith; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "filter", function() { return filter; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Choice", function() { return Choice; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "choice1", function() { return choice1; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "choice2", function() { return choice2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryValueIfChoice1", function() { return tryValueIfChoice1; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryValueIfChoice2", function() { return tryValueIfChoice2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Result", function() { return Result; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ok", function() { return ok; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "error", function() { return error; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mapOk", function() { return mapOk; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mapError", function() { return mapError; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "bindOk", function() { return bindOk; });
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/classCallCheck */ "./node_modules/@babel/runtime/helpers/classCallCheck.js");
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @babel/runtime/helpers/createClass */ "./node_modules/@babel/runtime/helpers/createClass.js");
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _Types__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./Types */ "./.fable/fable-library.2.2.3/Types.js");
/* harmony import */ var _Util__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./Util */ "./.fable/fable-library.2.2.3/Util.js");



 // Options are erased in runtime by Fable, but we have
// the `Some` type below to wrap values that would evaluate
// to null in runtime. These two rules must be followed:
// 1- None is always null in runtime, a non-strict null check
//    (`x == null`) is enough to check the case of an option.
// 2- To get the value of an option the `getValue` helper
//    below must **always** be used.
// export type Option<T> = T | Some<T>;
// Using a class here for better compatibility with TS files importing Some

var Some =
/*#__PURE__*/
function () {
  function Some(value) {
    _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_0___default()(this, Some);

    this.value = value;
  } // Don't add "Some" for consistency with erased options


  _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_1___default()(Some, [{
    key: "toString",
    value: function toString() {
      return String(this.value);
    }
  }, {
    key: "toJSON",
    value: function toJSON() {
      return this.value;
    }
  }, {
    key: "GetHashCode",
    value: function GetHashCode() {
      return Object(_Util__WEBPACK_IMPORTED_MODULE_3__["structuralHash"])(this.value);
    }
  }, {
    key: "Equals",
    value: function Equals(other) {
      return other == null ? false : Object(_Util__WEBPACK_IMPORTED_MODULE_3__["equals"])(this.value, other instanceof Some ? other.value : other);
    }
  }, {
    key: "CompareTo",
    value: function CompareTo(other) {
      return other == null ? 1 : Object(_Util__WEBPACK_IMPORTED_MODULE_3__["compare"])(this.value, other instanceof Some ? other.value : other);
    }
  }]);

  return Some;
}();
function some(x) {
  return x == null || x instanceof Some ? new Some(x) : x;
}
function value(x, acceptNull) {
  if (x == null) {
    if (!acceptNull) {
      throw new Error("Option has no value");
    }

    return null;
  } else {
    return x instanceof Some ? x.value : x;
  }
}
function defaultArg(arg, defaultValue, f) {
  return arg == null ? defaultValue : f != null ? f(value(arg)) : value(arg);
}
function defaultArgWith(arg, defThunk) {
  return arg == null ? defThunk() : value(arg);
}
function filter(predicate, arg) {
  return arg != null ? !predicate(value(arg)) ? null : arg : arg;
} // CHOICE

var Choice = Object(_Types__WEBPACK_IMPORTED_MODULE_2__["declare"])(function Choice(tag, name, field) {
  _Types__WEBPACK_IMPORTED_MODULE_2__["Union"].call(this, tag, name, field);
}, _Types__WEBPACK_IMPORTED_MODULE_2__["Union"]);
function choice1(x) {
  return new Choice(0, "Choice1Of2", x);
}
function choice2(x) {
  return new Choice(1, "Choice2Of2", x);
}
function tryValueIfChoice1(x) {
  return x.tag === 0 ? some(x.fields[0]) : null;
}
function tryValueIfChoice2(x) {
  return x.tag === 1 ? some(x.fields[0]) : null;
} // RESULT

var Result = Object(_Types__WEBPACK_IMPORTED_MODULE_2__["declare"])(function Result(tag, name, field) {
  _Types__WEBPACK_IMPORTED_MODULE_2__["Union"].call(this, tag, name, field);
}, _Types__WEBPACK_IMPORTED_MODULE_2__["Union"]);
function ok(x) {
  return new Result(0, "Ok", x);
}
function error(x) {
  return new Result(1, "Error", x);
}
function mapOk(f, result) {
  return result.tag === 0 ? ok(f(result.fields[0])) : result;
}
function mapError(f, result) {
  return result.tag === 1 ? error(f(result.fields[0])) : result;
}
function bindOk(f, result) {
  return result.tag === 0 ? f(result.fields[0]) : result;
}

/***/ }),

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

/***/ "./.fable/fable-library.2.2.3/RegExp.js":
/*!**********************************************!*\
  !*** ./.fable/fable-library.2.2.3/RegExp.js ***!
  \**********************************************/
/*! exports provided: create, escape, unescape, isMatch, match, matches, options, replace, split */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "create", function() { return create; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "escape", function() { return escape; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "unescape", function() { return unescape; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isMatch", function() { return isMatch; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "match", function() { return match; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "matches", function() { return matches; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "options", function() { return options; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "replace", function() { return replace; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "split", function() { return split; });
function create(pattern, options) {
  // Supported RegexOptions
  // * IgnoreCase:  0x0001
  // * Multiline:   0x0002
  // * ECMAScript:  0x0100 (ignored)
  if ((options & ~(1 ^ 2 ^ 256)) !== 0) {
    throw new Error("RegexOptions only supports: IgnoreCase, Multiline and ECMAScript");
  }

  var flags = "g";
  flags += options & 1 ? "i" : ""; // 0x0001 RegexOptions.IgnoreCase

  flags += options & 2 ? "m" : "";
  return new RegExp(pattern, flags);
} // From http://stackoverflow.com/questions/3446170/escape-string-for-use-in-javascript-regex

function escape(str) {
  return str.replace(/[\-\[\/\{\}\(\)\*\+\?\.\\\^\$\|]/g, "\\$&");
}
function unescape(str) {
  return str.replace(/\\([\-\[\/\{\}\(\)\*\+\?\.\\\^\$\|])/g, "$1");
}
function isMatch(str, pattern) {
  var options = arguments.length > 2 && arguments[2] !== undefined ? arguments[2] : 0;
  var reg;
  reg = str instanceof RegExp ? (reg = str, str = pattern, reg.lastIndex = options, reg) : reg = create(pattern, options);
  return reg.test(str);
}
function match(str, pattern) {
  var options = arguments.length > 2 && arguments[2] !== undefined ? arguments[2] : 0;
  var reg;
  reg = str instanceof RegExp ? (reg = str, str = pattern, reg.lastIndex = options, reg) : reg = create(pattern, options);
  return reg.exec(str);
}
function matches(str, pattern) {
  var options = arguments.length > 2 && arguments[2] !== undefined ? arguments[2] : 0;
  var reg;
  reg = str instanceof RegExp ? (reg = str, str = pattern, reg.lastIndex = options, reg) : reg = create(pattern, options);

  if (!reg.global) {
    throw new Error("Non-global RegExp"); // Prevent infinite loop
  }

  var m = reg.exec(str);
  var matches = [];

  while (m !== null) {
    matches.push(m);
    m = reg.exec(str);
  }

  return matches;
}
function options(reg) {
  var options = 256; // ECMAScript

  options |= reg.ignoreCase ? 1 : 0;
  options |= reg.multiline ? 2 : 0;
  return options;
}
function replace(reg, input, replacement, limit) {
  var offset = arguments.length > 4 && arguments[4] !== undefined ? arguments[4] : 0;

  function replacer() {
    var res = arguments[0];

    if (limit !== 0) {
      limit--;
      var _match = [];
      var len = arguments.length;

      for (var i = 0; i < len - 2; i++) {
        _match.push(arguments[i]);
      }

      _match.index = arguments[len - 2];
      _match.input = arguments[len - 1];
      res = replacement(_match);
    }

    return res;
  }

  if (typeof reg === "string") {
    var tmp = reg;
    reg = create(input, limit);
    input = tmp;
    limit = undefined;
  }

  if (typeof replacement === "function") {
    limit = limit == null ? -1 : limit;
    return input.substring(0, offset) + input.substring(offset).replace(reg, replacer);
  } else {
    // $0 doesn't work with JS regex, see #1155
    replacement = replacement.replace(/\$0/g, function (s) {
      return "$&";
    });

    if (limit != null) {
      var m;
      var sub1 = input.substring(offset);

      var _matches = matches(reg, sub1);

      var sub2 = matches.length > limit ? (m = _matches[limit - 1], sub1.substring(0, m.index + m[0].length)) : sub1;
      return input.substring(0, offset) + sub2.replace(reg, replacement) + input.substring(offset + sub2.length);
    } else {
      return input.replace(reg, replacement);
    }
  }
}
function split(reg, input, limit) {
  var offset = arguments.length > 3 && arguments[3] !== undefined ? arguments[3] : 0;

  if (typeof reg === "string") {
    var tmp = reg;
    reg = create(input, limit);
    input = tmp;
    limit = undefined;
  }

  input = input.substring(offset);
  return input.split(reg, limit);
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/Seq.js":
/*!*******************************************!*\
  !*** ./.fable/fable-library.2.2.3/Seq.js ***!
  \*******************************************/
/*! exports provided: Enumerator, getEnumerator, toIterator, ofArray, append, average, averageBy, concat, collect, choose, compareWith, delay, empty, enumerateWhile, enumerateThenFinally, enumerateUsing, exactlyOne, except, exists, exists2, forAll, forAll2, contains, filter, where, fold, foldBack, fold2, foldBack2, tryHead, head, initialize, initializeInfinite, tryItem, item, iterate, iterate2, iterateIndexed, iterateIndexed2, isEmpty, tryLast, last, length, map, mapIndexed, indexed, map2, mapIndexed2, map3, mapFold, mapFoldBack, max, maxBy, min, minBy, pairwise, rangeChar, rangeLong, rangeNumber, readOnly, reduce, reduceBack, replicate, reverse, scan, scanBack, singleton, skip, skipWhile, sortWith, sum, sumBy, tail, take, truncate, takeWhile, tryFind, find, tryFindBack, findBack, tryFindIndex, findIndex, tryFindIndexBack, findIndexBack, tryPick, pick, unfold, zip, zip3, windowed */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Enumerator", function() { return Enumerator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getEnumerator", function() { return getEnumerator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toIterator", function() { return toIterator; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ofArray", function() { return ofArray; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "append", function() { return append; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "average", function() { return average; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "averageBy", function() { return averageBy; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "concat", function() { return concat; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "collect", function() { return collect; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "choose", function() { return choose; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareWith", function() { return compareWith; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "delay", function() { return delay; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "empty", function() { return empty; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "enumerateWhile", function() { return enumerateWhile; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "enumerateThenFinally", function() { return enumerateThenFinally; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "enumerateUsing", function() { return enumerateUsing; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "exactlyOne", function() { return exactlyOne; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "except", function() { return except; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "exists", function() { return exists; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "exists2", function() { return exists2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "forAll", function() { return forAll; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "forAll2", function() { return forAll2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "contains", function() { return contains; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "filter", function() { return filter; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "where", function() { return where; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fold", function() { return fold; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "foldBack", function() { return foldBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fold2", function() { return fold2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "foldBack2", function() { return foldBack2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryHead", function() { return tryHead; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "head", function() { return head; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "initialize", function() { return initialize; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "initializeInfinite", function() { return initializeInfinite; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryItem", function() { return tryItem; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "item", function() { return item; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "iterate", function() { return iterate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "iterate2", function() { return iterate2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "iterateIndexed", function() { return iterateIndexed; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "iterateIndexed2", function() { return iterateIndexed2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isEmpty", function() { return isEmpty; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryLast", function() { return tryLast; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "last", function() { return last; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "length", function() { return length; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "map", function() { return map; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mapIndexed", function() { return mapIndexed; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "indexed", function() { return indexed; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "map2", function() { return map2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mapIndexed2", function() { return mapIndexed2; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "map3", function() { return map3; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mapFold", function() { return mapFold; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "mapFoldBack", function() { return mapFoldBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "max", function() { return max; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "maxBy", function() { return maxBy; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "min", function() { return min; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "minBy", function() { return minBy; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "pairwise", function() { return pairwise; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "rangeChar", function() { return rangeChar; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "rangeLong", function() { return rangeLong; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "rangeNumber", function() { return rangeNumber; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "readOnly", function() { return readOnly; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "reduce", function() { return reduce; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "reduceBack", function() { return reduceBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "replicate", function() { return replicate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "reverse", function() { return reverse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "scan", function() { return scan; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "scanBack", function() { return scanBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "singleton", function() { return singleton; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "skip", function() { return skip; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "skipWhile", function() { return skipWhile; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "sortWith", function() { return sortWith; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "sum", function() { return sum; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "sumBy", function() { return sumBy; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tail", function() { return tail; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "take", function() { return take; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "truncate", function() { return truncate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "takeWhile", function() { return takeWhile; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryFind", function() { return tryFind; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "find", function() { return find; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryFindBack", function() { return tryFindBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "findBack", function() { return findBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryFindIndex", function() { return tryFindIndex; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "findIndex", function() { return findIndex; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryFindIndexBack", function() { return tryFindIndexBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "findIndexBack", function() { return findIndexBack; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "tryPick", function() { return tryPick; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "pick", function() { return pick; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "unfold", function() { return unfold; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "zip", function() { return zip; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "zip3", function() { return zip3; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "windowed", function() { return windowed; });
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/slicedToArray */ "./node_modules/@babel/runtime/helpers/slicedToArray.js");
/* harmony import */ var _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @babel/runtime/helpers/defineProperty */ "./node_modules/@babel/runtime/helpers/defineProperty.js");
/* harmony import */ var _babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @babel/runtime/helpers/classCallCheck */ "./node_modules/@babel/runtime/helpers/classCallCheck.js");
/* harmony import */ var _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @babel/runtime/helpers/createClass */ "./node_modules/@babel/runtime/helpers/createClass.js");
/* harmony import */ var _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_3___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_3__);
/* harmony import */ var _Long__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./Long */ "./.fable/fable-library.2.2.3/Long.js");
/* harmony import */ var _Option__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./Option */ "./.fable/fable-library.2.2.3/Option.js");
/* harmony import */ var _Util__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./Util */ "./.fable/fable-library.2.2.3/Util.js");







var Enumerator =
/*#__PURE__*/
function () {
  function Enumerator(iter) {
    _babel_runtime_helpers_classCallCheck__WEBPACK_IMPORTED_MODULE_2___default()(this, Enumerator);

    this.iter = iter;
  }

  _babel_runtime_helpers_createClass__WEBPACK_IMPORTED_MODULE_3___default()(Enumerator, [{
    key: "MoveNext",
    value: function MoveNext() {
      var cur = this.iter.next();
      this.current = cur.value;
      return !cur.done;
    }
  }, {
    key: "Reset",
    value: function Reset() {
      throw new Error("JS iterators cannot be reset");
    }
  }, {
    key: "Dispose",
    value: function Dispose() {
      return;
    }
  }, {
    key: "Current",
    get: function get() {
      return this.current;
    }
  }]);

  return Enumerator;
}();
function getEnumerator(o) {
  return new Enumerator(o[Symbol.iterator]());
}
function toIterator(en) {
  return {
    next: function next() {
      return en.MoveNext() ? {
        done: false,
        value: en.Current
      } : {
        done: true,
        value: null
      };
    }
  };
} // export function toIterable<T>(en: IEnumerable<T>): Iterable<T> {
//   return {
//     [Symbol.iterator]() {
//       return toIterator(en.GetEnumerator());
//     },
//   };
// }

function __failIfNone(res) {
  if (res == null) {
    throw new Error("Seq did not contain any matching element");
  }

  return Object(_Option__WEBPACK_IMPORTED_MODULE_5__["value"])(res);
}

function ofArray(xs) {
  return delay(function () {
    return unfold(function (i) {
      return i < xs.length ? [xs[i], i + 1] : null;
    }, 0);
  });
}
function append(xs, ys) {
  return delay(function () {
    var firstDone = false;
    var i = xs[Symbol.iterator]();
    var iters = [i, null];
    return unfold(function () {
      var cur;

      if (!firstDone) {
        cur = iters[0].next();

        if (!cur.done) {
          return [cur.value, iters];
        } else {
          firstDone = true;
          iters = [null, ys[Symbol.iterator]()];
        }
      }

      cur = iters[1].next();
      return !cur.done ? [cur.value, iters] : null;
    }, iters);
  });
}
function average(xs, averager) {
  var count = 0;
  var total = fold(function (acc, x) {
    count++;
    return averager.Add(acc, x);
  }, averager.GetZero(), xs);
  return averager.DivideByInt(total, count);
}
function averageBy(f, xs, averager) {
  var count = 0;
  var total = fold(function (acc, x) {
    count++;
    return averager.Add(acc, f(x));
  }, averager.GetZero(), xs);
  return averager.DivideByInt(total, count);
}
function concat(xs) {
  return delay(function () {
    var iter = xs[Symbol.iterator]();
    var output = {
      value: null
    };
    return unfold(function (innerIter) {
      var hasFinished = false;

      while (!hasFinished) {
        if (innerIter == null) {
          var cur = iter.next();

          if (!cur.done) {
            innerIter = cur.value[Symbol.iterator]();
          } else {
            hasFinished = true;
          }
        } else {
          var _cur = innerIter.next();

          if (!_cur.done) {
            output = {
              value: _cur.value
            };
            hasFinished = true;
          } else {
            innerIter = null;
          }
        }
      }

      return innerIter != null && output != null ? [output.value, innerIter] : null;
    }, null);
  });
}
function collect(f, xs) {
  return concat(map(f, xs));
}
function choose(f, xs) {
  return delay(function () {
    return unfold(function (iter) {
      var cur = iter.next();

      while (!cur.done) {
        var y = f(cur.value);

        if (y != null) {
          return [Object(_Option__WEBPACK_IMPORTED_MODULE_5__["value"])(y), iter];
        }

        cur = iter.next();
      }

      return null;
    }, xs[Symbol.iterator]());
  });
}
function compareWith(f, xs, ys) {
  var nonZero = tryFind(function (i) {
    return i !== 0;
  }, map2(function (x, y) {
    return f(x, y);
  }, xs, ys));
  return nonZero != null ? Object(_Option__WEBPACK_IMPORTED_MODULE_5__["value"])(nonZero) : length(xs) - length(ys);
}
function delay(f) {
  return _babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1___default()({}, Symbol.iterator, function () {
    return f()[Symbol.iterator]();
  });
}
function empty() {
  return unfold(function () {
    return void 0;
  });
}
function enumerateWhile(cond, xs) {
  return concat(unfold(function () {
    return cond() ? [xs, true] : null;
  }));
}
function enumerateThenFinally(xs, finalFn) {
  return delay(function () {
    var iter;

    try {
      iter = xs[Symbol.iterator]();
    } catch (err) {
      return void 0;
    } finally {
      finalFn();
    }

    return unfold(function (it) {
      try {
        var cur = it.next();
        return !cur.done ? [cur.value, it] : null;
      } catch (err) {
        return void 0;
      } finally {
        finalFn();
      }
    }, iter);
  });
}
function enumerateUsing(disp, work) {
  var isDisposed = false;

  var disposeOnce = function disposeOnce() {
    if (!isDisposed) {
      isDisposed = true;
      disp.Dispose();
    }
  };

  try {
    return enumerateThenFinally(work(disp), disposeOnce);
  } catch (err) {
    return void 0;
  } finally {
    disposeOnce();
  }
}
function exactlyOne(xs) {
  var iter = xs[Symbol.iterator]();
  var fst = iter.next();

  if (fst.done) {
    throw new Error("Seq was empty");
  }

  var snd = iter.next();

  if (!snd.done) {
    throw new Error("Seq had multiple items");
  }

  return fst.value;
}
function except(itemsToExclude, source) {
  var exclusionItems = Array.from(itemsToExclude);

  var testIsNotInExclusionItems = function testIsNotInExclusionItems(element) {
    return !exclusionItems.some(function (excludedItem) {
      return Object(_Util__WEBPACK_IMPORTED_MODULE_6__["equals"])(excludedItem, element);
    });
  };

  return filter(testIsNotInExclusionItems, source);
}
function exists(f, xs) {
  var cur;

  for (var iter = xs[Symbol.iterator]();;) {
    cur = iter.next();

    if (cur.done) {
      break;
    }

    if (f(cur.value)) {
      return true;
    }
  }

  return false;
}
function exists2(f, xs, ys) {
  var cur1;
  var cur2;

  for (var iter1 = xs[Symbol.iterator](), iter2 = ys[Symbol.iterator]();;) {
    cur1 = iter1.next();
    cur2 = iter2.next();

    if (cur1.done || cur2.done) {
      break;
    }

    if (f(cur1.value, cur2.value)) {
      return true;
    }
  }

  return false;
}
function forAll(f, xs) {
  return !exists(function (x) {
    return !f(x);
  }, xs);
}
function forAll2(f, xs, ys) {
  return !exists2(function (x, y) {
    return !f(x, y);
  }, xs, ys);
}
function contains(i, xs) {
  return exists(function (x) {
    return Object(_Util__WEBPACK_IMPORTED_MODULE_6__["equals"])(x, i);
  }, xs);
}
function filter(f, xs) {
  return delay(function () {
    return unfold(function (iter) {
      var cur = iter.next();

      while (!cur.done) {
        if (f(cur.value)) {
          return [cur.value, iter];
        }

        cur = iter.next();
      }

      return null;
    }, xs[Symbol.iterator]());
  });
}
function where(f, xs) {
  return filter(f, xs);
}
function fold(f, acc, xs) {
  if (Array.isArray(xs) || ArrayBuffer.isView(xs)) {
    return xs.reduce(f, acc);
  } else {
    var cur;

    for (var i = 0, iter = xs[Symbol.iterator]();; i++) {
      cur = iter.next();

      if (cur.done) {
        break;
      }

      acc = f(acc, cur.value, i);
    }

    return acc;
  }
}
function foldBack(f, xs, acc) {
  var arr = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs : Array.from(xs);

  for (var i = arr.length - 1; i >= 0; i--) {
    acc = f(arr[i], acc, i);
  }

  return acc;
}
function fold2(f, acc, xs, ys) {
  var iter1 = xs[Symbol.iterator]();
  var iter2 = ys[Symbol.iterator]();
  var cur1;
  var cur2;

  for (var i = 0;; i++) {
    cur1 = iter1.next();
    cur2 = iter2.next();

    if (cur1.done || cur2.done) {
      break;
    }

    acc = f(acc, cur1.value, cur2.value, i);
  }

  return acc;
}
function foldBack2(f, xs, ys, acc) {
  var ar1 = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs : Array.from(xs);
  var ar2 = Array.isArray(ys) || ArrayBuffer.isView(ys) ? ys : Array.from(ys);

  for (var i = ar1.length - 1; i >= 0; i--) {
    acc = f(ar1[i], ar2[i], acc, i);
  }

  return acc;
}
function tryHead(xs) {
  var iter = xs[Symbol.iterator]();
  var cur = iter.next();
  return cur.done ? null : Object(_Option__WEBPACK_IMPORTED_MODULE_5__["some"])(cur.value);
}
function head(xs) {
  return __failIfNone(tryHead(xs));
}
function initialize(n, f) {
  return delay(function () {
    return unfold(function (i) {
      return i < n ? [f(i), i + 1] : null;
    }, 0);
  });
}
function initializeInfinite(f) {
  return delay(function () {
    return unfold(function (i) {
      return [f(i), i + 1];
    }, 0);
  });
}
function tryItem(i, xs) {
  if (i < 0) {
    return null;
  }

  if (Array.isArray(xs) || ArrayBuffer.isView(xs)) {
    return i < xs.length ? Object(_Option__WEBPACK_IMPORTED_MODULE_5__["some"])(xs[i]) : null;
  }

  for (var j = 0, iter = xs[Symbol.iterator]();; j++) {
    var cur = iter.next();

    if (cur.done) {
      break;
    }

    if (j === i) {
      return Object(_Option__WEBPACK_IMPORTED_MODULE_5__["some"])(cur.value);
    }
  }

  return null;
}
function item(i, xs) {
  return __failIfNone(tryItem(i, xs));
}
function iterate(f, xs) {
  fold(function (_, x) {
    return f(x);
  }, null, xs);
}
function iterate2(f, xs, ys) {
  fold2(function (_, x, y) {
    return f(x, y);
  }, null, xs, ys);
}
function iterateIndexed(f, xs) {
  fold(function (_, x, i) {
    return f(i, x);
  }, null, xs);
}
function iterateIndexed2(f, xs, ys) {
  fold2(function (_, x, y, i) {
    return f(i, x, y);
  }, null, xs, ys);
}
function isEmpty(xs) {
  var i = xs[Symbol.iterator]();
  return i.next().done;
}
function tryLast(xs) {
  return isEmpty(xs) ? null : Object(_Option__WEBPACK_IMPORTED_MODULE_5__["some"])(reduce(function (_, x) {
    return x;
  }, xs));
}
function last(xs) {
  return __failIfNone(tryLast(xs));
}
function length(xs) {
  return Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs.length : fold(function (acc, x) {
    return acc + 1;
  }, 0, xs);
}
function map(f, xs) {
  return delay(function () {
    return unfold(function (iter) {
      var cur = iter.next();
      return !cur.done ? [f(cur.value), iter] : null;
    }, xs[Symbol.iterator]());
  });
}
function mapIndexed(f, xs) {
  return delay(function () {
    var i = 0;
    return unfold(function (iter) {
      var cur = iter.next();
      return !cur.done ? [f(i++, cur.value), iter] : null;
    }, xs[Symbol.iterator]());
  });
}
function indexed(xs) {
  return mapIndexed(function (i, x) {
    return [i, x];
  }, xs);
}
function map2(f, xs, ys) {
  return delay(function () {
    var iter1 = xs[Symbol.iterator]();
    var iter2 = ys[Symbol.iterator]();
    return unfold(function () {
      var cur1 = iter1.next();
      var cur2 = iter2.next();
      return !cur1.done && !cur2.done ? [f(cur1.value, cur2.value), null] : null;
    });
  });
}
function mapIndexed2(f, xs, ys) {
  return delay(function () {
    var i = 0;
    var iter1 = xs[Symbol.iterator]();
    var iter2 = ys[Symbol.iterator]();
    return unfold(function () {
      var cur1 = iter1.next();
      var cur2 = iter2.next();
      return !cur1.done && !cur2.done ? [f(i++, cur1.value, cur2.value), null] : null;
    });
  });
}
function map3(f, xs, ys, zs) {
  return delay(function () {
    var iter1 = xs[Symbol.iterator]();
    var iter2 = ys[Symbol.iterator]();
    var iter3 = zs[Symbol.iterator]();
    return unfold(function () {
      var cur1 = iter1.next();
      var cur2 = iter2.next();
      var cur3 = iter3.next();
      return !cur1.done && !cur2.done && !cur3.done ? [f(cur1.value, cur2.value, cur3.value), null] : null;
    });
  });
}
function mapFold(f, acc, xs, transform) {
  var result = [];
  var r;
  var cur;

  for (var i = 0, iter = xs[Symbol.iterator]();; i++) {
    cur = iter.next();

    if (cur.done) {
      break;
    }

    var _f = f(acc, cur.value);

    var _f2 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_f, 2);

    r = _f2[0];
    acc = _f2[1];
    result.push(r);
  }

  return transform !== void 0 ? [transform(result), acc] : [result, acc];
}
function mapFoldBack(f, xs, acc, transform) {
  var arr = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs : Array.from(xs);
  var result = [];
  var r;

  for (var i = arr.length - 1; i >= 0; i--) {
    var _f3 = f(arr[i], acc);

    var _f4 = _babel_runtime_helpers_slicedToArray__WEBPACK_IMPORTED_MODULE_0___default()(_f3, 2);

    r = _f4[0];
    acc = _f4[1];
    result.push(r);
  }

  return transform !== void 0 ? [transform(result), acc] : [result, acc];
}
function max(xs, comparer) {
  var compareFn = comparer != null ? comparer.Compare : _Util__WEBPACK_IMPORTED_MODULE_6__["compare"];
  return reduce(function (acc, x) {
    return compareFn(acc, x) === 1 ? acc : x;
  }, xs);
}
function maxBy(f, xs, comparer) {
  var compareFn = comparer != null ? comparer.Compare : _Util__WEBPACK_IMPORTED_MODULE_6__["compare"];
  return reduce(function (acc, x) {
    return compareFn(f(acc), f(x)) === 1 ? acc : x;
  }, xs);
}
function min(xs, comparer) {
  var compareFn = comparer != null ? comparer.Compare : _Util__WEBPACK_IMPORTED_MODULE_6__["compare"];
  return reduce(function (acc, x) {
    return compareFn(acc, x) === -1 ? acc : x;
  }, xs);
}
function minBy(f, xs, comparer) {
  var compareFn = comparer != null ? comparer.Compare : _Util__WEBPACK_IMPORTED_MODULE_6__["compare"];
  return reduce(function (acc, x) {
    return compareFn(f(acc), f(x)) === -1 ? acc : x;
  }, xs);
}
function pairwise(xs) {
  return skip(2, scan(function (last, next) {
    return [last[1], next];
  }, [0, 0], xs));
}
function rangeChar(first, last) {
  return delay(function () {
    return unfold(function (x) {
      return x <= last ? [x, String.fromCharCode(x.charCodeAt(0) + 1)] : null;
    }, first);
  });
}
function rangeLong(first, step, last, unsigned) {
  var stepFn = Object(_Long__WEBPACK_IMPORTED_MODULE_4__["makeRangeStepFunction"])(step, last, unsigned);
  return delay(function () {
    return unfold(stepFn, first);
  });
}
function rangeNumber(first, step, last) {
  if (step === 0) {
    throw new Error("Step cannot be 0");
  }

  return delay(function () {
    return unfold(function (x) {
      return step > 0 && x <= last || step < 0 && x >= last ? [x, x + step] : null;
    }, first);
  });
}
function readOnly(xs) {
  return map(function (x) {
    return x;
  }, xs);
}
function reduce(f, xs) {
  if (Array.isArray(xs) || ArrayBuffer.isView(xs)) {
    return xs.reduce(f);
  }

  var iter = xs[Symbol.iterator]();
  var cur = iter.next();

  if (cur.done) {
    throw new Error("Seq was empty");
  }

  var acc = cur.value;

  while (true) {
    cur = iter.next();

    if (cur.done) {
      break;
    }

    acc = f(acc, cur.value);
  }

  return acc;
}
function reduceBack(f, xs) {
  var ar = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs : Array.from(xs);

  if (ar.length === 0) {
    throw new Error("Seq was empty");
  }

  var acc = ar[ar.length - 1];

  for (var i = ar.length - 2; i >= 0; i--) {
    acc = f(ar[i], acc, i);
  }

  return acc;
}
function replicate(n, x) {
  return initialize(n, function () {
    return x;
  });
}
function reverse(xs) {
  var ar = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs.slice(0) : Array.from(xs);
  return ofArray(ar.reverse());
}
function scan(f, seed, xs) {
  return delay(function () {
    var iter = xs[Symbol.iterator]();
    return unfold(function (acc) {
      if (acc == null) {
        return [seed, seed];
      }

      var cur = iter.next();

      if (!cur.done) {
        acc = f(acc, cur.value);
        return [acc, acc];
      }

      return void 0;
    }, null);
  });
}
function scanBack(f, xs, seed) {
  return reverse(scan(function (acc, x) {
    return f(x, acc);
  }, seed, reverse(xs)));
}
function singleton(y) {
  return [y];
}
function skip(n, xs) {
  return _babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1___default()({}, Symbol.iterator, function () {
    var iter = xs[Symbol.iterator]();

    for (var i = 1; i <= n; i++) {
      if (iter.next().done) {
        throw new Error("Seq has not enough elements");
      }
    }

    return iter;
  });
}
function skipWhile(f, xs) {
  return delay(function () {
    var hasPassed = false;
    return filter(function (x) {
      return hasPassed || (hasPassed = !f(x));
    }, xs);
  });
}
function sortWith(f, xs) {
  var ys = Array.from(xs);
  return ofArray(ys.sort(f));
}
function sum(xs, adder) {
  return fold(function (acc, x) {
    return adder.Add(acc, x);
  }, adder.GetZero(), xs);
}
function sumBy(f, xs, adder) {
  return fold(function (acc, x) {
    return adder.Add(acc, f(x));
  }, adder.GetZero(), xs);
}
function tail(xs) {
  var iter = xs[Symbol.iterator]();
  var cur = iter.next();

  if (cur.done) {
    throw new Error("Seq was empty");
  }

  return _babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1___default()({}, Symbol.iterator, function () {
    return iter;
  });
}
function take(n, xs) {
  var truncate = arguments.length > 2 && arguments[2] !== undefined ? arguments[2] : false;
  return delay(function () {
    var iter = xs[Symbol.iterator]();
    return unfold(function (i) {
      if (i < n) {
        var cur = iter.next();

        if (!cur.done) {
          return [cur.value, i + 1];
        }

        if (!truncate) {
          throw new Error("Seq has not enough elements");
        }
      }

      return void 0;
    }, 0);
  });
}
function truncate(n, xs) {
  return take(n, xs, true);
}
function takeWhile(f, xs) {
  return delay(function () {
    var iter = xs[Symbol.iterator]();
    return unfold(function (i) {
      var cur = iter.next();

      if (!cur.done && f(cur.value)) {
        return [cur.value, null];
      }

      return void 0;
    }, 0);
  });
}
function tryFind(f, xs, defaultValue) {
  for (var i = 0, iter = xs[Symbol.iterator]();; i++) {
    var cur = iter.next();

    if (cur.done) {
      break;
    }

    if (f(cur.value, i)) {
      return Object(_Option__WEBPACK_IMPORTED_MODULE_5__["some"])(cur.value);
    }
  }

  return defaultValue === void 0 ? null : Object(_Option__WEBPACK_IMPORTED_MODULE_5__["some"])(defaultValue);
}
function find(f, xs) {
  return __failIfNone(tryFind(f, xs));
}
function tryFindBack(f, xs, defaultValue) {
  var arr = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs.slice(0) : Array.from(xs);
  return tryFind(f, arr.reverse(), defaultValue);
}
function findBack(f, xs) {
  return __failIfNone(tryFindBack(f, xs));
}
function tryFindIndex(f, xs) {
  for (var i = 0, iter = xs[Symbol.iterator]();; i++) {
    var cur = iter.next();

    if (cur.done) {
      break;
    }

    if (f(cur.value, i)) {
      return i;
    }
  }

  return null;
}
function findIndex(f, xs) {
  return __failIfNone(tryFindIndex(f, xs));
}
function tryFindIndexBack(f, xs) {
  var arr = Array.isArray(xs) || ArrayBuffer.isView(xs) ? xs.slice(0) : Array.from(xs);

  for (var i = arr.length - 1; i >= 0; i--) {
    if (f(arr[i], i)) {
      return i;
    }
  }

  return null;
}
function findIndexBack(f, xs) {
  return __failIfNone(tryFindIndexBack(f, xs));
}
function tryPick(f, xs) {
  for (var i = 0, iter = xs[Symbol.iterator]();; i++) {
    var cur = iter.next();

    if (cur.done) {
      break;
    }

    var y = f(cur.value, i);

    if (y != null) {
      return y;
    }
  }

  return null;
}
function pick(f, xs) {
  return __failIfNone(tryPick(f, xs));
}
function unfold(f, fst) {
  return _babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1___default()({}, Symbol.iterator, function () {
    // Capture a copy of the first value in the closure
    // so the sequence is restarted every time, see #1230
    var acc = fst;
    return {
      next: function next() {
        var res = f(acc);

        if (res != null) {
          acc = res[1];
          return {
            done: false,
            value: res[0]
          };
        }

        return {
          done: true
        };
      }
    };
  });
}
function zip(xs, ys) {
  return map2(function (x, y) {
    return [x, y];
  }, xs, ys);
}
function zip3(xs, ys, zs) {
  return map3(function (x, y, z) {
    return [x, y, z];
  }, xs, ys, zs);
}
function windowed(windowSize, source) {
  if (windowSize <= 0) {
    throw new Error("windowSize must be positive");
  }

  return _babel_runtime_helpers_defineProperty__WEBPACK_IMPORTED_MODULE_1___default()({}, Symbol.iterator, function () {
    var window = [];
    var iter = source[Symbol.iterator]();
    return {
      next: function next() {
        var cur;

        while (window.length < windowSize) {
          if ((cur = iter.next()).done) {
            return {
              done: true
            };
          }

          window.push(cur.value);
        }

        var value = window;
        window = window.slice(1);
        return {
          done: false,
          value: value
        };
      }
    };
  });
}

/***/ }),

/***/ "./.fable/fable-library.2.2.3/String.js":
/*!**********************************************!*\
  !*** ./.fable/fable-library.2.2.3/String.js ***!
  \**********************************************/
/*! exports provided: compare, compareOrdinal, compareTo, startsWith, indexOfAny, printf, toConsole, toConsoleError, toText, toFail, fsFormat, format, endsWith, initialize, insert, isNullOrEmpty, isNullOrWhiteSpace, join, joinWithIndices, validateGuid, newGuid, guidToArray, arrayToGuid, toBase64String, fromBase64String, padLeft, padRight, remove, replace, replicate, getCharAtIndex, split, trim, trimStart, trimEnd, filter */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compare", function() { return compare; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareOrdinal", function() { return compareOrdinal; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "compareTo", function() { return compareTo; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "startsWith", function() { return startsWith; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "indexOfAny", function() { return indexOfAny; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "printf", function() { return printf; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toConsole", function() { return toConsole; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toConsoleError", function() { return toConsoleError; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toText", function() { return toText; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toFail", function() { return toFail; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fsFormat", function() { return fsFormat; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "format", function() { return format; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "endsWith", function() { return endsWith; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "initialize", function() { return initialize; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "insert", function() { return insert; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isNullOrEmpty", function() { return isNullOrEmpty; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "isNullOrWhiteSpace", function() { return isNullOrWhiteSpace; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "join", function() { return join; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "joinWithIndices", function() { return joinWithIndices; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "validateGuid", function() { return validateGuid; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "newGuid", function() { return newGuid; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "guidToArray", function() { return guidToArray; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "arrayToGuid", function() { return arrayToGuid; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "toBase64String", function() { return toBase64String; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "fromBase64String", function() { return fromBase64String; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "padLeft", function() { return padLeft; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "padRight", function() { return padRight; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "remove", function() { return remove; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "replace", function() { return replace; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "replicate", function() { return replicate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "getCharAtIndex", function() { return getCharAtIndex; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "split", function() { return split; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "trim", function() { return trim; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "trimStart", function() { return trimStart; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "trimEnd", function() { return trimEnd; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "filter", function() { return filter; });
/* harmony import */ var _babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @babel/runtime/helpers/toConsumableArray */ "./node_modules/@babel/runtime/helpers/toConsumableArray.js");
/* harmony import */ var _babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @babel/runtime/helpers/typeof */ "./node_modules/@babel/runtime/helpers/typeof.js");
/* harmony import */ var _babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_1__);
/* harmony import */ var _Date__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./Date */ "./.fable/fable-library.2.2.3/Date.js");
/* harmony import */ var _Long__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./Long */ "./.fable/fable-library.2.2.3/Long.js");
/* harmony import */ var _RegExp__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./RegExp */ "./.fable/fable-library.2.2.3/RegExp.js");





var fsFormatRegExp = /(^|[^%])%([0+ ]*)(-?\d+)?(?:\.(\d+))?(\w)/;
var formatRegExp = /\{(\d+)(,-?\d+)?(?:\:([a-zA-Z])(\d{0,2})|\:(.+?))?\}/g; // RFC 4122 compliant. From https://stackoverflow.com/a/13653180/3922220
// const guidRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-[1-5][0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/;
// Relax GUID parsing, see #1637

var guidRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$/;

function cmp(x, y, ic) {
  function isIgnoreCase(i) {
    return i === true || i === 1
    /* CurrentCultureIgnoreCase */
    || i === 3
    /* InvariantCultureIgnoreCase */
    || i === 5
    /* OrdinalIgnoreCase */
    ;
  }

  function isOrdinal(i) {
    return i === 4
    /* Ordinal */
    || i === 5
    /* OrdinalIgnoreCase */
    ;
  }

  if (x == null) {
    return y == null ? 0 : -1;
  }

  if (y == null) {
    return 1;
  } // everything is bigger than null


  if (isOrdinal(ic)) {
    if (isIgnoreCase(ic)) {
      x = x.toLowerCase();
      y = y.toLowerCase();
    }

    return x === y ? 0 : x < y ? -1 : 1;
  } else {
    if (isIgnoreCase(ic)) {
      x = x.toLocaleLowerCase();
      y = y.toLocaleLowerCase();
    }

    return x.localeCompare(y);
  }
}

function compare() {
  for (var _len = arguments.length, args = new Array(_len), _key = 0; _key < _len; _key++) {
    args[_key] = arguments[_key];
  }

  switch (args.length) {
    case 2:
      return cmp(args[0], args[1], false);

    case 3:
      return cmp(args[0], args[1], args[2]);

    case 4:
      return cmp(args[0], args[1], args[2] === true);

    case 5:
      return cmp(args[0].substr(args[1], args[4]), args[2].substr(args[3], args[4]), false);

    case 6:
      return cmp(args[0].substr(args[1], args[4]), args[2].substr(args[3], args[4]), args[5]);

    case 7:
      return cmp(args[0].substr(args[1], args[4]), args[2].substr(args[3], args[4]), args[5] === true);

    default:
      throw new Error("String.compare: Unsupported number of parameters");
  }
}
function compareOrdinal(x, y) {
  return cmp(x, y, 4
  /* Ordinal */
  );
}
function compareTo(x, y) {
  return cmp(x, y, 0
  /* CurrentCulture */
  );
}
function startsWith(str, pattern, ic) {
  if (str.length >= pattern.length) {
    return cmp(str.substr(0, pattern.length), pattern, ic) === 0;
  }

  return false;
}
function indexOfAny(str, anyOf) {
  if (str == null || str === "") {
    return -1;
  }

  var startIndex = (arguments.length <= 2 ? 0 : arguments.length - 2) > 0 ? arguments.length <= 2 ? undefined : arguments[2] : 0;

  if (startIndex < 0) {
    throw new Error("Start index cannot be negative");
  }

  var length = (arguments.length <= 2 ? 0 : arguments.length - 2) > 1 ? arguments.length <= 3 ? undefined : arguments[3] : str.length - startIndex;

  if (length < 0) {
    throw new Error("Length cannot be negative");
  }

  if (length > str.length - startIndex) {
    throw new Error("Invalid startIndex and length");
  }

  str = str.substr(startIndex, length);
  var _iteratorNormalCompletion = true;
  var _didIteratorError = false;
  var _iteratorError = undefined;

  try {
    for (var _iterator = anyOf[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
      var c = _step.value;
      var index = str.indexOf(c);

      if (index > -1) {
        return index + startIndex;
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

  return -1;
}

function toHex(x) {
  if (x instanceof _Long__WEBPACK_IMPORTED_MODULE_3__["default"]) {
    return Object(_Long__WEBPACK_IMPORTED_MODULE_3__["toString"])(x.unsigned ? x : Object(_Long__WEBPACK_IMPORTED_MODULE_3__["fromBytes"])(Object(_Long__WEBPACK_IMPORTED_MODULE_3__["toBytes"])(x), true), 16);
  } else {
    return (Number(x) >>> 0).toString(16);
  }
}

function printf(input) {
  return {
    input: input,
    cont: fsFormat(input)
  };
}
function toConsole(arg) {
  // Don't remove the lambda here, see #1357
  return arg.cont(function (x) {
    console.log(x);
  });
}
function toConsoleError(arg) {
  return arg.cont(function (x) {
    console.error(x);
  });
}
function toText(arg) {
  return arg.cont(function (x) {
    return x;
  });
}
function toFail(arg) {
  return arg.cont(function (x) {
    throw new Error(x);
  });
}

function formatOnce(str2, rep) {
  return str2.replace(fsFormatRegExp, function (_, prefix, flags, pad, precision, format) {
    switch (format) {
      case "f":
      case "F":
        rep = Number(rep).toFixed(precision || 6);
        break;

      case "g":
      case "G":
        rep = Number(rep).toPrecision(precision);
        break;

      case "e":
      case "E":
        rep = Number(rep).toExponential(precision);
        break;

      case "O":
      case "A":
        rep = String(rep);
        break;

      case "x":
        rep = toHex(rep);
        break;

      case "X":
        rep = toHex(rep).toUpperCase();
        break;
    }

    var plusPrefix = flags.indexOf("+") >= 0 && parseInt(rep, 10) >= 0;
    pad = parseInt(pad, 10);

    if (!isNaN(pad)) {
      var ch = pad >= 0 && flags.indexOf("0") >= 0 ? "0" : " ";
      rep = padLeft(String(rep), Math.abs(pad) - (plusPrefix ? 1 : 0), ch, pad < 0);
    }

    var once = prefix + (plusPrefix ? "+" + rep : rep);
    return once.replace(/%/g, "%%");
  });
}

function createPrinter(str, cont) {
  return function () {
    // Make a copy as the function may be used several times
    var strCopy = str;

    for (var _len2 = arguments.length, args = new Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
      args[_key2] = arguments[_key2];
    }

    for (var _i = 0, _args = args; _i < _args.length; _i++) {
      var arg = _args[_i];
      strCopy = formatOnce(strCopy, arg);
    }

    return fsFormatRegExp.test(strCopy) ? createPrinter(strCopy, cont) : cont(strCopy.replace(/%%/g, "%"));
  };
}

function fsFormat(str) {
  return function (cont) {
    return fsFormatRegExp.test(str) ? createPrinter(str, cont) : cont(str);
  };
}
function format(str) {
  for (var _len3 = arguments.length, args = new Array(_len3 > 1 ? _len3 - 1 : 0), _key3 = 1; _key3 < _len3; _key3++) {
    args[_key3 - 1] = arguments[_key3];
  }

  if (_babel_runtime_helpers_typeof__WEBPACK_IMPORTED_MODULE_1___default()(str) === "object" && args.length > 0) {
    // Called with culture info
    str = args[0];
    args.shift();
  }

  return str.replace(formatRegExp, function (match, idx, pad, format, precision, pattern) {
    var rep = args[idx];
    var padSymbol = " ";
    var isNumericType = typeof rep === "number" || rep instanceof _Long__WEBPACK_IMPORTED_MODULE_3__["default"]; // TODO: || (rep instanceof Decimal) || (rep instanceof BigInt);

    if (isNumericType) {
      switch (format) {
        case "f":
        case "F":
          rep = precision ? rep.toFixed(precision) : rep.toFixed(2);
          break;

        case "g":
        case "G":
          rep = precision ? rep.toPrecision(precision) : rep.toPrecision();
          break;

        case "e":
        case "E":
          rep = precision ? rep.toExponential(precision) : rep.toExponential();
          break;

        case "p":
        case "P":
          rep = (precision ? (rep * 100).toFixed(precision) : (rep * 100).toFixed(2)) + " %";
          break;

        case "d":
        case "D":
          rep = precision ? padLeft(rep.toString(), precision, "0") : rep.toString();
          break;

        case "x":
        case "X":
          rep = precision ? padLeft(toHex(rep), precision, "0") : toHex(rep);

          if (format === "X") {
            rep = rep.toUpperCase();
          }

          break;

        default:
          var m = /^(0+)(\.0+)?$/.exec(pattern);

          if (m != null) {
            var decs = 0;

            if (m[2] != null) {
              rep = rep.toFixed(decs = m[2].length - 1);
            }

            pad = "," + (m[1].length + (decs ? decs + 1 : 0)).toString();
            padSymbol = "0";
          } else if (pattern) {
            rep = pattern;
          }

      }
    } else if (rep instanceof Date) {
      rep = Object(_Date__WEBPACK_IMPORTED_MODULE_2__["toString"])(rep, pattern || format);
    }

    pad = parseInt((pad || "").substring(1), 10);

    if (!isNaN(pad)) {
      rep = padLeft(String(rep), Math.abs(pad), padSymbol, pad < 0);
    }

    return rep;
  });
}
function endsWith(str, search) {
  var idx = str.lastIndexOf(search);
  return idx >= 0 && idx === str.length - search.length;
}
function initialize(n, f) {
  if (n < 0) {
    throw new Error("String length must be non-negative");
  }

  var xs = new Array(n);

  for (var i = 0; i < n; i++) {
    xs[i] = f(i);
  }

  return xs.join("");
}
function insert(str, startIndex, value) {
  if (startIndex < 0 || startIndex > str.length) {
    throw new Error("startIndex is negative or greater than the length of this instance.");
  }

  return str.substring(0, startIndex) + value + str.substring(startIndex);
}
function isNullOrEmpty(str) {
  return typeof str !== "string" || str.length === 0;
}
function isNullOrWhiteSpace(str) {
  return typeof str !== "string" || /^\s*$/.test(str);
}
function join(delimiter) {
  for (var _len4 = arguments.length, xs = new Array(_len4 > 1 ? _len4 - 1 : 0), _key4 = 1; _key4 < _len4; _key4++) {
    xs[_key4 - 1] = arguments[_key4];
  }

  return xs.map(function (x) {
    return String(x);
  }).join(delimiter);
}
function joinWithIndices(delimiter, xs, startIndex, count) {
  var endIndexPlusOne = startIndex + count;

  if (endIndexPlusOne > xs.length) {
    throw new Error("Index and count must refer to a location within the buffer.");
  }

  return join.apply(void 0, [delimiter].concat(_babel_runtime_helpers_toConsumableArray__WEBPACK_IMPORTED_MODULE_0___default()(xs.slice(startIndex, endIndexPlusOne))));
}
/** Validates UUID as specified in RFC4122 (versions 1-5). Trims braces. */

function validateGuid(str, doNotThrow) {
  var trimmedAndLowered = trim(str, "{", "}").toLowerCase();

  if (guidRegex.test(trimmedAndLowered)) {
    return doNotThrow ? [true, trimmedAndLowered] : trimmedAndLowered;
  } else if (doNotThrow) {
    return [false, "00000000-0000-0000-0000-000000000000"];
  }

  throw new Error("Guid should contain 32 digits with 4 dashes: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx");
} // From https://gist.github.com/LeverOne/1308368

function newGuid() {
  var b = "";

  for (var a = 0; a++ < 36;) {
    b += a * 51 & 52 ? (a ^ 15 ? 8 ^ Math.random() * (a ^ 20 ? 16 : 4) : 4).toString(16) : "-";
  }

  return b;
} // Maps for number <-> hex string conversion

var _convertMapsInitialized = false;

var _byteToHex;

var _hexToByte;

function initConvertMaps() {
  _byteToHex = new Array(256);
  _hexToByte = {};

  for (var i = 0; i < 256; i++) {
    _byteToHex[i] = (i + 0x100).toString(16).substr(1);
    _hexToByte[_byteToHex[i]] = i;
  }

  _convertMapsInitialized = true;
}
/** Parse a UUID into it's component bytes */
// Adapted from https://github.com/zefferus/uuid-parse


function guidToArray(s) {
  if (!_convertMapsInitialized) {
    initConvertMaps();
  }

  var i = 0;
  var buf = new Uint8Array(16);
  s.toLowerCase().replace(/[0-9a-f]{2}/g, function (oct) {
    switch (i) {
      // .NET saves first three byte groups with different endianness
      // See https://stackoverflow.com/a/16722909/3922220
      case 0:
      case 1:
      case 2:
      case 3:
        buf[3 - i++] = _hexToByte[oct];
        break;

      case 4:
      case 5:
        buf[9 - i++] = _hexToByte[oct];
        break;

      case 6:
      case 7:
        buf[13 - i++] = _hexToByte[oct];
        break;

      case 8:
      case 9:
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
        buf[i++] = _hexToByte[oct];
        break;
    }
  }); // Zero out remaining bytes if string was short

  while (i < 16) {
    buf[i++] = 0;
  }

  return buf;
}
/** Convert UUID byte array into a string */

function arrayToGuid(buf) {
  if (buf.length !== 16) {
    throw new Error("Byte array for GUID must be exactly 16 bytes long");
  }

  if (!_convertMapsInitialized) {
    initConvertMaps();
  }

  return _byteToHex[buf[3]] + _byteToHex[buf[2]] + _byteToHex[buf[1]] + _byteToHex[buf[0]] + "-" + _byteToHex[buf[5]] + _byteToHex[buf[4]] + "-" + _byteToHex[buf[7]] + _byteToHex[buf[6]] + "-" + _byteToHex[buf[8]] + _byteToHex[buf[9]] + "-" + _byteToHex[buf[10]] + _byteToHex[buf[11]] + _byteToHex[buf[12]] + _byteToHex[buf[13]] + _byteToHex[buf[14]] + _byteToHex[buf[15]];
}

function notSupported(name) {
  throw new Error("The environment doesn't support '" + name + "', please use a polyfill.");
}

function toBase64String(inArray) {
  var str = "";

  for (var i = 0; i < inArray.length; i++) {
    str += String.fromCharCode(inArray[i]);
  }

  return typeof btoa === "function" ? btoa(str) : notSupported("btoa");
}
function fromBase64String(b64Encoded) {
  var binary = typeof atob === "function" ? atob(b64Encoded) : notSupported("atob");
  var bytes = new Uint8Array(binary.length);

  for (var i = 0; i < binary.length; i++) {
    bytes[i] = binary.charCodeAt(i);
  }

  return bytes;
}
function padLeft(str, len, ch, isRight) {
  ch = ch || " ";
  len = len - str.length;

  for (var i = 0; i < len; i++) {
    str = isRight ? str + ch : ch + str;
  }

  return str;
}
function padRight(str, len, ch) {
  return padLeft(str, len, ch, true);
}
function remove(str, startIndex, count) {
  if (startIndex >= str.length) {
    throw new Error("startIndex must be less than length of string");
  }

  if (typeof count === "number" && startIndex + count > str.length) {
    throw new Error("Index and count must refer to a location within the string.");
  }

  return str.slice(0, startIndex) + (typeof count === "number" ? str.substr(startIndex + count) : "");
}
function replace(str, search, replace) {
  return str.replace(new RegExp(Object(_RegExp__WEBPACK_IMPORTED_MODULE_4__["escape"])(search), "g"), replace);
}
function replicate(n, x) {
  return initialize(n, function () {
    return x;
  });
}
function getCharAtIndex(input, index) {
  if (index < 0 || index >= input.length) {
    throw new Error("Index was outside the bounds of the array.");
  }

  return input[index];
}
function split(str, splitters, count, removeEmpty) {
  count = typeof count === "number" ? count : null;
  removeEmpty = typeof removeEmpty === "number" ? removeEmpty : null;

  if (count < 0) {
    throw new Error("Count cannot be less than zero");
  }

  if (count === 0) {
    return [];
  }

  if (!Array.isArray(splitters)) {
    if (removeEmpty === 0) {
      return str.split(splitters, count);
    }

    var len = arguments.length;
    splitters = Array(len - 1);

    for (var key = 1; key < len; key++) {
      splitters[key - 1] = arguments[key];
    }
  }

  splitters = splitters.map(function (x) {
    return Object(_RegExp__WEBPACK_IMPORTED_MODULE_4__["escape"])(x);
  });
  splitters = splitters.length > 0 ? splitters : [" "];
  var i = 0;
  var splits = [];
  var reg = new RegExp(splitters.join("|"), "g");

  while (count == null || count > 1) {
    var m = reg.exec(str);

    if (m === null) {
      break;
    }

    if (!removeEmpty || m.index - i > 0) {
      count = count != null ? count - 1 : count;
      splits.push(str.substring(i, m.index));
    }

    i = reg.lastIndex;
  }

  if (!removeEmpty || str.length - i > 0) {
    splits.push(str.substring(i));
  }

  return splits;
}
function trim(str) {
  for (var _len5 = arguments.length, chars = new Array(_len5 > 1 ? _len5 - 1 : 0), _key5 = 1; _key5 < _len5; _key5++) {
    chars[_key5 - 1] = arguments[_key5];
  }

  if (chars.length === 0) {
    return str.trim();
  }

  var pattern = "[" + Object(_RegExp__WEBPACK_IMPORTED_MODULE_4__["escape"])(chars.join("")) + "]+";
  return str.replace(new RegExp("^" + pattern), "").replace(new RegExp(pattern + "$"), "");
}
function trimStart(str) {
  for (var _len6 = arguments.length, chars = new Array(_len6 > 1 ? _len6 - 1 : 0), _key6 = 1; _key6 < _len6; _key6++) {
    chars[_key6 - 1] = arguments[_key6];
  }

  return chars.length === 0 ? str.trimStart() : str.replace(new RegExp("^[" + Object(_RegExp__WEBPACK_IMPORTED_MODULE_4__["escape"])(chars.join("")) + "]+"), "");
}
function trimEnd(str) {
  for (var _len7 = arguments.length, chars = new Array(_len7 > 1 ? _len7 - 1 : 0), _key7 = 1; _key7 < _len7; _key7++) {
    chars[_key7 - 1] = arguments[_key7];
  }

  return chars.length === 0 ? str.trimEnd() : str.replace(new RegExp("[" + Object(_RegExp__WEBPACK_IMPORTED_MODULE_4__["escape"])(chars.join("")) + "]+$"), "");
}
function filter(pred, x) {
  return x.split("").filter(function (c) {
    return pred(c);
  }).join("");
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

/***/ "./node_modules/@babel/runtime/helpers/arrayWithHoles.js":
/*!***************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/arrayWithHoles.js ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _arrayWithHoles(arr) {
  if (Array.isArray(arr)) return arr;
}

module.exports = _arrayWithHoles;

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

/***/ "./node_modules/@babel/runtime/helpers/defineProperty.js":
/*!***************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/defineProperty.js ***!
  \***************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _defineProperty(obj, key, value) {
  if (key in obj) {
    Object.defineProperty(obj, key, {
      value: value,
      enumerable: true,
      configurable: true,
      writable: true
    });
  } else {
    obj[key] = value;
  }

  return obj;
}

module.exports = _defineProperty;

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

/***/ "./node_modules/@babel/runtime/helpers/iterableToArrayLimit.js":
/*!*********************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/iterableToArrayLimit.js ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _iterableToArrayLimit(arr, i) {
  var _arr = [];
  var _n = true;
  var _d = false;
  var _e = undefined;

  try {
    for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) {
      _arr.push(_s.value);

      if (i && _arr.length === i) break;
    }
  } catch (err) {
    _d = true;
    _e = err;
  } finally {
    try {
      if (!_n && _i["return"] != null) _i["return"]();
    } finally {
      if (_d) throw _e;
    }
  }

  return _arr;
}

module.exports = _iterableToArrayLimit;

/***/ }),

/***/ "./node_modules/@babel/runtime/helpers/nonIterableRest.js":
/*!****************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/nonIterableRest.js ***!
  \****************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function _nonIterableRest() {
  throw new TypeError("Invalid attempt to destructure non-iterable instance");
}

module.exports = _nonIterableRest;

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

/***/ "./node_modules/@babel/runtime/helpers/slicedToArray.js":
/*!**************************************************************!*\
  !*** ./node_modules/@babel/runtime/helpers/slicedToArray.js ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

var arrayWithHoles = __webpack_require__(/*! ./arrayWithHoles */ "./node_modules/@babel/runtime/helpers/arrayWithHoles.js");

var iterableToArrayLimit = __webpack_require__(/*! ./iterableToArrayLimit */ "./node_modules/@babel/runtime/helpers/iterableToArrayLimit.js");

var nonIterableRest = __webpack_require__(/*! ./nonIterableRest */ "./node_modules/@babel/runtime/helpers/nonIterableRest.js");

function _slicedToArray(arr, i) {
  return arrayWithHoles(arr) || iterableToArrayLimit(arr, i) || nonIterableRest();
}

module.exports = _slicedToArray;

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

/***/ "./node_modules/file-size/index.js":
/*!*****************************************!*\
  !*** ./node_modules/file-size/index.js ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

var __WEBPACK_AMD_DEFINE_FACTORY__, __WEBPACK_AMD_DEFINE_ARRAY__, __WEBPACK_AMD_DEFINE_RESULT__;// File-Size | 1.0.0 | MIT | Nijiko Yonskai <nijikokun@gmail.com> | 2015
(function (plugin) {
  /* istanbul ignore next: differing implementations */
  if ( true && module.exports) return module.exports = plugin()
  else if (true) return !(__WEBPACK_AMD_DEFINE_ARRAY__ = [], __WEBPACK_AMD_DEFINE_FACTORY__ = (plugin),
				__WEBPACK_AMD_DEFINE_RESULT__ = (typeof __WEBPACK_AMD_DEFINE_FACTORY__ === 'function' ?
				(__WEBPACK_AMD_DEFINE_FACTORY__.apply(exports, __WEBPACK_AMD_DEFINE_ARRAY__)) : __WEBPACK_AMD_DEFINE_FACTORY__),
				__WEBPACK_AMD_DEFINE_RESULT__ !== undefined && (module.exports = __WEBPACK_AMD_DEFINE_RESULT__))
  else {}
})(function () {
  var units = 'BKMGTPEZY'.split('')
  function equals (a, b) { return a && a.toLowerCase() === b.toLowerCase() }

  return function filesize (bytes, options) {
    bytes = typeof bytes == 'number' ? bytes : 0
    options = options || {}
    options.fixed = typeof options.fixed == 'number' ? options.fixed : 2
    options.spacer = typeof options.spacer == 'string' ? options.spacer : ' '

    options.calculate = function (spec) {
      var type = equals(spec, 'si') ? ['k', 'B'] : ['K', 'iB']
      var algorithm = equals(spec, 'si') ? 1e3 : 1024
      var magnitude = Math.log(bytes) / Math.log(algorithm)|0
      var result = (bytes / Math.pow(algorithm, magnitude))
      var fixed = result.toFixed(options.fixed)
      var suffix

      if (magnitude-1 < 3 && !equals(spec, 'si') && equals(spec, 'jedec'))
        type[1] = 'B'

      suffix = magnitude
        ? (type[0] + 'MGTPEZY')[magnitude-1] + type[1]
        : ((fixed|0) === 1 ? 'Byte' : 'Bytes')

      return {
        suffix: suffix,
        magnitude: magnitude,
        result: result,
        fixed: fixed,
        bits: { result: result/8, fixed: (result/8).toFixed(options.fixed) }
      }
    }

    options.to = function (unit, spec) {
      var algorithm = equals(spec, 'si') ? 1e3 : 1024
      var position = units.indexOf(typeof unit == 'string' ? unit[0].toUpperCase() : 'B')
      var result = bytes

      if (position === -1 || position === 0) return result.toFixed(2)
      for (; position > 0; position--) result /= algorithm
      return result.toFixed(2)
    }

    options.human = function (spec) {
      var output = options.calculate(spec)
      return output.fixed + options.spacer + output.suffix
    }

    return options;
  }
})


/***/ }),

/***/ "./src/Renderer/Renderer.fs":
/*!**********************************!*\
  !*** ./src/Renderer/Renderer.fs ***!
  \**********************************/
/*! exports provided: filesize, sizeToHuman, aboutWindow, remote, Navigate, Navigate$reflection, navigation, init */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "filesize", function() { return filesize; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "sizeToHuman", function() { return sizeToHuman; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "aboutWindow", function() { return aboutWindow; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "remote", function() { return remote; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Navigate", function() { return Navigate; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "Navigate$reflection", function() { return Navigate$reflection; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "navigation", function() { return navigation; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "init", function() { return init; });
/* harmony import */ var file_size__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! file-size */ "./node_modules/file-size/index.js");
/* harmony import */ var file_size__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(file_size__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _fable_fable_library_2_2_3_Util_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/Util.js */ "./.fable/fable-library.2.2.3/Util.js");
/* harmony import */ var electron__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! electron */ "electron");
/* harmony import */ var electron__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(electron__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _fable_fable_library_2_2_3_Types_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/Types.js */ "./.fable/fable-library.2.2.3/Types.js");
/* harmony import */ var _fable_fable_library_2_2_3_Reflection_js__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/Reflection.js */ "./.fable/fable-library.2.2.3/Reflection.js");
/* harmony import */ var _fable_fable_library_2_2_3_Event_js__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/Event.js */ "./.fable/fable-library.2.2.3/Event.js");
/* harmony import */ var _fable_fable_library_2_2_3_String_js__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ../../.fable/fable-library.2.2.3/String.js */ "./.fable/fable-library.2.2.3/String.js");







var filesize = file_size__WEBPACK_IMPORTED_MODULE_0__;
function sizeToHuman(size) {
  return function (arg20) {
    return filesize(size).human(arg20);
  }("si");
}
var aboutWindow = Object(_fable_fable_library_2_2_3_Util_js__WEBPACK_IMPORTED_MODULE_1__["createAtom"])(null);
var remote = electron__WEBPACK_IMPORTED_MODULE_2__["remote"];
var Navigate = Object(_fable_fable_library_2_2_3_Types_js__WEBPACK_IMPORTED_MODULE_3__["declare"])(function Renderer_Navigate(arg1) {
  this.Path = arg1;
}, _fable_fable_library_2_2_3_Types_js__WEBPACK_IMPORTED_MODULE_3__["Record"]);
function Navigate$reflection() {
  return Object(_fable_fable_library_2_2_3_Reflection_js__WEBPACK_IMPORTED_MODULE_4__["record"])("Renderer.Navigate", [], Navigate, function () {
    return [["Path", _fable_fable_library_2_2_3_Reflection_js__WEBPACK_IMPORTED_MODULE_4__["string"]]];
  });
}
var navigation = new _fable_fable_library_2_2_3_Event_js__WEBPACK_IMPORTED_MODULE_5__["default"]();
function init() {
  Object(_fable_fable_library_2_2_3_String_js__WEBPACK_IMPORTED_MODULE_6__["toConsole"])(Object(_fable_fable_library_2_2_3_String_js__WEBPACK_IMPORTED_MODULE_6__["printf"])("calling initMenu()"));
}
init();

/***/ }),

/***/ "./src/Renderer/Renderer.fsproj":
/*!**************************************!*\
  !*** ./src/Renderer/Renderer.fsproj ***!
  \**************************************/
/*! exports provided: filesize, sizeToHuman, aboutWindow, remote, Navigate, Navigate$reflection, navigation, init */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./Renderer.fs */ "./src/Renderer/Renderer.fs");
/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "filesize", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["filesize"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "sizeToHuman", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["sizeToHuman"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "aboutWindow", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["aboutWindow"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "remote", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["remote"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "Navigate", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["Navigate"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "Navigate$reflection", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["Navigate$reflection"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "navigation", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["navigation"]; });

/* harmony reexport (safe) */ __webpack_require__.d(__webpack_exports__, "init", function() { return _Renderer_fs__WEBPACK_IMPORTED_MODULE_0__["init"]; });



/***/ }),

/***/ "electron":
/*!***************************!*\
  !*** external "electron" ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = require("electron");

/***/ })

/******/ });
//# sourceMappingURL=renderer.js.map