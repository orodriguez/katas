test = require('tape');

const transform = require('../app/transform');

test('None', (t) => {
  t.plan(1);
  t.equal(transform('', 'Hello world'), 'Hello world');
});

test('Uppercase', (t) => {
  t.plan(1);
  t.equal(transform('Uppercase', 'Hello world'), 'HELLO WORLD');
});

test('Lowercase', (t) => {
  t.plan(1);
  t.equal(transform('Lowercase', 'Hello world'), 'hello world');
});

test('Trim-Start', (t) => {
  t.plan(1);
  t.equal(transform('Trim-Start', '\n\t   Hello world'), 'Hello world');
});

test('Trim-End', (t) => {
  t.plan(1);
  t.equal(transform('Trim-End', 'Hello world\n\t   '), 'Hello world');
});

test('PascalCase', (t) => {
  t.plan(1);
  t.equal(transform('PascalCase', 'hello world'), 'Hello World');
});

test('PascalCase with many spaces', (t) => {
  t.plan(1);
  t.equal(transform('PascalCase', '   hello  world   '), '   Hello  World   ');
});