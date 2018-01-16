const transform = (transformations, str) => {
  const handlers = {
    '': str => str,
    'Lowercase': str => str.toLowerCase(),
    'Uppercase': str => str.toUpperCase()
  };
  
  return handlers[transformations](str);
}

module.exports = transform;