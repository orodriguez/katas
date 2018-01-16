const transform = (transformations, str) => 
  (transformations === 'Uppercase') ? str.toUpperCase() : str;

module.exports = transform;