test = require('tape');

const transform = require('../app/transform');

test('None', (t) => {
  t.plan(1);
  t.equal(transform('', 'Hello world'), 'Hello world');
});