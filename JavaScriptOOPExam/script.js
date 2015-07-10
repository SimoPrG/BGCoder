function solve() {

    Array.prototype.getUnique = function () {
        var u = {}, a = [];
        for (var i = 0, l = this.length; i < l; ++i) {
            if (u.hasOwnProperty(this[i])) {
                continue;
            }
            a.push(this[i]);
            u[this[i]] = 1;
        }
        return a;
    };

    var module,
        validator;

    validator = {
        validateIfUndefined: function (val, name) {
            name = name || 'Value';
            if (val === undefined) {
                throw new Error(name + ' cannot be undefined');
            }
        },
        validateIfObject: function (val, name) {
            name = name || 'Value';

            this.validateIfUndefined(val, name);

            if (typeof val !== 'object') {
                throw new Error(name + ' must be an object');
            }
        },
        validateIfNumber: function (val, name) {
            name = name || 'Value';

            this.validateIfUndefined(val, name);

            if (typeof val !== 'number') {
                throw new Error(name + ' must be a number');
            }
        },
        validatePositiveNumber: function (val, name) {
            name = name || 'Value';

            this.validateIfNumber(val, name);

            if (val <= 0) {
                throw new Error(name + ' must be positive number');
            }
        },
        validateNumberRange: function (val, name, min, max) {
            name = name || 'Value';

            this.validateIfNumber(val, name);

            if (val < min || max < val) {
                throw new Error(name + ' must be between '
                    + min
                    + ' and ' + max);
            }
        },
        validateIfString: function (val, name) {
            name = name || 'Value';

            this.validateIfUndefined(val, name);

            if (typeof val !== 'string') {
                throw new Error(name + ' must be a string');
            }
        },
        validateStringRange: function (val, name, minLength, maxLength) {
            name = name || 'Value';
            this.validateIfString(val, name);

            if (typeof val !== 'string') {
                throw new Error(name + ' must be a string');
            }

            if (val.length < minLength
                || maxLength < val.length) {
                throw new Error(name + ' must be between ' + minLength +
                    ' and ' + maxLength + ' symbols');
            }
        },
        validateIfEmptyString: function (val, name) {
            name = name || 'Value';

            this.validateIfString(val, name);

            if (val.length === 0) {
                throw new Error(name + ' must not be empty string');
            }
        },
        validateISBN: function (val, name) {
            name = name || 'Value';

            this.validateIfString(val, name);

            if (!/^(?:\d{10}|\d{13})$/.test(val)) {
                throw new Error(name + ' must be 10 or 13 digits');
            }
        }
    };

    module = (function () {
        var item,
            book,
            media,
            catalog,
            bookCatalog,
            mediaCatalog,
            findOptions = {};

        item = (function () {
            var currentItemId = 0,
                item = {};

            Object.defineProperty(item, 'init', {
                value: function (name, description) {
                    this.name = name;
                    this.description = description;
                    this._id = ++currentItemId;

                    return this;
                }
            });

            Object.defineProperty(item, 'id', {
                get: function () {
                    return this._id;
                }
            });

            Object.defineProperty(item, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (val) {
                    validator.validateStringRange(val, 'Item name', 2, 40);
                    this._name = val;
                }
            });

            Object.defineProperty(item, 'description', {
                get: function () {
                    return this._description;
                },
                set: function (val) {
                    validator.validateStringRange(val, 'Item name', 1, Number.MAX_VALUE);
                    this._description = val;
                }
            });

            return item;
        }());

        book = (function (parent) {
            var book = Object.create(parent);
            Object.defineProperty(book, 'init', {
                value: function (name, isbn, genre, description) {
                    parent.init.call(this, name, description);
                    this._isbn = isbn;
                    this.genre = genre;

                    return this;
                }
            });

            Object.defineProperty(book, 'isbn', {
                get: function () {
                    return this._isbn;
                },
                set: function (val) {
                    validator.validateISBN(val, 'isbn');
                    this._isbn = val;
                }
            });

            Object.defineProperty(book, 'genre', {
                get: function () {
                    return this._genre;
                },
                set: function (val) {
                    validator.validateStringRange(val, 'Book genre', 2, 20);
                    this._genre = val;
                }
            });

            return book;
        }(item));

        media = (function (parent) {
            var media = Object.create(parent);

            Object.defineProperty(media, 'init', {
                value: function (name, rating, duration, description) {
                    parent.init.call(this, name, description);
                    this.rating = rating;
                    this.duration = duration;

                    return this;
                }
            });

            Object.defineProperty(media, 'rating', {
                get: function () {
                    return this._rating;
                },
                set: function (val) {
                    validator.validateNumberRange(val, 'Media rating', 1, 5);

                    this._rating = val;
                }
            });

            Object.defineProperty(media, 'duration', {
                get: function () {
                    return this._duration;
                },
                set: function (val) {
                    validator.validatePositiveNumber(val, 'Media duration');

                    this._duration = val;
                }
            });

            return media;
        }(item));

        catalog = (function () {
            var catalogId = 0,
                catalog = {};

            Object.defineProperty(catalog, 'init', {
                value: function (name) {
                    this.name = name;
                    this._id = ++catalogId;
                    this.items = [];

                    return this;
                }
            });

            Object.defineProperty(catalog, 'name', {
                get: function () {
                    return this._name;
                },
                set: function (val) {
                    validator.validateStringRange(val, 'Catalog name', 2, 40);

                    this._name = val;
                }
            });

            Object.defineProperty(catalog, 'id', {
                get: function () {
                    return this._id;
                }
            });

            Object.defineProperty(catalog, 'add', {
                value: function () {
                    var items = Array.prototype.slice.apply(arguments);

                    if (items.length === 0) {
                        throw new Error('You cannot add zero items.')
                    }

                    if (items[0] instanceof Array) {
                        items = items[0];
                    }

                    if (items.length === 0) {
                        throw new Error('You cannot add zero items array.')
                    }

                    items.forEach(function (item) {
                        validator.validateIfUndefined(item.id, 'Item id');
                        validator.validateIfUndefined(item.name, 'Item name');
                        validator.validateIfUndefined(item.description, 'Item description');
                    });

                    this.items = this.items.concat(items);

                    return this;
                }
            });

            Object.defineProperty(catalog, 'find', {
                value: function (options) {
                    var i,
                        len,
                        findOptionsKeys,
                        result = [];

                    switch (typeof options) {
                        case 'number':
                            for (i = 0, len = this.items.length; i < len; i += 1) {
                                if (this.items[i].id === options) {
                                    return this.items[i];
                                }
                            }

                            return null;

                        case 'object':
                            if (options.hasOwnProperty('id')) {
                                findOptions.id = options.id;
                            }

                            if (options.hasOwnProperty('name')) {
                                findOptions.name = options.name;
                            }

                            findOptionsKeys = Object.keys(findOptions);

                            result = this.items.filter(function (item) {
                                var isMatching = true;
                                findOptionsKeys.forEach(function (key) {
                                    var itemKey = item[key],
                                        optionKey = findOptions[key];

                                    if (itemKey.toString().toLowerCase() !== optionKey.toString().toLowerCase()) {
                                        isMatching = false;
                                    }
                                });

                                return isMatching;
                            });

                            findOptions = {};

                            return result;

                        default :
                            throw new Error('Options must be object or id number')
                    }
                }
            });

            Object.defineProperty(catalog, 'search', {
                value: function (pattern) {
                    var result;
                    validator.validateIfEmptyString(pattern, 'Pattern');

                    result = this.items.filter(function (item) {
                        return item.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0 ||
                            item.description.toLowerCase().indexOf(pattern.toLowerCase()) >= 0;
                    });

                    return result;
                }
            });

            return catalog;
        }());

        bookCatalog = (function (parent) {
            var bookCatalog = Object.create(parent);

            Object.defineProperty(bookCatalog, 'init', {
                value: function (name) {
                    parent.init.call(this, name);

                    return this;
                }
            });

            Object.defineProperty(bookCatalog, 'add', {
                value: function () {
                    var items = Array.prototype.slice.apply(arguments);

                    if (items.length === 0) {
                        throw new Error('You cannot add zero items.')
                    }

                    if (items[0] instanceof Array) {
                        items = items[0];
                    }

                    if (items.length === 0) {
                        throw new Error('You cannot add zero items array.')
                    }

                    items.forEach(function (item) {
                        validator.validateIfUndefined(item.id, 'Item id');
                        validator.validateIfUndefined(item.name, 'Item name');
                        validator.validateIfUndefined(item.description, 'Item description');
                        validator.validateIfUndefined(item.isbn, 'Book isbn');
                        validator.validateIfUndefined(item.genre, 'Book isbn');
                    });

                    this.items = this.items.concat(items);

                    return this;
                }
            });

            Object.defineProperty(bookCatalog, 'getGenres', {
                value: function () {
                    return this.items.map(function (item) {
                        return item.genre.toLowerCase();
                    }).getUnique();
                }
            });

            Object.defineProperty(bookCatalog, 'find', {
                value: function (options) {
                    if (options.genre !== 'undefined') {
                        findOptions.genre = options.genre;
                    }

                    return parent.find.call(this, options);
                }
            });

            return bookCatalog;
        }(catalog));

        mediaCatalog = (function (parent) {
            var mediaCatalog = Object.create(parent);

            Object.defineProperty(mediaCatalog, 'init', {
                value: function (name) {
                    parent.init.call(this, name);

                    return this;
                }
            });

            Object.defineProperty(mediaCatalog, 'add', {
                value: function () {
                    var items = Array.prototype.slice.apply(arguments);

                    if (items.length === 0) {
                        throw new Error('You cannot add zero items.')
                    }

                    if (items[0] instanceof Array) {
                        items = items[0];
                    }

                    if (items.length === 0) {
                        throw new Error('You cannot add zero items array.')
                    }

                    items.forEach(function (item) {
                        validator.validateIfUndefined(item.id, 'Item id');
                        validator.validateIfUndefined(item.name, 'Item name');
                        validator.validateIfUndefined(item.description, 'Item description');
                        validator.validateIfUndefined(item.rating, 'Item rating');
                        validator.validateIfUndefined(item.duration, 'Item duration');
                    });

                    this.items = this.items.concat(items);

                    return this;
                }
            });

            Object.defineProperty(mediaCatalog, 'getTop', {
                value: function (count) {
                    validator.validateIfNumber(count);
                    if (count < 1) {
                        throw new Error('count must be greater than 1')
                    }

                    this.items.sort(function (item1, item2) {
                        return item1.rating - item2.rating;
                    });

                    return this.items.slice(0, count);
                }
            });

            Object.defineProperty(mediaCatalog, 'getSortedByDuration', {
                value: function () {

                    return this.items.sort(function (item1, item2) {
                        if (item2.duration - item1.duration < 0) {
                            return -1;
                        } else if (item2.duration - item1.duration > 0) {
                            return 1;
                        }

                        return item1.id - item2.id;
                    });
                }
            });

            return mediaCatalog;
        }(catalog));

        var module = {
            getBook: function (name, isbn, genre, description) {
                return Object.create(book).init(name, isbn, genre, description);
            },
            getMedia: function (name, rating, duration, description) {
                return Object.create(media).init(name, rating, duration, description);
            },
            getBookCatalog: function (name) {
                return Object.create(bookCatalog).init(name);
            },
            getMediaCatalog: function (name) {
                return Object.create(mediaCatalog).init(name);
            }
        };

        return module;
    }());

    return module;
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

console.log(catalog.find(book1.id));
//returns book1

console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2

console.log(catalog.search('js'));
// returns book2

console.log(catalog.search('javascript'));
//returns book1 and book2

console.log(catalog.search('Te sa zeleni'));
//returns []
