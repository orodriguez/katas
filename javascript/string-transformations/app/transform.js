const transform = (transformations, str) => {
  const toPascalCase = str => 
    str.split(/(\s)/g) 
      .map(token => token.charAt(0).toUpperCase() + token.slice(1).toLowerCase());

  const toCamelCase = str => {
    let found = false;
    return toPascalCase(str)
      .map(token => {
        if (!found && token.match(/\w+/))
        {
          found = true;
          return token.toLowerCase();
        }

        return token;
      });
  };

  const toSnakeCase = str => 
    str.split(/[,!@#$%^&*()\s]/).join('_');

  const pack = str => str.split(/[\t\n\d\r\s]/).join('');

  const handlers = {
    '': str => str,
    'Lowercase': str => str.toLowerCase(),
    'Uppercase': str => str.toUpperCase(),
    'Trim-Start': str => str.trimLeft(),
    'Trim-End': str => str.trimRight(),
    'PascalCase': str => toPascalCase(str).join(''),
    'CamelCase': str => toCamelCase(str).join(''),
    'SnakeCase': str => toSnakeCase(str),
    'Pack': pack
  };

  const parseTransformations = transformations => 
    transformations.split('=>');

  const compose = (f, g) => a => g(f(a));
  
  const composed = parseTransformations(transformations)
    .map(t => handlers[t])
    .reduce((composite, current) => compose(composite, current));
  
  return composed(str);
}

module.exports = transform;