const transform = (transformationsStr, str) => {
  const parseResult = parseTransformations(transformationsStr);

  const invalid = parseResult.find(result => !result.valid); 
  if (invalid)
    return `Invalid Transformation "${invalid.token}"`;

  const transformations = parseResult.map(result => result.token);

  return composed(transformations)(str);
}

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
  transformations.split('=>')
    .map(parseTransformation);

const parseTransformation = transformationStr => {
  const transformation = handlers[transformationStr];
  return transformation 
    ? { valid: true, token: transformation } 
    : { valid: false, token: transformationStr };
};

const compose = (f, g) => a => g(f(a));

const composed = transformations =>
  transformations
    .reduce((composite, current) => compose(composite, current));

module.exports = transform;