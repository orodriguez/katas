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