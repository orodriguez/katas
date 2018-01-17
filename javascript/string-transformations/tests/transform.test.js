test = require('tape');

const transform = require('../app/transform');

const transformationTest = ([transformations,  input, expected]) => 
  test(transformations, t => {
    t.plan(1);
    t.equal(transform(transformations, input), expected);
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
  ['SnakeCase', 'hello!my!friend', 'hello_my_friend'],
  ['Pack', 'hello\tmy\nfriend there', 'hellomyfriendthere'],
  ['Trim-Start=>Trim-End=>PascalCase=>Pack', 
    ' to be or not to be: that is the question. ', 'ToBeOrNotToBe:ThatIsTheQuestion.'],
  ['Trim-Start=>Trim-End=>SnakeCase=>Uppercase', 
    ' to be or not to be: that is the question. ', 'TO_BE_OR_NOT_TO_BE:_THAT_IS_THE_QUESTION.'],
  //['Invalid', 'Something', 'Invalid Transformation "Invalid"']
].forEach(transformationTest);