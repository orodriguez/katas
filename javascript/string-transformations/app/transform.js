const transform = (transformations, str) => {
  const handlers = {
    '': str => str,
    'Lowercase': str => str.toLowerCase(),
    'Uppercase': str => str.toUpperCase(),
    'Trim-Start': str => str.trimLeft(),
    'Trim-End': str => str.trimRight(),
  };
  
  return handlers[transformations](str);
}

module.exports = transform;