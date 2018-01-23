const transform = (transformations, str) => 
  buildTransformation(transformations)(str);

const buildTransformation = transStr => {
  const result = parseTransformations(transStr);
  
  const invalid = result.find(t => !t.valid)

  return invalid 
    ? str => `Invalid Transformation "${invalid.token}"` 
    : composeTransformations(result);
}

const parseTransformations = transStr =>
  transStr
    .split('=>')
    .map(token => handlers[token] 
      ? { valid: true,  token, handler: handlers[token] } 
      : { valid: false, token, handler: null });

const composeTransformations = parsingResults => 
  parsingResults
    .map(result => result.handler)
    .reduce((composed, transformation) => str => transformation(composed(str)))

const pascalCase = str =>  
  str.split(/(\s)/g)
    .filter(token => token !== '')
    .map(pascalWord)
    .join('');

const pascalWord = token => 
  token[0].toUpperCase() + token.slice(1).toLowerCase();

const camelCase = str => {
  const pascalCased = pascalCase(str);
  const firstWord = pascalCased.match(/\w+/)[0];
  return pascalCased.replace(/\w+/, firstWord.toLowerCase());
};

const snakeCase = str => str
  .split(/[!@#$%^&*()_+\s]/)
  .join('_');

const pack = str => str
  .split(/[\s\t\n]/)
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
  'Pack': pack,
};

module.exports = transform;