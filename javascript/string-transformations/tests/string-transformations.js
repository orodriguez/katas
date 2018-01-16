test = require('tape');

const transform = require('../app/transform');

const transformationTest = ([transformation,  input, expected]) => 
  test(transformation, t => {
    t.plan(1);
    t.equal(transform(transformation, input), expected);
  });

[
  ['', 'Hello world', 'Hello world'],
  ['Uppercase', 'Hello world', 'HELLO WORLD'],
  ['Lowercase', 'Hello world', 'hello world'],
  ['Trim-Start', '\n\t   Hello world', 'Hello world'],
  ['Trim-End', 'Hello world\n\t   ', 'Hello world'],
  ['PascalCase', 'hello WORLD', 'Hello World'],
  ['PascalCase', '   HeLLo  woRld   ', '   Hello  World   '],
  ['CamelCase', 'HEllo  wORld', 'hello  World'],
  ['CamelCase', '  HELLO  WORLD  ', '  hello  World  '],
  ['SnakeCase', 'hello my friend', 'hello_my_friend'],
  ['SnakeCase', 'hello!my!friend', 'hello_my_friend']
].forEach(transformationTest);