const transform = (transformations, str) => {
  const toPascalCase = str => 
    str.split(/(\s)/g) 
      .map(token => token.charAt(0).toUpperCase() + token.slice(1));

  const toCamelCase = str => 
    toPascalCase(str)
      .map((token, i) => i == 0 ? token.toLowerCase() : token)
  
  const handlers = {
    '': str => str,
    'Lowercase': str => str.toLowerCase(),
    'Uppercase': str => str.toUpperCase(),
    'Trim-Start': str => str.trimLeft(),
    'Trim-End': str => str.trimRight(),
    'PascalCase': str => toPascalCase(str).join(''),
    'CamelCase': str => toCamelCase(str).join('')
  };
  

  return handlers[transformations](str);
}

module.exports = transform;