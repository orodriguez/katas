const transform = (transformations, str) => {
  const pascalCase = str => 
    str.split(' ')
      .map(w => w.charAt(0).toUpperCase() + w.slice(1))
      .join(" ");
  
  const handlers = {
    '': str => str,
    'Lowercase': str => str.toLowerCase(),
    'Uppercase': str => str.toUpperCase(),
    'Trim-Start': str => str.trimLeft(),
    'Trim-End': str => str.trimRight(),
    'PascalCase': pascalCase
  };
  

  return handlers[transformations](str);
}

module.exports = transform;