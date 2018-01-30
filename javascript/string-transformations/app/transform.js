const transform = (transformations, str) => buildTransformation(transformations)(str);

const buildTransformation = transformations => {
  const parsingResults = parseTransformations(transformations);

  const invalid = parsingResults.find(result => !result.valid);

  if (invalid)
    return str => `Invalid Transformation "${invalid.token}"`;

  return parsingResults
    .map(result => result.handler)
    .reduce((composed, handler) => str => handler(composed(str)));
};

const parseTransformations = transformations => transformations
  .split('=>')
  .map(token => handlers[token] 
    ? { valid: true, token, handler: handlers[token]} 
    : { valid: false, token });

const pascalCase = str => str
  .split(/(\s)/g)
  .filter(token => token !== '')
  .map(pascalToken)
  .join('');

const pascalToken = str => 
  str[0].toUpperCase() + str.slice(1).toLowerCase();

const camelCase = str => {
  const pascalCased = pascalCase(str);
  const firstWord = pascalCased.match(/\w+/)[0];
  return pascalCased.replace(/\w+/, firstWord.toLowerCase());
};

const snakeCase = str => str
  .split(/[\s\t\r!@#$%^&*]/)
  .join('_');

const pack = str => str
  .split(/\s/)
  .join('');

const handlers = {
  '': str => str,
  'Uppercase': str => str.toUpperCase(),
  'Lowercase': str => str.toLowerCase(),
  'Trim-Start': str => str.trimLeft(),
  'Trim-End': str => str.trimRight(),
  'PascalCase': pascalCase,
  'CamelCase': camelCase,
  'SnakeCase': snakeCase,
  'Pack': pack
};

module.exports = transform;